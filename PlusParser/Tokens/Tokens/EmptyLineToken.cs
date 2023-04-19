namespace PlusParser.Tokens.Tokens;

public class EmptyLineToken: TokenBase
{
    public EmptyLineToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}