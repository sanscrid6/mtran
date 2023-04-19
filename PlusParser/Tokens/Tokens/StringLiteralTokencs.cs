using PlusParser.Tokens.LexickTokens;

namespace PlusParser.Tokens.Tokens;

public class StringLiteralToken: TokenBase, ILiteral
{
    public StringLiteralToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }
    
    public override void FillTable(List<TokenBase> nextTokens)
    {
        Lexer.constants.Add(this.value);
    }
}