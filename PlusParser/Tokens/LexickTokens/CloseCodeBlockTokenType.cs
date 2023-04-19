using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CloseCodeBlockTokenType: TokenTypeBase
{
    public CloseCodeBlockTokenType() : base(@"\r?\n?\}\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CloseCodeBlockToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}