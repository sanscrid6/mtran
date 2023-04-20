namespace PlusParser.Tokens.Tokens;

public class LogicOperatorToken: TokenBase, IOperator
{
    public LogicOperatorToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}