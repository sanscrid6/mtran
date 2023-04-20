using System.Security;

namespace PlusParser.Tokens.Tokens;

public class VariableToken: TokenBase
{
    public VariableToken(string val, int start, int end, int lineNumber) : base(val, start, end, lineNumber)
    {
    }

    public override bool IsValid(List<TokenBase> nextTokens)
    {
        if (nextTokens[0] is SpaceToken && nextTokens[1] is VariableToken)
        {
            BuildError($"typo in {value}", start, lineNumber);
        }

        return true;
    }
}