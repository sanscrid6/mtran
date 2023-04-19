using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CinTokenType: TokenTypeBase
{
    public CinTokenType() : base(@"cin")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CinToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}