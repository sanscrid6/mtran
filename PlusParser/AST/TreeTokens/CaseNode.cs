using PlusParser.Tokens.Tokens;

namespace PlusParser.AST.TreeTokens;

public class CaseNode: BaseNode
{
    public readonly BaseNode Literal;
    public readonly BodyNode Body;

    public CaseNode(BaseNode literal, BodyNode body)
    {
        Literal = literal;
        Body = body;
    }

    public override string Dump(int level, bool isNode = false)
    {
        return (!isNode ? DrawLevel(level) : DrawNode(level)) + "case:\n" +
               DrawLevel(level + 1) + "name:\n" +
               Literal.Dump(level + 2, true) + "\n" +
               DrawLevel(level + 1) + "body:\n" +
               Body.Dump(level + 2, true);
    }
}