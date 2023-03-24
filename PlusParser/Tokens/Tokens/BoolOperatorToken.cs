namespace PlusParser.Tokens.Tokens;

public class BoolOperatorToken: TokenBase, IOperator
{
    public BoolOperatorToken(string val, int start, int end) : base(val, start, end)
    {
    }
}