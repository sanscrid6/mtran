using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StringLiteralTokenType: TokenTypeBase
{
    public StringLiteralTokenType() : base(@""".+""")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new StringLiteralToken(match.Value, match.Index, match.Length);
    }
}