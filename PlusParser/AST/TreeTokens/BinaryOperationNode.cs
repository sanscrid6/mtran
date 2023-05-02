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
                var arg = Tables.variablesSemantic[variableNode.Name];
                if (!Tables.variablesSemantic[(Left as VariableNode).Name].isArr)
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
                var type = Tables.variablesSemantic[variableNode.Name];
                if (!type.isArr && type.type is not Type.Int and not Type.Float)
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

    public override object? Execute()
    {
        dynamic left = Left.Execute();
        dynamic right = Right.Execute();
        
        
        /*Console.WriteLine(Operation);
        if(left is not null)
        Console.WriteLine(left);
        if(right is not null)
        Console.WriteLine(right);*/

        if (left is float)
            left = (float) left;
        
        if (left is char)
            left = (char) left;

        if (left is int)
            left = (int) left;
        
        if (right is float)
            right = (float) right;
        
        if (right is int)
            right = (int) right;

        if (left is Array)
            left = (Array) left;
        
        if (right is char)
            right = (char) right;
        

        switch (Operation)
        {
            case BinaryOperation.Plus:
            {
                return left + right;
            }
            case BinaryOperation.Minus:
            {
                return left - right;
            }
            case BinaryOperation.Div:
            {
                return left / right;
            }
            case BinaryOperation.Mul:
            {
                return left * right;
            }
            case BinaryOperation.Gt:
            {
                return left > right;
            }
            case BinaryOperation.Gte:
            {
                return left >= right;
            }
            case BinaryOperation.Lt:
            {
                return left < right;
            }
            case BinaryOperation.Lte:
            {
                return left <= right;
            }
            case BinaryOperation.And:
            {
                return left && right;
            }
            case BinaryOperation.Or:
            {
                return left || right;
            }
            case BinaryOperation.Eq:
            {
                return left == right;
            }
            case BinaryOperation.ArrVal:
            {
                return left[right];
            }
        }
        
        return null;
    }
}