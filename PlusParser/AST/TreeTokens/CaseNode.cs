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

    public override void Analyze()
    {
        /*var breakNode = Body.Lines.Find(l => l is BreakNode);
        if (breakNode == null)
        {
            throw new Exception("expected break statement in case");
        }*/
        Tables.AddScope("case");
        Body.Analyze();
        Tables.RemoveScope();
    }

    public override object? Execute()
    {
        Tables.AddScope("case");
        Body.Execute();
        Tables.RemoveScope();
        return null;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "case:\n" +
               DrawLevel(level + 1) + "constant:\n" +
               Literal.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "body:\n" +
               Body.Dump(level + 2, true);
    }
}