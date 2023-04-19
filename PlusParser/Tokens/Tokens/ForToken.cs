namespace PlusParser.Tokens.Tokens;

public class ForToken: TokenBase, IKeyword
{
    public ForToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }

    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var closeClauseEndIndex = nextTokens.FindIndex(t => t is CloseParamsToken);
        var head = nextTokens.Skip(0).Take(closeClauseEndIndex + 1).ToList();
        /*if (head.Count(t => t is SemicolonToken) != 2)
        {
            BuildError("missing semicolon in for declaration", head[0].start, head[0].lineNumber);
        }*/

        if (head.FirstOrDefault(t => t is OpenParamsToken) == null)
        {
            BuildError("missing ( in for clause declaration", head[0].start, head[0].lineNumber);
        }
        
        if (head.FirstOrDefault(t => t is CloseParamsToken) == null)
        {
            BuildError("missing ) in for clause declaration", head[0].start, head[0].lineNumber);
        }
        
        return true;
    }
}