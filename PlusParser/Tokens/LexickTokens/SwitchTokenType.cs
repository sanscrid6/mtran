using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SwitchTokenType: TokenTypeBase
{
    public SwitchTokenType() : base(@"switch")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new SwitchToken(match.Value, match.Index, match.Length);;
    }
}