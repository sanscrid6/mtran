using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class OpenSquareBracketTokenType: TokenTypeBase
{
    public OpenSquareBracketTokenType() : base(@"\[")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new OpenSquareBracketToken(match.Value, offset + match.Index, match.Length, lineNumber);

    }
}