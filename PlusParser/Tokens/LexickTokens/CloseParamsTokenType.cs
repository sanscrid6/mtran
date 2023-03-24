using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CloseParamsTokenType: TokenTypeBase
{
    public CloseParamsTokenType() : base(@"\)")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CloseParamsToken(match.Value, match.Index, match.Length);
    }
}