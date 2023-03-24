using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CaseTokenType: TokenTypeBase
{
    public CaseTokenType() : base(@"case")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CaseToken(match.Value, match.Index, match.Length);
    }
}