namespace PlusParser.AST.TreeTokens;

public class GotoMarkNode: BaseNode
{
    public readonly VariableNode Value;

    public GotoMarkNode(VariableNode value)
    {
        Value = value;
    }

    public override void Analyze()
    {
        if (Tables.Run == 0)
        {
            Tables.gotos.Add(Value.Name);
        }
    }
}