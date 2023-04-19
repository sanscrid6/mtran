namespace PlusParser.Tokens.Tokens;

public class AssignToken: TokenBase, IOperator
{
    public AssignToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
}