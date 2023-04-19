namespace PlusParser.Tokens.Tokens;

public class StreamOperatorToken: TokenBase, IOperator
{
    public StreamOperatorToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}