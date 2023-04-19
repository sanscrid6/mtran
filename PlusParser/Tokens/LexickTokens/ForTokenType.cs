using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ForTokenType: TokenTypeBase
{
    public ForTokenType() : base(@"for")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ForToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}