namespace PlusParser.AST.TreeTokens;

public class FloatConstantNode: BaseNode
{
    public readonly float Value;

    public FloatConstantNode(float v)
    {
        Value = v;
    }
}