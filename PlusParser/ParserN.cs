using PlusParser.AST;
using PlusParser.Tokens.Tokens;

namespace PlusParser;

public static class ParserN
{
    private static Tree<INode> _ast = new();
    

    public static void q(List<TokenBase> tokens)
    {
        var curr = _ast.root;
      
        var s = tokens.Aggregate(new List<List<TokenBase>>(), (acc, curr) =>
        {
            if (acc.Count == 0)
            {
                acc.Add(new List<TokenBase>());
            }

            acc[^1].Add(curr);

            if (curr.value.Contains('\n'))
            {
                acc.Add(new List<TokenBase>());
            }
         
            return acc;
        });


        for (int i = 0; i < s.Count; i++)
        {
            var isFunctionDeclaration = s[i].Count > 0 && s[i][0] is VoidToken or IntToken && 
                                        s[i].Find(t => t is OpenParamsToken) != null && 
                                        s[i].Find(t => t is OpenCodeBlockToken) != null || 
                                        s.Count < i + 1 && s[i+1].Find(t => t is OpenCodeBlockToken) != null;
            
            if (s[i].Find(t => t is IfToken or ElseToken or ForToken or WhileToken or SwitchToken or IncludeToken or CaseToken) == null &&
                !isFunctionDeclaration &&
                !(s[i].Count == 1 && s[i][0] is EmptyLineToken) && 
                !s[i].All(t => t is SpaceToken or CloseCodeBlockToken or OpenCodeBlockToken) &&  
                !(s[i].Count == 1 && s[i][0] is CommentToken)
               )
            {
                if (s[i].Find(t => t is EOLToken) == null)
                {
                    TokenBase.BuildError($"expected semicolon", s[i][s[i].Count - 1].start, s[i][s[i].Count - 1].lineNumber);
                }
            }
            
            
        }
    }
}