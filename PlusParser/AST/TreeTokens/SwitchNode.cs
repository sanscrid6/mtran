namespace PlusParser.AST.TreeTokens;

public class SwitchNode: BaseNode
{
    public readonly VariableNode SwitchValue;
    public readonly List<CaseNode> Cases;

    public SwitchNode(VariableNode switchValue, List<CaseNode> cases)
    {
        SwitchValue = switchValue;
        Cases = cases;
    }

    public override void Analyze()
    {
        Cases.ForEach(c => c.Analyze());
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "switch:\n" +
               DrawLevel(level + 1) + "name:\n" +
               SwitchValue.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "cases:\n" +
               Cases.DumpList(level + 2);
    }
}