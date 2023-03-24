using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class VariableTokenType: TokenTypeBase
{
    public VariableTokenType(): base(@"\w+")
    {
       
    }

    public override TokenBase CreateToken(Match match)
    {
        return new VariableToken(match.Value, match.Index, match.Length);
    }
}