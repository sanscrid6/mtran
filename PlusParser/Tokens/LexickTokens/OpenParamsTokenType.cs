using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OpenParamsTokenType: TokenTypeBase
{
    public OpenParamsTokenType() : base(@"\(")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new OpenParamsToken(match.Value, match.Index, match.Length);
    }
}