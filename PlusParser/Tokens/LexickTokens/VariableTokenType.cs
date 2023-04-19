using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class VariableTokenType: TokenTypeBase
{
    public VariableTokenType(): base(@"\w+")
    {
       
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new VariableToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}