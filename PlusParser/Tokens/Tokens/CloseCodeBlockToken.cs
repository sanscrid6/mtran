using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class CloseCodeBlockToken: TokenBase
{
    public CloseCodeBlockToken(string val, int start, int end) : base(val, start, end)
    {
    }
}