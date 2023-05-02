using System.Security.Cryptography;

namespace PlusParser.AST.TreeTokens;

public class ArgNode: BaseNode
{
    public readonly Type Type;
    public readonly string Name;
    public readonly bool IsArray;

    public ArgNode(Type type, string name, bool isArray)
    {
        Type = type;
        Name = name;
        IsArray = isArray;
    }

    public override void Analyze()
    {
        if (Tables.variablesSemantic.ContainsKey(Name))
        {
            Tables.variablesSemantic.Remove(Name);
        }
        
        Tables.variablesSemantic.Add(Name, new Arg
        {
            name = Name,
            isArr = IsArray,
            type = Type
        });
    }

    public override string Dump(int level, bool isNode = true)
    {
        var prefix = isNode ? DrawNode(level) : DrawLevel(level);
        var value = $"{prefix}{Type.ToString().ToLower()} {Name}";
        
        if (IsArray)
        {
            value += "[]";
        }

        return value;
    }
}