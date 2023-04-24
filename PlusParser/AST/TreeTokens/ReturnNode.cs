namespace PlusParser.AST.TreeTokens;

public class ReturnNode: BaseNode
{
    public readonly ExpressionNode? Value;

    public ReturnNode(ExpressionNode? value)
    {
        Value = value;
    }
}