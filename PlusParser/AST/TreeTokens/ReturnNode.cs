namespace PlusParser.AST.TreeTokens;

public class ReturnNode: BaseNode
{
    public readonly BaseNode? Value;

    public ReturnNode(BaseNode? value)
    {
        Value = value;
    }

    public override object? Execute()
    {
        var ex = new ReturnEx();
        ex.Value = Value?.Execute();
        throw ex;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + $"return\n" + 
               Extensions.If(() => Value != null, Value?.Dump(level + 1, true), $"{DrawNode(level + 1)}Empty");
    }
}