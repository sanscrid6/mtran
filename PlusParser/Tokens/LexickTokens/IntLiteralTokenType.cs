using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class IntLiteralTokenType: TokenTypeBase
{
    public IntLiteralTokenType() : base(@"-?\d+")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new IntLiteralToken(match.Value, match.Index, match.Length);
    }
}