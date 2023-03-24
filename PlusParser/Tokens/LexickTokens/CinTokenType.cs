using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CinTokenType: TokenTypeBase
{
    public CinTokenType() : base(@"cin")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CinToken(match.Value, match.Index, match.Length);
    }
}