namespace PlusParser.Tokens.Tokens;

public class ArifmeticToken: TokenBase, IOperator
{
    public ArifmeticToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}