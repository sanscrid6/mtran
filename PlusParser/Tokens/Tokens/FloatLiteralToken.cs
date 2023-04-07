namespace PlusParser.Tokens.Tokens;

public class FloatLiteralToken: TokenBase, ILiteral
{
    public FloatLiteralToken(string val, int start, int end) : base(val, start, end)
    {
    }
}