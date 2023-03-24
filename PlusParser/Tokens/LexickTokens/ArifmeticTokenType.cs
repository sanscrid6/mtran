using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class ArifmeticTokenType: TokenTypeBase
{
    public ArifmeticTokenType() : base(@"\+|^-|^\*|^\/")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new ArifmeticToken(match.Value, match.Index, match.Length);
    }
}