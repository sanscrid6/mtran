using System.IO.Pipes;

namespace PlusParser.AST.TreeTokens;

public class BodyNode: BaseNode
{
    public readonly List<BaseNode> Lines;

    public BodyNode(List<BaseNode> lines)
    {
        Lines = lines;
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