namespace PlusParser.AST.TreeTokens;

public class FunctionCallNode: BaseNode
{
    public ExpressionNode name;
    public ExpressionNode args;
}