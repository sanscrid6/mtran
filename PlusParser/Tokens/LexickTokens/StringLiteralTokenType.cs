using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StringLiteralTokenType: TokenTypeBase
{
    public StringLiteralTokenType() : base(@""".+""")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new StringLiteralToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}