namespace PlusParser.AST.TreeTokens;

public class ForNode: BaseNode
{
    public BaseNode first;
    public BaseNode second;
    public BaseNode third;

    public BaseNode body;
}