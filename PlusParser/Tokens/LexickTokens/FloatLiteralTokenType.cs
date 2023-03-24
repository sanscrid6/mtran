using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class FloatLiteralTokenType: TokenTypeBase
{
    public FloatLiteralTokenType(): base(@"\d+\.\d+")
    {
        
    }

    public override TokenBase CreateToken(Match match)
    {
        return new FloatLiteralToken(match.Value, match.Index, match.Length);
    }
}