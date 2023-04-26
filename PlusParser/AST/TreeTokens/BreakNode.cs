namespace PlusParser.AST.TreeTokens;

public class BreakNode: BaseNode
{
    public override string Dump(int level, bool isNode = false)
    {
        return DrawLevel(level) + "break";
    }
}