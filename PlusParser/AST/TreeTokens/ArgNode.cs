using System.Security.Cryptography;

namespace PlusParser.AST.TreeTokens;

public class ArgNode: BaseNode
{
    public readonly Type Type;
    public readonly string Name;

    public ArgNode(string name, Type type)
    {
        Name = name;
        Type = type;
    }
}