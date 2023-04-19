namespace PlusParser.Tokens.Tokens;


public interface IKeyword
{
}

public interface IOperator
{
}

public interface ILiteral
{
}

public abstract class TokenBase
{
    public readonly string value;
    public readonly int start;
    public readonly int end;
    public readonly int lineNumber;

    public TokenBase(string val, int start, int end, int lineNumber)
    {
        value = val;
        this.start = start;
        this.end = end;
        this.lineNumber = lineNumber;
    }

    public virtual bool IsValid(List<TokenBase> nextTokens)
    {
        return true;
    }

    public virtual void FillTable(List<TokenBase> nextTokens)
    {
    }

    public override string ToString()
    {
        return value;
    }

    public static void BuildError(string text, int start, int line)
    {
        throw new Exception($"line {line + 1}:{start}: {text}");
    }

    public static void BuildError(string text)
    {
        throw new Exception($"{text}");
    }

    public bool IsLiteral()
    {
        return this is StringLiteralToken || this is FloatLiteralToken || this is IntLiteralToken ||
               this is CharLiteralToken;
    }
}