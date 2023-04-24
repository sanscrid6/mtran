namespace PlusParser.AST.TreeTokens;

public class CaseNode: BaseNode
{
    public readonly BaseNode Literal;
    public readonly BodyNode Body;

    public CaseNode(BaseNode literal, BodyNode body)
    {
        Literal = literal;
        Body = body;
    }
}