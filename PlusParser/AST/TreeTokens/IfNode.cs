namespace PlusParser.AST.TreeTokens;

public class IfNode: BaseNode
{
    public readonly BaseNode Cond;
    public readonly BaseNode Body;

    public IfNode(BaseNode cond, BaseNode body)
    {
        Cond = cond;
        Body = body;
    }
}