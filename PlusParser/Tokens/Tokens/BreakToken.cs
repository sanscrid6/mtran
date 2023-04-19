namespace PlusParser.Tokens.Tokens;

public class BreakToken: TokenBase, IKeyword
{
    public BreakToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
}