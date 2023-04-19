using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class FloatLiteralTokenType: TokenTypeBase
{
    public FloatLiteralTokenType(): base(@"\d+\.\d+")
    {
        
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new FloatLiteralToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}