namespace PlusParser.Tokens.Tokens;

public class ReturnToken: TokenBase, IKeyword
{
    public ReturnToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}