namespace PlusParser.Tokens.Tokens;

public class SwitchToken: TokenBase, IKeyword
{
    public SwitchToken(string val, int start, int end) : base(val, start, end)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        var isVariableDeclaration = (nextTokens[3] is AssignToken);

        if (isVariableDeclaration)
        {
            Lexer.variables.Add(nextTokens[1], this.value);
        }
    }
}