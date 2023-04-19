using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CharTokenType: TokenTypeBase
{
    public CharTokenType() : base(@"char")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CharToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}