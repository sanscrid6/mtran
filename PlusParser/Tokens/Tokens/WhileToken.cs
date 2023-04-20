namespace PlusParser.Tokens.Tokens;

public class WhileToken: TokenBase, IKeyword
{
    public WhileToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}