using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class BoolOperatorTokenType: TokenTypeBase
{
    public BoolOperatorTokenType() : base(@"<=|^<|^>")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new BoolOperatorToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}