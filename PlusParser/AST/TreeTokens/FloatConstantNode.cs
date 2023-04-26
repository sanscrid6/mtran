namespace PlusParser.AST.TreeTokens;

public class FloatConstantNode: LiteralNode
{
    public readonly float Value;

    public FloatConstantNode(float v)
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
}