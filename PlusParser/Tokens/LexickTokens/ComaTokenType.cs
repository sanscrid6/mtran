using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ComaTokenType: TokenTypeBase
{
    public ComaTokenType() : base(@",")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ComaToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}