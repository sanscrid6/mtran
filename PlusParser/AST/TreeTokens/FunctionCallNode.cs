namespace PlusParser.AST.TreeTokens;

public class FunctionCallNode: BaseNode
{
    public readonly VariableNode Name;
    public readonly List<BaseNode> Args;

    public FunctionCallNode(VariableNode name, List<BaseNode> args)
    {
        Name = name;
        Args = args;
    }
}