namespace PlusParser.Tokens.Tokens;

public class CharLiteralToken: TokenBase, ILiteral
{
    public CharLiteralToken(string val, int start, int end) : base(val, start, end)
    {
    }
}