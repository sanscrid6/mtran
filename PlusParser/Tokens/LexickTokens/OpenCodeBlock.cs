using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OpenCodeBlockTokenType: TokenTypeBase
{
    public OpenCodeBlockTokenType() : base(@"\r?\n?\{\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new OpenCodeBlockToken(match.Value, match.Index, match.Length);
    }
}