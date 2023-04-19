using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class AssignTokenType: TokenTypeBase
{
    public AssignTokenType() : base(@"=")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new AssignToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}