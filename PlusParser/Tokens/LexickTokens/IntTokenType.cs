using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class IntTokenType: TokenTypeBase
{
    public IntTokenType(): base(@"int")
    {
      
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new IntToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}