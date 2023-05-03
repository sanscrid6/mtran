namespace PlusParser.AST.TreeTokens;

public class MultipleVariableDeclarationNode: BaseNode
{
    public readonly Type Type;
    public readonly List<AssignNode> Nodes;


    public MultipleVariableDeclarationNode(Type type, List<AssignNode> nodes)
    {
        Type = type;
        Nodes = nodes;
    }

    public override void Analyze()
    {
        foreach (var n in Nodes)
        {
            if (Tables.variablesSemantic.ContainsKey(n.VariableName))
            {
                Tables.variablesSemantic.Remove(n.VariableName);
            }
        
            Tables.variablesSemantic.Add(n.VariableName, new Arg
            {
                name = n.VariableName,
                type = Type,
                isArr = false
            });
        }
    }

    public override object? Execute()
    {
        foreach (var n in Nodes)
        {
            Tables.AddVariable(n.VariableName, n.Value.Execute(), new Arg
            {
                isArr = false,
                name = n.VariableName,
                type = Type
            });
        }

        return null;
    }
}