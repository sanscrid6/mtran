using System.Text.RegularExpressions;
using PlusParser.Tokens.Tokens;

namespace PlusParser.Tokens.LexickTokens;

public class UsingNamespaceTokenType: TokenTypeBase
{
    public UsingNamespaceTokenType(): base(@"using namespace")
    {
       
    }

    public override TokenBase CreateToken(Match match)
    {
        return new UsingNamespaceToken(match.Value, match.Index, match.Length);
    }
}