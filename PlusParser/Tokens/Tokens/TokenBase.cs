namespace PlusParser.Tokens.Tokens;


public interface IKeyword
{
}

public interface IOperator
{
}

public abstract class TokenBase
{
    public readonly string value;
    public readonly int start;
    public readonly int end;

    public Type[] next = Array.Empty<Type>();

    public TokenBase(string val, int start, int end)
    {
        value = val;
        this.start = start;
        this.end = end;
    }

    public virtual bool IsValid(List<TokenBase> nextTokens)
    {
        return true;
    }

    public virtual void FillTable(List<TokenBase> nextTokens)
    {
    }
}