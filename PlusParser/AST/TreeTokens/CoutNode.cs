namespace PlusParser.AST.TreeTokens;

public class CoutNode: BaseNode
{
    public readonly List<BaseNode> Out;

    public CoutNode(List<BaseNode> nodes)
    {
        Out = nodes;
    }

    public override void Analyze()
    {
        Out.ForEach(o => o.Analyze());
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "cout:\n" + Out.DumpList(level + 1);
    }
}