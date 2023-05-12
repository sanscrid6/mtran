namespace PlusParser.AST.TreeTokens;

public class GotoNode: BaseNode
{
    public readonly VariableNode Value;

    public GotoNode(VariableNode value)
    {
        Value = value;
    }

    public override void Analyze()
    {
        if (Tables.Run > 0)
        {
            var q = Tables.gotos.Find(g => g == Value.Name);
            if (q == null)
            {
                throw new Exception($"cant find goto {Value.Name}");
            }
        }
    }
}