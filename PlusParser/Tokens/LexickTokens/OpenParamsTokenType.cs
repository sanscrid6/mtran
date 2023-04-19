using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OpenParamsTokenType: TokenTypeBase
{
    public OpenParamsTokenType() : base(@"\(")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new OpenParamsToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}