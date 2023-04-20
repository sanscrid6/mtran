using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class IfTokenType: TokenTypeBase
{
    public IfTokenType() : base(@"if")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new IfToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}