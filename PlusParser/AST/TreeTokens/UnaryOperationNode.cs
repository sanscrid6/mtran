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
        //return DrawLevel(level) + $"{EnumToSymbol[Operation]}\n" + Value.Dump(level + 1);
        
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "operation:\n" + 
               DrawNode(level + 1) + $"{EnumToSymbol[Operation]}\n" + 
               DrawLevel(level + 1) + "values:" + "\n" +
               Value.Dump(level + 2, true);
    }
}