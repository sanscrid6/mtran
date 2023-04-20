namespace PlusParser.Tokens.Tokens;

public class IfToken: TokenBase, IKeyword
{
    public IfToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}