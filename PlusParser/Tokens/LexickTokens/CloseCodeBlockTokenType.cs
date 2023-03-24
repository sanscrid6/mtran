using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CloseCodeBlockTokenType: TokenTypeBase
{
    public CloseCodeBlockTokenType() : base(@"\r?\n?\}\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new CloseCodeBlockToken(match.Value, match.Index, match.Length);
    }
}