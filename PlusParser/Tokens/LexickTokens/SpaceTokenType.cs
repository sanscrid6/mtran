using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class SpaceTokenType: TokenTypeBase
{
    public SpaceTokenType() : base(@" +")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new SpaceToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}