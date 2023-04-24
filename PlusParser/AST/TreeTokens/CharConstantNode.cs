namespace PlusParser.AST.TreeTokens;

public class CharConstantNode: BaseNode
{
    public readonly char Value;

    public CharConstantNode(char v)
    {
        Value = v;
    }
}