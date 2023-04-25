using System.Reflection;

namespace PlusParser.AST.TreeTokens;

public class FunctionDefinitionNode: BaseNode
{
    public readonly string Name;
    public readonly List<ArgNode> Args;
    public readonly Type ReturnType;
    public readonly BodyNode Body;

    public FunctionDefinitionNode(string name, List<ArgNode> args, Type returnType, BodyNode body)
    {
        Body = body;
        Name = name;
        Args = args;
        ReturnType = returnType;
    }

    public override string Dump(int level, bool isNode = true)
    {
        return
            $"function:\n" +
            DrawNode(level + 1) + $"declaration: {ReturnType.ToString().ToLower()} {Name}\n" +
            DrawLevel(level + 1) + "args:\n" +
            (Args.Count > 0 ? $"{Args.DumpList(level + 2)}": $"{DrawNode(level + 2)}Empty") + "\n" +
            DrawLevel(level + 1) +"body:\n" +
            Body.Dump(level + 2);
    }
}