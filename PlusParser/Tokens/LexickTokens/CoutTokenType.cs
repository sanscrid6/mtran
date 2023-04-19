using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CoutTokenType: TokenTypeBase
{
    public CoutTokenType() : base(@"cout")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CoutToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}