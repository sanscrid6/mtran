namespace PlusParser.AST.TreeTokens;

public class IntConstantNode: BaseNode
{
    public readonly int Value;

    public IntConstantNode(int v)
    {
        Value = v;
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (isNode)
        {
            return DrawNode(level) + $"{Value}";
        }
        
        return DrawLevel(level) + $"{Value}";
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}