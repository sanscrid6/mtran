namespace PlusParser.Tokens.Tokens;

public class CommentToken: TokenBase
{
    public CommentToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}