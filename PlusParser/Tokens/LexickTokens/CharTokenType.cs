using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CharTokenType: TokenTypeBase
{
    public CharTokenType() : base(@"char")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CharToken(match.Value, match.Index, match.Length);
    }
}