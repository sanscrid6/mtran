using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SpaceTokenType: TokenTypeBase
{
    public SpaceTokenType() : base(@" +")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new SpaceToken(match.Value, match.Index, match.Length);
    }
}