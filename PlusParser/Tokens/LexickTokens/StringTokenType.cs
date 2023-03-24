using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StringTokenType: TokenTypeBase
{
    public StringTokenType() : base(@"string")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new StringToken(match.Value, match.Index, match.Length);;
    }
}