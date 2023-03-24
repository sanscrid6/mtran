namespace PlusParser.Tokens.Tokens;

public class OperatorToken: TokenBase, IOperator
{
    public OperatorToken(string val, int start, int end) : base(val, start, end)
    {
    }
}