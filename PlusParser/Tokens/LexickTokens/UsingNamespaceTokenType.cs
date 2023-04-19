using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class UsingNamespaceTokenType: TokenTypeBase
{
    public UsingNamespaceTokenType(): base(@"using namespace")
    {
       
    }

    public override TokenBase CreateToken(Match match, int offset, int lineNumber)
    {
        return new UsingNamespaceToken(match.Value, offset + match.Index, match.Length, lineNumber);
    }
}