namespace PlusParser.Tokens.Tokens;

public class VoidToken: TokenBase, IKeyword
{
    public VoidToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {   
        var isFunction = (nextTokens[1] is VariableToken && nextTokens[2] is OpenParamsToken);

        if (isFunction)
        {
            Lexer.variables.Add(nextTokens[1].value, "function");
        }
    }
}