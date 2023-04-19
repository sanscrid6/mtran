namespace PlusParser.Tokens.Tokens;

public class UsingNamespaceToken: TokenBase, IKeyword
{
    public UsingNamespaceToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        Lexer.variables.Add(nextTokens[1].value, "namespace");
    }
}