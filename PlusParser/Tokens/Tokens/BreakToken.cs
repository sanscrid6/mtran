namespace PlusParser.Tokens.Tokens;

public class BreakToken: TokenBase, IKeyword
{
    public BreakToken(string val, int start, int end) : base(val, start, end)
    {
    }
}