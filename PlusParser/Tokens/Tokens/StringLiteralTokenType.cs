using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class StringLiteralToken: TokenBase, ILiteral
{
    public StringLiteralToken(string val, int start, int end) : base(val, start, end)
    {
    }
}