using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CharLiteralTokenType: TokenTypeBase
{
    public CharLiteralTokenType() : base(@"'.'")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CharLiteralToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}