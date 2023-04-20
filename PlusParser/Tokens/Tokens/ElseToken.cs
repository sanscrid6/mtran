namespace PlusParser.Tokens.Tokens;

public class ElseToken: TokenBase, IKeyword
{
    public ElseToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}