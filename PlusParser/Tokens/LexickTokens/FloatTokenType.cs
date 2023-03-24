using System.Text.RegularExpressions;
using PlusParser.Tokens.LexickTokens;
using PlusParser.Tokens.Tokens;

public class FloatTokenType : TokenTypeBase
{
    public FloatTokenType() : base(@"float")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new FloatToken(match.Value, match.Index, match.Length);
    }
}