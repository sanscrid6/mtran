using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ColonTokenType: TokenTypeBase
{
    public ColonTokenType() : base(@":\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new ColonToken(match.Value, match.Index, match.Length);
    }
}