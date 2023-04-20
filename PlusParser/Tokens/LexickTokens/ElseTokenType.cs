using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ElseTokenType: TokenTypeBase
{
    public ElseTokenType() : base(@"else")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ElseToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}