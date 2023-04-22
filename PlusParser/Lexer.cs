using System.Runtime.CompilerServices;
using PlusParser.Tokens.LexickTokens;
using PlusParser.Tokens.Tokens;

namespace PlusParser;

public static class Lexer
{
    private static List<TokenTypeBase> _lexicalTokens = new()
    {
        new CommentTokenType(),
        new EOLTokenType(),
        new ComaTokenType(),
        new ColonTokenType(),
        new CoutTokenType(),
        new CinTokenType(),
        new SwitchTokenType(),
        new BreakTokenType(),
        new CharTokenType(),
        new CharLiteralTokenType(),
        new StreamOperatorTokenType(),
        new BoolOperatorTokenType(),
        new OperatorTokenType(),
        new CaseTokenType(),
        new CloseParamsTokenType(),
        new OpenParamsTokenType(),
        new OpenCodeBlockTokenType(),
        new CloseCodeBlockTokenType(),
        new ReturnTokenType(),
        new ForTokenType(),
        new SemicolonTokenType(),
        new FloatTokenType(),
        new IntTokenType(),
        new SpaceTokenType(),
        new FloatLiteralTokenType(),
        new IncludeTokenType(),
        new ArifmeticTokenType(),
        new UsingNamespaceTokenType(),
        new StringLiteralTokenType(),
        new StringTokenType(),
        new IntLiteralTokenType(),
        new AssignTokenType(),
        new WhileTokenType(),
        new VoidTokenType(),
        new IfTokenType(),
        new ElseTokenType(),
        new OpenSquareBracketTokenType(),
        new CloseSquareBracketTokenType(),
        new VariableTokenType(),
        new EmptyLineTokenType(),
        new LogicOperatorTokenType()
    };

    public static Dictionary<string, string> variables = new();
    public static HashSet<string> keywords = new();
    public static HashSet<string> operators = new ();
    public static HashSet<string> constants = new();

    public static List<TokenBase> Parse(string programLike)
    {
        var pos = 0;
        var tokens = new List<TokenBase>();
        var lineNumber = 0;
        var lineOffset = 0;
        var hasExpressionOnLine = false;
        
        if (programLike.Count(c => c == '"') % 2 != 0)
            TokenBase.BuildError($"cant find string quote");
        if (programLike.Count(c => c == "'".ToCharArray()[0]) % 2 != 0)
            TokenBase.BuildError($"cant find char quote");
        
        while (pos < programLike.Length)
        {
            TokenBase token = null;
            var currString = programLike.Substring(pos);
            foreach (var lexToken in _lexicalTokens)
            {
                var match = lexToken.regex.Match(currString);
                if (match.Success)
                {
                    token = lexToken.CreateToken(match, lineOffset, lineNumber);
                    
                    if (!hasExpressionOnLine && token is not IncludeToken and not EmptyLineToken and not EOLToken and not CommentToken)
                    {
                        hasExpressionOnLine = true;
                    }

                    pos += match.Length;
                    lineOffset += match.Length;
                   
                    if (token.value.Contains('\n'))
                    {
                        lineNumber += token.value.Count(t => t == '\n');
                        lineOffset = 0;
                        hasExpressionOnLine = false;
                    }

                    break;
                }
            }

            if (token is null)
            {
                Console.WriteLine(currString);
                TokenBase.BuildError($"unknown error in program", lineOffset, lineNumber);
            }
            else
            {
                tokens.Add(token);
            }
        }
        
        Validate(tokens);
        FillTable(tokens);
        //tokens.ForEach(t => Console.WriteLine(t.GetType()));
        return tokens;
    }

    private static void Validate(List<TokenBase> tokens)
    {
        tokens.Where(t => t is IKeyword)
              .ToList()
              .ForEach(keyword => keywords.Add(keyword.value));
        
        tokens
            .Where(t => t is IOperator)
            .ToList()
            .ForEach(keyword => operators.Add(keyword.value));
        
        for (int i = 0; i < tokens.Count; i++)
        {
            tokens[i].IsValid(tokens.Skip(i + 1).Take(tokens.Count - 1 - i).ToList());
        }
    }

    private static void FillTable(List<TokenBase> tokens)
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            tokens[i].FillTable(tokens.Skip(i + 1).Take(tokens.Count - 1 - i).ToList());
        }
    }
}