using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OperatorTokenType: TokenTypeBase
{
    public OperatorTokenType() : base(@"(\+=)|^(\+\+)|^(--)")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new OperatorToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}