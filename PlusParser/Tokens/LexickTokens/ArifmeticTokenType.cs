using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ArifmeticTokenType: TokenTypeBase
{
    public ArifmeticTokenType() : base(@"\+|^-|^\*|^\/")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new ArifmeticToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}