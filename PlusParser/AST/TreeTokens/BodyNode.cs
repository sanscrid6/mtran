using System.IO.Pipes;

namespace PlusParser.AST.TreeTokens;

public class ReturnEx : Exception
{
    public object? Value;
}

public class BodyNode: BaseNode
{
    public readonly List<BaseNode> Lines;

    public BodyNode(List<BaseNode> lines)
    {
        Lines = lines;
    }

    public override void Analyze()
    {
        Lines.ForEach(l => l.Analyze());
    }

    public override object? Execute()
    {
        for (int i = 0; i < Lines.Count; i++)
        {
            if (Lines[i] is ReturnNode)
            {
                var ex = new ReturnEx();
                ex.Value = Lines[i].Execute();
                throw ex;
            }

            Lines[i].Execute();
        }

        return null;
    }

    public override string Dump(int level, bool isNode = false)
    {
        var result = "";
        for (int i = 0; i < Lines.Count; i++)
        {
            var q = i;
            result += $"{Lines[i].Dump(level, i == 0)}{Extensions.If(() => q != Lines.Count - 1, "\n", "")}";
        }
        //var body = Lines.DumpList(level + 1);
        return result;
    }
}