namespace PlusParser.Tokens.Tokens;

public class CharLiteralToken: TokenBase, ILiteral
{
    public CharLiteralToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }

    public override void FillTable(List<TokenBase> nextTokens)
    {
        Lexer.constants.Add(this.value);
    }
}