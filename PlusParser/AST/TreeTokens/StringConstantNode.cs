namespace PlusParser.AST.TreeTokens;

public class StringConstantNode: LiteralNode
{
    public readonly string Value;

    public StringConstantNode(string v)
    {
        Value = v.Replace("\\n", "\n");
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (isNode)
        {
            return DrawNode(level) + @$"""{Value}""";
        }
        
        return DrawLevel(level) + @$"""{Value}""";
    }

    public override string ToString()
    {
        return Value;
    }

    public override object? Execute()
    {
        return Value;
    }
}