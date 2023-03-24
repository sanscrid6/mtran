using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class IncludeTokenType: TokenTypeBase
{
    public IncludeTokenType() : base(@"#include <\w+>\r?\n?")
    {
    }

    public override TokenBase CreateToken(Match match)
    {
        return new IncludeToken(match.Value, match.Index, match.Length);
    }
}