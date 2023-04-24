namespace PlusParser.AST.TreeTokens;

public class StringConstantNode: BaseNode
{
    public readonly string Value;

    public StringConstantNode(string v)
    {
        Value = v;
    }
}