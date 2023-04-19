using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class IncludeTokenType: TokenTypeBase
{
    public IncludeTokenType() : base(@"#include <\w+>")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new IncludeToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}