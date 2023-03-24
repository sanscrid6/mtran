namespace PlusParser.Tokens.Tokens;

public class UsingNamespaceToken: TokenBase, IKeyword
{
    public UsingNamespaceToken(string val, int start, int end) : base(val, start, end)
    {
    }
}