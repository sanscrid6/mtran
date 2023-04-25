namespace PlusParser.AST.TreeTokens;

public class ArrInitNode<T>: BaseNode where T: BaseNode
{
    public readonly List<T> Init;

    public ArrInitNode(List<T> init)
    {
        Init = init;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + $"[{String.Join(", ", Init.Select(item => item.ToString()))}]";
    }
}