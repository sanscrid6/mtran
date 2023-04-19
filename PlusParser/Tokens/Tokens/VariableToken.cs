namespace PlusParser.Tokens.Tokens;

public class VariableToken: TokenBase
{
    public VariableToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
}