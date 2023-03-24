using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class BoolOperatorTokenType: TokenTypeBase
{
    public BoolOperatorTokenType() : base(@"<=|^<")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new BoolOperatorToken(match.Value, match.Index, match.Length);
    }
}