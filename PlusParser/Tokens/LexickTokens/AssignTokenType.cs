using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class AssignTokenType: TokenTypeBase
{
    public AssignTokenType() : base(@"=")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new AssignToken(match.Value, match.Index, match.Length);
    }
}