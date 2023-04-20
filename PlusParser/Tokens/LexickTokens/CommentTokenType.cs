using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class CommentTokenType: TokenTypeBase
{
    public CommentTokenType() : base(@"//.+\r?\n")
    {
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new CommentToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}