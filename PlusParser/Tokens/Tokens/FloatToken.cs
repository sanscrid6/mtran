namespace PlusParser.Tokens.Tokens;

public class FloatToken: TokenBase, IKeyword
{
    public FloatToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
    
    public override void FillTable(List<TokenBase> nextTokens)
    {
        var isFunction = (nextTokens[1] is VariableToken && nextTokens[2] is OpenParamsToken);
        var isVariableDeclaration = (nextTokens[3] is AssignToken);

        if (isVariableDeclaration)
        {
            if (Lexer.variables.ContainsKey(nextTokens[1].value))
                BuildError($"variable ${nextTokens[1].value} already declared");
            
            Lexer.variables.Add(nextTokens[1].value, "float");
        }
    }
}