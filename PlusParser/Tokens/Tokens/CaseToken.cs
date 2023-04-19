namespace PlusParser.Tokens.Tokens;

public class CaseToken: TokenBase, IKeyword
{
    public CaseToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }
}