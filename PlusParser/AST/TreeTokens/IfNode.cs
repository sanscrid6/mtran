namespace PlusParser.AST.TreeTokens;

public class IfNode: BaseNode
{
    public BaseNode cond;
    public BaseNode body;
}