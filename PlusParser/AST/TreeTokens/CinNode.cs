namespace PlusParser.AST.TreeTokens;

public class CinNode: BaseNode
{
    public readonly VariableNode Value;

    public CinNode(VariableNode value)
    {
        Value = value;
    }
}