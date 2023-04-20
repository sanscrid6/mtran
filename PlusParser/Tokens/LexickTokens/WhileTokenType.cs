using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class WhileTokenType: TokenTypeBase
{
    public WhileTokenType() : base(@"while")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new WhileToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}