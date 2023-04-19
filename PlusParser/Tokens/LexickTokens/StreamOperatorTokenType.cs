using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StreamOperatorTokenType: TokenTypeBase
{
    public StreamOperatorTokenType() : base(@"<<|^>>")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new StreamOperatorToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}