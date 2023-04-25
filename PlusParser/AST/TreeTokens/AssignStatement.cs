namespace PlusParser.AST.TreeTokens;

public class AssignStatement: BaseNode
{
    public readonly string VariableName;
    public readonly BaseNode Value;

    public AssignStatement(string name, BaseNode val)
    {
        VariableName = name;
        Value = val;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + VariableName + "\n" + Value.Dump(level + 1);
    }
}