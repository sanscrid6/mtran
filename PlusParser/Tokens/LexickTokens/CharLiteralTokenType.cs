using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CharLiteralTokenType: TokenTypeBase
{
    public CharLiteralTokenType() : base(@"'.'")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CharLiteralToken(match.Value, match.Index, match.Length);
    }
}