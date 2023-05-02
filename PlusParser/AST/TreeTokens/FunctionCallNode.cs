namespace PlusParser.AST.TreeTokens;

public class FunctionCallNode: BaseNode
{
    public readonly VariableNode Name;
    public readonly List<BaseNode> Args;

    public FunctionCallNode(VariableNode name, List<BaseNode> args)
    {
        Name = name;
        Args = args;
    }

    public override void Analyze()
    {
        Args.ForEach(arg => arg.Analyze());
    }

    public override object? Execute()
    {
        var args = Args.Select(arg => arg.Execute()).ToList();
        //args.Print();
        //Console.WriteLine(args.Count);
        Tables.ExecuteFunction(Name.Name, args);
        return null;
    }


    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "funccall:\n" +
               DrawLevel(level + 1) + "name:\n" +
               Name.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "args:\n" +
               Args.DumpList(level + 2);
    }
}