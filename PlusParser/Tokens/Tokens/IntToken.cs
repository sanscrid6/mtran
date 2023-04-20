using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class IntToken: TokenBase, IKeyword
{
    public IntToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
       
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        var isFunction = (nextTokens[1] is VariableToken && nextTokens[2] is OpenParamsToken);
        var isVariableDeclaration = (nextTokens[3] is AssignToken);


        if (isVariableDeclaration)
        {
            /*if (Lexer.variables.ContainsKey(nextTokens[1].value))
                BuildError($"variable {nextTokens[1].value} already declared");*/

            /*if (!(nextTokens[5] is IntLiteralToken))
                BuildError($"invalid assign operation, expected integer got {nextTokens[5].GetType()}");*/

            if (!Lexer.variables.ContainsKey(nextTokens[1].value))
            {
                Lexer.variables.Add(nextTokens[1].value, "int");
            }
        }

        if (isFunction)
        {
            var closeClauseEndIndex = nextTokens.FindIndex(t => t is CloseParamsToken);
            var head = nextTokens.Skip(0).Take(closeClauseEndIndex + 1).ToList();
            for (int i = 0; i < head.Count; i++)
            {
                if (head[i] is IntToken)
                {
                    Lexer.variables.Add(head[i + 2].value, "int");
                }
            }
            
            Lexer.variables.Add(nextTokens[1].value, "function");
        }
    }
}