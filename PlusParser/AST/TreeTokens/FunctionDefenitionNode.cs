using System.Reflection;
using PlusParser.Tokens.Tokens;

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

    public override void Analyze()
    {
        Args.ForEach(arg => arg.Analyze());
        var returnNode = Body.Lines.Find(l => l is ReturnNode) as ReturnNode;
        if (ReturnType == Type.Int)
        {
            if (returnNode == null)
            {
                throw new Exception("expected return statement in function body");
            }
            
            if (returnNode.Value == null)
            {
                throw new Exception("expected value in return statement");
            }

            if (returnNode.Value is LiteralNode)
            {
                if (returnNode.Value is not IntConstantNode)
                {
                    throw new Exception("expected integer return type");
                }
            }
        }
        else if (ReturnType == Type.Void)
        {
            if (returnNode is {Value: { }})
            {
                throw new Exception("not expected value in return statement");
            }
        }

        if (Body.Lines.Find(l => l is BreakNode) != null)
        {
            throw new Exception("not expected break statement in this context");
        }
        
        Body.Analyze();
    }

    public override object? Execute()
    {
        Tables.AddScope(Name);
        Body.Execute();
        Tables.RemoveScope();
        return null;
    }

    public object? Execute(List<object> args)
    {
        Tables.AddScope(Name);

        for (int i = 0; i < args.Count; i++)
        {
            Tables.AddVariable(Args[i].Name, args[i], new Arg()
            {
                name = Args[i].Name,
                isArr = Args[i].IsArray,
                type = Args[i].Type
            });

        }
        var res = Body.Execute();
        Tables.RemoveScope();
        return res;
    }

    public override string Dump(int level, bool isNode = true)
    {
        return
            $"function:\n" +
            DrawLevel(level + 1) + $"name: {Name}\n" +
            DrawLevel(level + 1) + $"return type: {ReturnType.ToString().ToLower()}\n" +
            DrawLevel(level + 1) + "args:\n" +
            (Args.Count > 0 ? $"{Args.DumpList(level + 2)}": $"{DrawNode(level + 2)}Empty") + "\n" +
            DrawLevel(level + 1) +"body:\n" +
            Body.Dump(level + 2);
    }
}