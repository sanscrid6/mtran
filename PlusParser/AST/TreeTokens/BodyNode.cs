namespace PlusParser.AST.TreeTokens;

public class BodyNode: BaseNode
{
    public readonly List<BaseNode> Lines;

    public BodyNode(List<BaseNode> lines)
    {
        Lines = lines;
    }
}