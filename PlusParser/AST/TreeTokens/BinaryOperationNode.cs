namespace PlusParser.AST.TreeTokens;

public enum BinaryOperation
{
    Plus,
    Minus,
    Mul,
    Div,
    Gt,
    Gte,
    Lt,
    Lte,
    Eq,
    ArrVal,
    And,
    Or,
}

public class BinaryOperationNode: ExpressionNode
{
    public readonly BaseNode Left;
    public readonly BaseNode Right;
    public readonly BinaryOperation Operation;

    public BinaryOperationNode(BaseNode leftNode, BaseNode rightNode, BinaryOperation op)
    {
        Left = leftNode;
        Right = rightNode;
        Operation = op;
    }
}