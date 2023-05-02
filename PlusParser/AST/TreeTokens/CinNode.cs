namespace PlusParser.AST.TreeTokens;

public class CinNode: BaseNode
{
    public readonly VariableNode Value;

    public CinNode(VariableNode value)
    {
        Value = value;
    }

    public override void Analyze()
    {
        Value.Analyze();
    }

    public override object? Execute()
    {
        var input = Console.ReadLine();
        var meta = Tables.GetMetadata(Value.Name);
        switch (meta.type)
        {
            case Type.Char:
            {
                Tables.ChangeValue(Value.Name, input[0]);
                break;
            }
            case Type.Float:
            {
                Tables.ChangeValue(Value.Name, float.Parse(input));
                break;
            }
            case Type.Int:
            {
                Tables.ChangeValue(Value.Name, int.Parse(input));
                break;
            }
        }

        return null;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "cin:\n" + 
               DrawLevel(level + 1) + "value:\n" + 
               Value.Dump(level + 2, true);
    }
}