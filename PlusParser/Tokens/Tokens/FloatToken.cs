namespace PlusParser.Tokens.Tokens;

public class FloatToken: TokenBase, IKeyword
{
    public FloatToken(string val, int start, int end) : base(val, start, end)
    {
        next = new[]
        {
            typeof(SpaceToken),
            typeof(VariableToken),
        };
    }
}