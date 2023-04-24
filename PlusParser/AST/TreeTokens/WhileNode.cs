namespace PlusParser.AST.TreeTokens;

public class WhileNode: BaseNode
{
    public readonly BaseNode Cond;
    public readonly BaseNode Body;

    public WhileNode(BaseNode cond, BaseNode body)
    {
        this.Cond = cond;
        this.Body = body;
    }
}