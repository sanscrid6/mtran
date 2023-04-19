namespace PlusParser.Tokens.Tokens;

public class BoolOperatorToken: TokenBase, IOperator
{
    public BoolOperatorToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
}