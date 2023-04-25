namespace PlusParser.AST.TreeTokens;

public class CinNode: BaseNode
{
    public readonly VariableNode Value;

    public CinNode(VariableNode value)
    {
        Value = value;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "cin:\n" + 
               DrawLevel(level + 1) + "value:\n" + 
               Value.Dump(level + 2, true);
    }
}