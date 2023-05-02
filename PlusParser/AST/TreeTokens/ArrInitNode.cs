namespace PlusParser.AST.TreeTokens;

public class ArrInitNode<T>: BaseNode where T: BaseNode
{
    public readonly List<T> Init;

    public ArrInitNode(List<T> init)
    {
        Init = init;
    }

    public override object? Execute()
    {
        dynamic result = null;
        
        if (Init is List<IntConstantNode> ints)
        {
            result = ints.Select(i => i.Value).ToArray();
        }
        else if (Init is List<CharConstantNode> chars)
        {
            result = chars.Select(i => i.Value).ToArray();
        }
        else if (Init is List<FloatConstantNode> floats)
        {
            result = floats.Select(i => i.Value).ToArray();
        }

        return result;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + $"[{String.Join(", ", Init.Select(item => item.ToString()))}]";
    }
}