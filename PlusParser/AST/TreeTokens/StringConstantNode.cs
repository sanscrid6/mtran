namespace PlusParser.AST.TreeTokens;

public class StringConstantNode: BaseNode
{
    public readonly string Value;

    public StringConstantNode(string v)
    {
        Value = v;
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (isNode)
        {
            return DrawNode(level) + @$"""{Value}""";
        }
        
        return DrawLevel(level) + @$"""{Value}""";
    }
}