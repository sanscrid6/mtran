namespace PlusParser;

public class Arg
{
    public string type;
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
}