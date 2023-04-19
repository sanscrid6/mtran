using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class BreakTokenType: TokenTypeBase
{
    public BreakTokenType() : base(@"break")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new BreakToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}