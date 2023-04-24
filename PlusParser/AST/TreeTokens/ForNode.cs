namespace PlusParser.AST.TreeTokens;

public class ForNode: BaseNode
{
    public readonly BaseNode Assign;
    public readonly ExpressionNode Condition;
    public readonly UnaryOperationNode Increment;

    public readonly BaseNode Body;

    public ForNode(BaseNode assign, ExpressionNode condition, UnaryOperationNode increment, BaseNode body)
    {
        Assign = assign;
        Condition = condition;
        Increment = increment;
        Body = body;
    }
}