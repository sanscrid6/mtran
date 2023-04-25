namespace PlusParser.AST.TreeTokens;

public class VariableDeclarationNode: BaseNode
{
    public readonly Type Type;
    public readonly string Name;
    public readonly BaseNode? Value;
    public readonly bool IsArray;
    
    public VariableDeclarationNode(string name, Type type, BaseNode expr, bool isArray)
    {
        Type = type;
        Name = name;
        Value = expr;
        IsArray = isArray;
    }
    
    public VariableDeclarationNode(string name, Type type, BaseNode expr)
    {
        Type = type;
        Name = name;
        Value = expr;
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (IsArray)
        {
            return $"{(!isNode ? DrawLevel(level) : DrawNode(level))}{Type.ToString().ToLower()} {Name}[]\n" +
                   DrawNode(level + 1) + "value:\n" + 
                   Extensions.If(() => Value != null, Value?.Dump(level + 2), $"{DrawNode(level+2)}Empty");
        }

        return $"{(!isNode ? DrawLevel(level) : DrawNode(level))}{Type.ToString().ToLower()} {Name}\n" +
               DrawNode(level + 1) + "value:\n" + 
               Extensions.If(() => Value != null, Value?.Dump(level + 2), $"{DrawNode(level+2)}Empty");
    }
}