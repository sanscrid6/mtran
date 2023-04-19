namespace PlusParser.Tokens.Tokens;

public class OpenCodeBlockToken: TokenBase
{
    public OpenCodeBlockToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}