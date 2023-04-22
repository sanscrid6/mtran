using System.Text.RegularExpressions;

namespace PlusParser.Tokens.Tokens;

public class IncludeToken: TokenBase
{
    public IncludeToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        var r = new Regex(@"<\w+>");
        var name = r.Match(this.value);

        Lexer.keywords.Add("#include");
        Lexer.variables.Add(name.Value.Substring(1,name.Value.Length - 2), "library");
    }
}