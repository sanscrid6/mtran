namespace PlusParser.AST.TreeTokens;

public class AssignNode: BaseNode
{
    public readonly string VariableName;
    public readonly BaseNode Value;

    public AssignNode(string name, BaseNode val)
    {
        VariableName = name;
        Value = val;
    }

    public override void Analyze()
    {
        Value.Analyze();
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + VariableName + "\n" + Value.Dump(level + 1);
    }

    public override object? Execute()
    {
        Tables.ChangeValue(VariableName, Value.Execute());
        return null;
    }
}