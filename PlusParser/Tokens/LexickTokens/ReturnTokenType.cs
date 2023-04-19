using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ReturnTokenType: TokenTypeBase
{
    public ReturnTokenType() : base(@"return")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ReturnToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}