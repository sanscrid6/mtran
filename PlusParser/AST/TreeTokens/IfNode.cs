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
        Tables.RemoveScope();
        
        return null;
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