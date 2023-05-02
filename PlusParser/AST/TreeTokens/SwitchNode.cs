namespace PlusParser.AST.TreeTokens;

public class SwitchNode: BaseNode
{
    public readonly VariableNode SwitchValue;
    public readonly List<CaseNode> Cases;

    public SwitchNode(VariableNode switchValue, List<CaseNode> cases)
    {
        SwitchValue = switchValue;
        Cases = cases;
    }

    public override void Analyze()
    {
        Cases.ForEach(c => c.Analyze());
    }

    public override object? Execute()
    {
        dynamic val = Tables.GetValue(SwitchValue.Name);

        for (int i = 0; i < Cases.Count; i++)
        {
            if (Cases[i].Literal is FloatConstantNode fc)
            {
                if (fc.Value == val)
                {
                    Cases[i].Execute();
                    if (Cases[i].Body.Lines.Find(l => l is BreakNode) != null)
                    {
                        return null;
                    }
                }
            }
            else if (Cases[i].Literal is CharConstantNode cc)
            {
                if (cc.Value == val)
                {
                    Cases[i].Execute();
                    if (Cases[i].Body.Lines.Find(l => l is BreakNode) != null)
                    {
                        return null;
                    }
                }
            }
            else if (Cases[i].Literal is IntConstantNode ic)
            {
                if (ic.Value == val)
                {
                    Cases[i].Execute();
                    if (Cases[i].Body.Lines.Find(l => l is BreakNode) != null)
                    {
                        return null;
                    }
                }
            }
        }

        return null;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "switch:\n" +
               DrawLevel(level + 1) + "name:\n" +
               SwitchValue.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "cases:\n" +
               Cases.DumpList(level + 2);
    }
}