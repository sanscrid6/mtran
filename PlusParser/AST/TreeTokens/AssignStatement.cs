namespace PlusParser.AST.TreeTokens;

public class AssignStatement: StatementNode
{
    public readonly string VariableName;
    public readonly ExpressionNode Value;

    public AssignStatement(string name, ExpressionNode val)
    {
        VariableName = name;
        Value = val;
    }

}