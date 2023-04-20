using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public abstract class TokenTypeBase
{
    public readonly Regex regex;

    public abstract TokenBase CreateToken(Match match, int offset, int lineNumber);

    public TokenTypeBase(string regular)
    {
        regex = new Regex("^"+regular);
    }
    
    public TokenTypeBase(string regular, RegexOptions options)
    {
        regex = new Regex("^"+regular, options);
    }
}