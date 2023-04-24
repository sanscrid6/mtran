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
}