namespace PlusParser.AST.TreeTokens;

public class IfNode: BaseNode
{
    public readonly BaseNode Cond;
    public readonly BaseNode Body;
    public readonly BaseNode? Else;

    public IfNode(BaseNode cond, BaseNode body, BaseNode? elseNode)
    {
        Cond = cond;
        Body = body;
        Else = elseNode;
    }

    public override object? Execute()
    {
        Tables.AddScope("if");
        if ((bool) Cond.Execute())
        {
            try
            {
                Body.Execute();
            }
            catch (ReturnEx e)
            {
                Tables.RemoveScope();
                throw;
            }

        }
        else
        {
            try
            {
                Else?.Execute();
            }
            catch (ReturnEx e)
            {
                Tables.RemoveScope();
                throw;
            }
        }
        Tables.RemoveScope();
        
        return null;
    }

    public override void Analyze()
    {
        Cond.Analyze();
        Tables.AddScope("if");
        Body.Analyze();
        Tables.RemoveScope();
        Tables.AddScope("else");
        Else?.Analyze();
        Tables.RemoveScope();
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "if:\n" +
               DrawLevel(level + 1) + "cond:\n" +
               Cond.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "body:\n" +
               Body.Dump(level + 2, true);
    }
}