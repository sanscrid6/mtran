namespace PlusParser.Tokens.Tokens;

public class ForToken: TokenBase, IKeyword
{
    public ForToken(string val, int start, int end) : base(val, start, end)
    {
    }

    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var closeClauseEndIndex = nextTokens.FindIndex(t => t is CloseParamsToken);
        var head = nextTokens.Skip(0).Take(closeClauseEndIndex + 1).ToList();
        if (head.Count(t => t is SemicolonToken) != 2)
        {
            throw new Exception("missing semicolon in for declaration");
        }

        if (head.FirstOrDefault(t => t is OpenParamsToken) == null)
        {
            throw new Exception("missing ( in for clause declaration");
        }
        
        return true;
    }
}