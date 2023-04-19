using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ColonTokenType: TokenTypeBase
{
    public ColonTokenType() : base(@":\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ColonToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}