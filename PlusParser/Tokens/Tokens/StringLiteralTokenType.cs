using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class StringLiteralToken: TokenBase
{
    public StringLiteralToken(string val, int start, int end) : base(val, start, end)
    {
    }
}