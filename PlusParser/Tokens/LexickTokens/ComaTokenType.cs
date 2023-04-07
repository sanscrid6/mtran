using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ComaTokenType: TokenTypeBase
{
    public ComaTokenType() : base(@",")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new ComaToken(match.Value, match.Index, match.Length);
    }
}