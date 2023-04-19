using System.Runtime.InteropServices;
using PlusParser.AST;
using PlusParser.Tokens.LexickTokens;
using PlusParser.Tokens.Tokens;

namespace PlusParser;

public static class Parser
{
   private static Tree<TokenBase> _ast = new();
   
   public static void BuildAST(List<TokenBase> tokens)
   {
      var curr = _ast.root;
      
      var s = tokens.Aggregate(new List<List<TokenBase>>(), (acc, curr) =>
      {
         if (acc.Count == 0)
         {
            acc.Add(new List<TokenBase>());
         }

         if (curr is EOLToken || curr is ColonToken || curr is OpenCodeBlockToken)
         {
            acc.Add(new List<TokenBase>());
         }
         else
         {
            acc[^1].Add(curr);
         }
         
         return acc;
      });
      
      s.ForEach(q =>
      {
         if (q[0] is SpaceToken)
         {
            q.RemoveAt(0);
         }
      });

      if (tokens.Count(t => t is OpenCodeBlockToken) != tokens.Count(t => t is CloseCodeBlockToken))
      {
         TokenBase.BuildError("missing }");
      }


      for (int i = 0; i < s.Count; i++)
      {
         // s[i].Print();
         // Console.WriteLine("===========================================================================");
         if (s[i].Find(t => t is CloseCodeBlockToken) != null)
         {
            var count = s[i].Count(t => t is CloseCodeBlockToken);
            for (int j = 0; j < count; j++)
            {
               curr = curr.GetPrev();
            }
         }
         
         if (s[i].Find(t => t is CoutToken || t is CinToken) != null)
         {
            var start = s[i].FindIndex(t => t is CoutToken || t is CinToken);
            BuildCoutOrCin(s[i].Skip(start).Take(s[i].Count).ToList(), curr);
         }
         else if (s[i][0] is IntToken && s[i][2] is VariableToken && s[i][3] is OpenParamsToken) // is function
         {
            curr = curr.AddChildren(s[i][2]);
         }
         else if (s[i][0] is SwitchToken)
         {
            curr = BuildSwitch(s[i], curr);
         }
         else if (s[i].Find(t => t is CaseToken) != null)
         {
            curr = BuildCase(s[i], curr);
         }
         else if (s[i][0] is BreakToken)
         {
            curr = curr.GetPrev();
            curr = curr.GetPrev();
         }
         else if (s[i].Find(t => t is ForToken) != null)
         {
            curr = BuildFor(s[i], curr);
         } 
         else if (s[i][0] is VariableToken || s[i][0] is StringToken || s[i][0] is IntToken || s[i][0] is CharToken || s[i][0] is FloatToken )
         {
            BuildAssign(s[i], curr);
         }

         
      }
      
      _ast.Print();
   }

   private static Node<TokenBase> BuildFor(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      var forHead = tokens.Split(t => t is SemicolonToken);
      if (forHead.Count < 3) 
         TokenBase.BuildError("missing semicolon in for declaration", forHead[0][0].start, forHead[0][0].lineNumber);
      curr = curr.AddChildren(tokens[0]);
      BuildAssign(forHead[0], curr);
      BuildBooleanExpression(forHead[1], curr);
      BuildExpression(forHead[2], curr);
      return curr;
   }

   private static void BuildBooleanExpression(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      var operands = tokens.FindAll(t => t is VariableToken || t.IsLiteral());
      var binaryOperator = tokens.Find(t => t is BoolOperatorToken)!;

      curr = curr.AddChildren(binaryOperator);
      
      curr.AddChildren(operands[0]);
      curr.AddChildren(operands[1]);
   }

   private static void BuildAssign(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      var variable = tokens.FindIndex(t => t is VariableToken);
      var literal = tokens.FindIndex(variable+1, t => t.IsLiteral() || t is VariableToken);
      var assign = tokens.Find(t => t is IOperator);
      if (assign == null) 
         return;
      
      curr = curr.AddChildren(assign);
      if(variable != -1)
         curr.AddChildren(tokens[variable]);
      if(literal != -1)
         curr.AddChildren(tokens[literal]);
   }

   private static void BuildExpression(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      if (tokens.Count == 1)
      {
         curr.AddChildren(tokens[0]);
         return;
      }

      var operands = tokens.FindAll(t => t is VariableToken || t.IsLiteral())!;
      var binaryOperator = tokens.Find(t => t is IOperator)!;
      
      curr = curr.AddChildren(binaryOperator);
      
      curr.AddChildren(operands[0]);
      if(operands.Count > 1)
         curr.AddChildren(operands[1]);
   }

   private static void BuildCoutOrCin(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      for (int i = 0; i < tokens.Count; i++)
      {
         if (tokens[i] is VariableToken)
         {
            var streamIndex = tokens.Skip(i).ToList().FindFirstIndex(t => t is StreamOperatorToken);
            var q = tokens.Skip(i).ToList();
            var expressionTokens = tokens.Skip(i).Take(streamIndex != -1 ? streamIndex: tokens.Count).ToList();
            BuildExpression(expressionTokens.Where(t => !(t is SpaceToken)).ToList(), curr);
            //curr = curr.GetPrev();
            i = streamIndex != -1 ? streamIndex + i: tokens.Count;
            i = Math.Clamp(i, 0, tokens.Count);
            i--;
         }

         if (tokens[i] is CoutToken || tokens[i] is CinToken)
         {
            curr = curr.AddChildren(tokens[i]);
         }

         if (tokens[i] is StringLiteralToken || tokens[i] is CharLiteralToken)
         {
            curr.AddChildren(tokens[i]);
         }
      }
   }

   private static Node<TokenBase> BuildSwitch(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      if (tokens.Find(t => t is OpenParamsToken) == null) 
         TokenBase.BuildError("expected ( after switch", tokens[0].start, tokens[0].lineNumber);
      
      curr = curr.AddChildren(tokens.Find(t => t is SwitchToken)!);
      curr = curr.AddChildren(tokens.Find(t => t is VariableToken)!);
      return curr;
   }
   
   private static Node<TokenBase> BuildCase(List<TokenBase> tokens, Node<TokenBase> curr)
   {
      curr = curr.AddChildren(tokens.Find(t => t is CaseToken)!);
      var caseVar = tokens.Find(t => t.IsLiteral());
      if (caseVar == null) TokenBase.BuildError("expected literal in case ");
      
      curr = curr.AddChildren(caseVar);
      return curr;
   }
}