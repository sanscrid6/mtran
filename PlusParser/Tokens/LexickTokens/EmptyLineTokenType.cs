using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class EmptyLineTokenType: TokenTypeBase
{
    public EmptyLineTokenType() : base(@"\s*\r?\n")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new EmptyLineToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}