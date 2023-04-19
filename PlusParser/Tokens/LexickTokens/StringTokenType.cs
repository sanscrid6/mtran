using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StringTokenType: TokenTypeBase
{
    public StringTokenType() : base(@"string")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new StringToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}