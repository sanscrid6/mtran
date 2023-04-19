using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SemicolonTokenType: TokenTypeBase
{
    public SemicolonTokenType(): base(@";")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new SemicolonToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}