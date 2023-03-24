using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ReturnTokenType: TokenTypeBase
{
    public ReturnTokenType() : base(@"return")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new ReturnToken(match.Value, match.Index, match.Length);
    }
}