using System.Text.RegularExpressions;
using PlusParser.Tokens.LexickTokens;
using PlusParser.Tokens.Tokens;

public class FloatTokenType : TokenTypeBase
{
    public FloatTokenType() : base(@"float")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new FloatToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}