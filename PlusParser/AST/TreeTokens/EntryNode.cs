namespace PlusParser.AST.TreeTokens;

public class EntryNode: BaseNode
{
    public readonly FunctionDefinitionNode Main;
    public readonly List<FunctionDefinitionNode> Functions;

    public EntryNode(FunctionDefinitionNode main, List<FunctionDefinitionNode> functions)
    {
        Main = main;
        Functions = functions;
    }

    public override string Dump(int tab, bool isNode = false)
    {
        return Functions.DumpList(0);
    }

    public override void Analyze()
    {
        Functions.ForEach(f => f.Analyze());
    }

    public override object? Execute()
    {
        Main.Execute();
        return null;
    }
}