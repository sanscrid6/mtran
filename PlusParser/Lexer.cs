using System.Runtime.CompilerServices;
using PlusParser.Tokens.LexickTokens;
using PlusParser.Tokens.Tokens;

namespace PlusParser;

public static class Lexer
{
    private static List<TokenTypeBase> _lexicalTokens = new()
    {
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
        new VariableTokenType(),
        new EmptyLineTokenType()
    };

    public static Dictionary<string, string> variables = new();
    public static HashSet<string> keywords = new();
    public static HashSet<string> operators = new ();
    public static HashSet<string> constants = new();

    public static int offset = 0; 
    // public static Dictionary<Type, string> operators = new();

    public static List<TokenBase> Parse(string programLike)
    {
        var pos = 0;
        var tokens = new List<TokenBase>();
        var lineNumber = 0;
        var lineOffset = 0;
        var hasExpressionOnLine = false;
        
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
                    if (!hasExpressionOnLine && token is not IncludeToken and not EmptyLineToken and not EOLToken)
                    {
                        hasExpressionOnLine = true;
                    }

                    if (hasExpressionOnLine && token is EmptyLineToken)
                    {
                        TokenBase.BuildError($"expected semicolon", lineOffset, lineNumber);
                    }

                    pos += match.Length;
                    lineOffset += match.Length;
                    if (token is EOLToken or EmptyLineToken)
                    {
                        lineNumber++;
                        lineOffset = 0;
                        hasExpressionOnLine = false;
                    }
                    break;
                }
            }

            if (token is null)
            {
                if (currString.StartsWith('"'))
                    TokenBase.BuildError($"cant find string quote", lineOffset, lineNumber);
                if (currString.StartsWith("'"))
                    TokenBase.BuildError($"cant find char quote", lineOffset, lineNumber);

                TokenBase.BuildError($"unknown error in program", lineOffset, lineNumber);
            }
            else
            {
                tokens.Add(token);
            }
        }
        Validate(tokens);
        FillTable(tokens);

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