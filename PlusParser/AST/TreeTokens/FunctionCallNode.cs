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
        //args.Print();
        //Console.WriteLine(args.Count);
        if (Name.Name == "swap")
        {
            var left = Args[0];
            var right = Args[1];

            var indexLeft = (int)(left as BinaryOperationNode).Right.Execute();
            var indexRight =  (int)(right as BinaryOperationNode).Right.Execute();
            
            void Swap<T>(T[] array, int index1, int index2)
            {
                T temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
            
            Swap(Tables.GetValue("arr") as int[], indexLeft, indexRight);
        }
        else
        {
            var args = Args.Select(arg => arg.Execute()).ToList();

            return Tables.ExecuteFunction(Name.Name, args);
        }

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