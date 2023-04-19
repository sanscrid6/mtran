namespace PlusParser.Tokens.Tokens;

public class CoutToken: TokenBase
{
    public CoutToken(string val, int start, int end, int lineNumber) : base(val, start, end,  lineNumber)
    {
    }

    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var lineEndIndex = nextTokens.FindIndex(t => t is EOLToken);
        var line = nextTokens.Skip(0).Take(lineEndIndex + 1).ToList();

        var boolOperator = line.Find(t => t is BoolOperatorToken);
        
        if (boolOperator != null)
        {
            BuildError($"typo in << operator", boolOperator.start, boolOperator.lineNumber);
        }

        return true;
    }
}