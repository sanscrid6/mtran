namespace PlusParser.AST.TreeTokens;

public class ForNode: BaseNode
{
    public readonly BaseNode Assign;
    public readonly ExpressionNode Condition;
    public readonly UnaryOperationNode Increment;

    public readonly BodyNode Body;

    public ForNode(BaseNode assign, ExpressionNode condition, UnaryOperationNode increment, BodyNode body)
    {
        Assign = assign;
        Condition = condition;
        Increment = increment;
        Body = body;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "for:\n" +
               DrawLevel(level + 1) + "decl:\n" + 
               Assign.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "cond:\n" + 
               Condition.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "inc:\n" +
               Increment.Dump(level + 2, true) + "\n" + 
               DrawLevel(level + 1) + "body:\n" +
               Body.Dump(level + 2, true);
    }
}