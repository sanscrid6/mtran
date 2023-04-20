using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class LogicOperatorTokenType: TokenTypeBase
{
    public LogicOperatorTokenType() : base(@"&&|^\|\|")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new LogicOperatorToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}