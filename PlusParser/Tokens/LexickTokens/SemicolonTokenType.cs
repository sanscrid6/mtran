using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SemicolonTokenType: TokenTypeBase
{
    public SemicolonTokenType(): base(@";")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new SemicolonToken(match.Value, match.Index, match.Length);
    }
}