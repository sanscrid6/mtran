namespace PlusParser.Tokens.Tokens;

public class SwitchToken: TokenBase, IKeyword
{
    public SwitchToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        var isVariableDeclaration = (nextTokens[3] is AssignToken);

        if (isVariableDeclaration)
        {
            Lexer.variables.Add(nextTokens[1].value, this.value);
        }
    }

    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var closeClauseEndIndex = nextTokens.FindIndex(t => t is CloseParamsToken);
        var head = nextTokens.Skip(0).Take(closeClauseEndIndex + 1).ToList();

        if (head.FirstOrDefault(t => t is OpenParamsToken) == null)
        {
            BuildError("missing ( in switch declaration", head[0].start, head[0].lineNumber);
        }

        return true;
    }
}