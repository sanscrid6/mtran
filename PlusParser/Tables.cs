namespace PlusParser;

public class Arg
{
    public AST.TreeTokens.Type type;
    public bool isArr;
    public string name;
}

public class FunctionDefinition
{
    public string name;
    public List<Arg> args = new ();
}

public static class Tables
{
    public static List<FunctionDefinition> functions = new();
    public static Dictionary<string, Arg> variables = new();
}