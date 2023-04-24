using System.Reflection;

namespace PlusParser.AST.TreeTokens;

public class FunctionDefinitionNode: BaseNode
{
    public readonly string Name;
    public readonly List<ArgNode> Args;
    public readonly Type ReturnType;
    public readonly BaseNode Body;

    public FunctionDefinitionNode(string name, List<ArgNode> args, Type returnType, BaseNode body)
    {
        Body = body;
        Name = name;
        Args = args;
        ReturnType = returnType;
    }
}