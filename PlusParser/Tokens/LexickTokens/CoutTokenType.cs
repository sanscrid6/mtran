using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CoutTokenType: TokenTypeBase
{
    public CoutTokenType() : base(@"cout")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CoutToken(match.Value, match.Index, match.Length);
    }
}