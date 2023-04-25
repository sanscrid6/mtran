namespace PlusParser.AST.TreeTokens;

public enum Type
{
    Int,
    Float,
    String,
    Char,
    Void,
}

public class VariableNode: BaseNode
{
    public readonly string Name;
    
    public VariableNode(string name)
    {
        Name = name;
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (isNode)
        {
            return DrawNode(level) + Name;
        }

        return DrawLevel(level) + Name; 
    }
}