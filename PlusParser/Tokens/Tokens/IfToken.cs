namespace PlusParser.Tokens.Tokens;

public class IfToken: TokenBase, IKeyword
{
    public IfToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }


    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var closeClauseEndIndex = nextTokens.FindIndex(t => t is CloseParamsToken);
        var head = nextTokens.Skip(0).Take(closeClauseEndIndex + 1).ToList();

        if (head.FirstOrDefault(t => t is OpenParamsToken) == null)
        {
            BuildError("missing ( in if clause declaration", head[0].start, head[0].lineNumber);
        }

        return true;
    }
}