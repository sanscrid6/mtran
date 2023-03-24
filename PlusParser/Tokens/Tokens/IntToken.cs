using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class IntToken: TokenBase, IKeyword
{
    public IntToken(string val, int start, int end) : base(val, start, end)
    {
       
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        var isFunction = (nextTokens[1] is VariableToken && nextTokens[2] is OpenParamsToken);
        var isVariableDeclaration = (nextTokens[3] is AssignToken);

        if (isVariableDeclaration)
        {
            // int main()
            //int q = 1;
            Lexer.variables.Add(nextTokens[1], "int");
        }
    }
}