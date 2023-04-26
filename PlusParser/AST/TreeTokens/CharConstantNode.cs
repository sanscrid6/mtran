namespace PlusParser.AST.TreeTokens;

public class CharConstantNode: LiteralNode
{
    public readonly char Value;

    public CharConstantNode(char v)
    {
        Value = v;
    }
    
    public override string Dump(int level, bool isNode = false)
    {
        if (isNode)
        {
            return DrawNode(level) + $"'{Value}'";
        }
        
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + $"'{Value}'";
    }
}