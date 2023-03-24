namespace PlusParser.Tokens.Tokens;

public class CaseToken: TokenBase, IKeyword
{
    public CaseToken(string val, int start, int end) : base(val, start, end)
    {
    }
}