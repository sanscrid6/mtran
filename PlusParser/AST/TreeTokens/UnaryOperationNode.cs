namespace PlusParser.AST.TreeTokens;

public enum UnaryOperation
{
    Inc,
    Dec,
}

public class UnaryOperationNode: BaseNode
{
    public static readonly Dictionary<UnaryOperation, string> EnumToSymbol = new()
    {
        {UnaryOperation.Dec, "--"},
        {UnaryOperation.Inc, "++"}
    };
    
    public readonly BaseNode Value;
    public readonly UnaryOperation Operation;

    public UnaryOperationNode(BaseNode node, UnaryOperation op)
    {
        Value = node;
        Operation = op;
    }

    public override void Analyze()
    {
        if (Value is LiteralNode and not FloatConstantNode and not IntConstantNode)
        {
            throw new Exception("unary operator can be apply only to int ot float");
        }
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "operation:\n" + 
               DrawNode(level + 1) + $"{EnumToSymbol[Operation]}\n" + 
               DrawLevel(level + 1) + "values:" + "\n" +
               Value.Dump(level + 2, true);
    }

    public override object? Execute()
    {
        var name = (Value as VariableNode).Name;
        dynamic val = Tables.GetValue(name);

        if (val is float)
            val = (float) val;

        if (val is int)
            val = (int) val;

        switch (Operation)
        {
            case UnaryOperation.Dec:
            {
                Tables.ChangeValue(name, val - 1);
                break;
            }
            case UnaryOperation.Inc:
            {
                Tables.ChangeValue(name, val + 1);
                break;
            }
        }

        return val;
    }
}