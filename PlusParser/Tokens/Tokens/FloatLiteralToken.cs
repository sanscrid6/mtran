namespace PlusParser.Tokens.Tokens;

public class FloatLiteralToken: TokenBase, ILiteral
{
    public FloatLiteralToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
    
    public override void FillTable(List<TokenBase> nextTokens)
    {
        Lexer.constants.Add(this.value);
    }
}