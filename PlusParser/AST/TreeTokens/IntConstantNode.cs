namespace PlusParser.AST.TreeTokens;

public class IntConstantNode: BaseNode
{
    public readonly int Value;

    public IntConstantNode(int v)
    {
        Value = v;
    }
}