using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CloseParamsTokenType: TokenTypeBase
{
    public CloseParamsTokenType() : base(@"\)")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CloseParamsToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}