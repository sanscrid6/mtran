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
    public static Dictionary<BinaryOperation, string> EnumToSymbol = new()
    {
        {BinaryOperation.And, "&&"},
        {BinaryOperation.Div, "/"},
        {BinaryOperation.Eq, "=="},
        {BinaryOperation.Gt, ">"},
        {BinaryOperation.Gte, ">="},
        {BinaryOperation.Lt, "<"},
        {BinaryOperation.Lte, "<="},
        {BinaryOperation.Minus, "-"},
        {BinaryOperation.Plus, "+"},
        {BinaryOperation.Mul, "*"},
        {BinaryOperation.ArrVal, "[]"},
        {BinaryOperation.Or, "||"}
    };
    
    public readonly BaseNode Left;
    public readonly BaseNode Right;
    public readonly BinaryOperation Operation;

    public BinaryOperationNode(BaseNode leftNode, BaseNode rightNode, BinaryOperation op)
    {
        Left = leftNode;
        Right = rightNode;
        Operation = op;
    }

    public override string Dump(int level, bool isNode = false)
    {
        //return DrawLevel(level) + $"{EnumToSymbol[Operation]}\n" + Left.Dump(level + 1) + "\n" + Right.Dump(level + 1);

        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "operation:\n" +
               DrawNode(level + 1) + $"{EnumToSymbol[Operation]}\n" +
               DrawLevel(level + 1) + "values:\n" +
               Left.Dump(level+2, true) + "\n" +
               Right.Dump(level+2);
    }
}