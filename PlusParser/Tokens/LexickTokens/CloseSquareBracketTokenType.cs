using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CloseSquareBracketTokenType: TokenTypeBase
{
    public CloseSquareBracketTokenType() : base(@"\]")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CloseSquareBracketToken(match.Value, offset + match.Index, match.Length, lineNumber);

    }
}