namespace PlusParser.Tokens.Tokens;

public class CharToken: TokenBase, IKeyword
{
    public CharToken(string val, int start, int end) : base(val, start, end)
    {
    }
}