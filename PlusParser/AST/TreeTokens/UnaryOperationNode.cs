namespace PlusParser.AST.TreeTokens;

public enum UnaryOperation
{
    Inc,
    Dec,
}

public class UnaryOperationNode: BaseNode
{
    public readonly BaseNode Value;
    public readonly UnaryOperation Operation;

    public UnaryOperationNode(BaseNode node, UnaryOperation op)
    {
        Value = node;
        Operation = op;
    }
}