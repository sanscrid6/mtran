namespace PlusParser.AST.TreeTokens;

public class VariableDeclarationNode: BaseNode
{
    public readonly Type Type;
    public readonly string Name;
    public readonly ExpressionNode Value;


    public VariableDeclarationNode(string name, Type type, ExpressionNode expr)
    {
        Type = type;
        Name = name;
        Value = expr;
    }
}