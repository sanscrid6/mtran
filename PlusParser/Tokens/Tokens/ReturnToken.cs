namespace PlusParser.Tokens.Tokens;

public class ReturnToken: TokenBase, IKeyword
{
    public ReturnToken(string val, int start, int end) : base(val, start, end)
    {
    }
}