namespace PlusParser.AST.TreeTokens;

public class CoutNode: BaseNode
{
    public readonly List<BaseNode> Out;

    public CoutNode(List<BaseNode> nodes)
    {
        Out = nodes;
    }
}