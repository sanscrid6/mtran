using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class EOLTokenType: TokenTypeBase
{
    public EOLTokenType(): base(@";\r?\n")
    {
        
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new EOLToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}