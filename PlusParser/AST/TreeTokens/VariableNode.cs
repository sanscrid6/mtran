namespace PlusParser.AST.TreeTokens;

public enum Type
{
    Int,
    Float,
    String,
    Char,
    Void,
    IntArr,
}

public class VariableNode: BaseNode
{
    public readonly string Name;
    
    public VariableNode(string name)
    {
        Name = name;
    }
}