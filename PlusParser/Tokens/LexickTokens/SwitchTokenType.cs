using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SwitchTokenType: TokenTypeBase
{
    public SwitchTokenType() : base(@"switch")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new SwitchToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}