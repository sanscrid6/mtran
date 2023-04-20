using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class VoidTokenType: TokenTypeBase
{
    public VoidTokenType() : base("void")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new VoidToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}