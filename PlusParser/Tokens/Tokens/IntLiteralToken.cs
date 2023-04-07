namespace PlusParser.Tokens.Tokens;

public class IntLiteralToken: TokenBase, ILiteral
{
    public IntLiteralToken(string val, int start, int end) : base(val, start, end)
    {
    }
}