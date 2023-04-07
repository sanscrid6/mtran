namespace PlusParser.Tokens.Tokens;

public class CinToken: TokenBase
{
    public CinToken(string val, int start, int end) : base(val, start, end)
    {
    }
    
    public override bool IsValid(List<TokenBase> nextTokens)
    {
        var lineEndIndex = nextTokens.FindIndex(t => t is EOLToken);
        var line = nextTokens.Skip(0).Take(lineEndIndex + 1).ToList();
        
        if (line.Find(t => t is BoolOperatorToken) != null)
        {
            throw new Exception($"typo in >> operator");
        }

        return true;
    }
}