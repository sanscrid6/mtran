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

    public override void Analyze()
    {
        if (Operation == BinaryOperation.ArrVal)
        {
            if (Right is LiteralNode and not IntConstantNode)
            {
                throw new Exception("expected int value in [] operator");
            }

            if (Right is VariableNode variableNode)
            {
                var arg = Tables.variables[variableNode.Name];
                if (!Tables.variables[(Left as VariableNode).Name].isArr)
                {
                    throw new Exception("expected array in [] operation");
                }

                if (arg.type != Type.Int)
                {
                    throw new Exception("expected int variable in [] operator");
                }
            }
        }

        if (Operation is BinaryOperation.Minus or BinaryOperation.Plus or BinaryOperation.Div or BinaryOperation.Mul)
        {
            if (Left is LiteralNode and not IntConstantNode and not FloatConstantNode)
            {
                throw new Exception("expected int constant in arifmetic expression");
            }

            if (Left is VariableNode variableNode)
            {
                var type = Tables.variables[variableNode.Name];
                if (!type.isArr && type.type is not Type.Int or Type.Float)
                {
                    throw new Exception("expected int or float variable in arifmetic expression");
                }
            }
        }
        
        Left.Analyze();
        Right.Analyze();
    }

    public BinaryOperationNode(BaseNode leftNode, BaseNode rightNode, BinaryOperation op)
    {
        Left = leftNode;
        Right = rightNode;
        Operation = op;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "operation:\n" +
               DrawNode(level + 1) + $"{EnumToSymbol[Operation]}\n" +
               DrawLevel(level + 1) + "values:\n" +
               Left.Dump(level+2, true) + "\n" +
               Right.Dump(level+2);
    }
}