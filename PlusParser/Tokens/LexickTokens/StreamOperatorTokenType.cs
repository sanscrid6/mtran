using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class StreamOperatorTokenType: TokenTypeBase
{
    public StreamOperatorTokenType() : base(@"<<|^>>")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new StreamOperatorToken(match.Value, match.Index, match.Length);
    }
}