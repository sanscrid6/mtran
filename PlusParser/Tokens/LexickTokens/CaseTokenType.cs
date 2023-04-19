using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CaseTokenType: TokenTypeBase
{
    public CaseTokenType() : base(@"case")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CaseToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}