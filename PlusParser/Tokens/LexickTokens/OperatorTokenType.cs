using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OperatorTokenType: TokenTypeBase
{
    public OperatorTokenType() : base(@"(\+=)|^(\+\+)")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new OperatorToken(match.Value, match.Index, match.Length);
    }
}