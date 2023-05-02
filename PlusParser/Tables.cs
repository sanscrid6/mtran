using PlusParser.AST.TreeTokens;
using Type = PlusParser.AST.TreeTokens.Type;

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

public class Scope
{
    public string name;
    public Dictionary<string, Tuple<object?, Arg>> variables = new();
}

public static class Tables
{
    public static List<FunctionDefinition> functions = new();
    public static Dictionary<string, Arg> variablesSemantic = new();
    
    //public static string Scope = "";

    public static EntryNode EntryNode;

    private static List<Scope> Scopes = new();
    // scope: [name: metadata]
    private static Dictionary<string, Dictionary<string, Tuple<object?, Arg>>> variables = new();

    public static void AddScope(string name)
    {
        Scopes.Add(new Scope
        {
            name = name
        });
    }

    public static object? ExecuteFunction(string name, List<object> args)
    {
        //Console.WriteLine(name);
        return EntryNode.Functions.Find(f => f.Name == name)?.Execute(args);
    }

    public static void RemoveScope()
    {
        Scopes.RemoveAt(Scopes.Count - 1);
    }
    
    public static void AddVariable(string name, object? val, Arg descriptor)
    {
        //PrintScopes();
        Scopes[^1].variables.Add(name, new Tuple<object?, Arg>(val, descriptor));
    }

    public static void ChangeValue(string name, object? val)
    {
        //Console.WriteLine(val);
        for (int i = Scopes.Count - 1; i >= 0; i--)
        {
            if (Scopes[i].variables.ContainsKey(name))
            {
                Scopes[i].variables[name] = new Tuple<object?, Arg>(val, Scopes[i].variables[name].Item2);
            }
        }
    }

    private static void PrintScopes()
    {
        Scopes.ForEach(s =>
        {
            foreach (var (key, (item1, item2)) in s.variables)
            {
                Console.WriteLine($"{s.name} - {key} - {item1}");
            }
        });
        Console.WriteLine("_____________________________________");
    }

    public static object? GetValue(string name)
    {
        //PrintScopes();
        
        for (int i = Scopes.Count - 1; i >= 0; i--)
        {
            if (Scopes[i].variables.ContainsKey(name))
            {
                //Console.WriteLine(Scopes[^1].variables[name].Item1);
                return Scopes[i].variables[name].Item1;
            }
        }

        return null;

        /*switch (variables[Scope][name].Item2.type)
        {
            case Type.Char:
            {
                return (char)variables[Scope][name].Item1;;
            }
            case Type.Float:
            {
                return (float)variables[Scope][name].Item1;
            }
            case Type.Int:
            {
                return (int)variables[Scope][name].Item1;
            }
            case Type.String:
            {
                return (string)variables[Scope][name].Item1;
            }
        }*/

        /*var replaceNames = new List<string>()
        {
            "for",
            "if",
            "while"
        };

        foreach (var nameReplace in replaceNames)
        {
            
        }

        for (int i = 0; i < variables.Keys.Count; i++)
        {
            if (Scope.StartsWith(Scope))
            {
                
            }
        }
        
        return variables[Scope][name].Item1;*/
    }

    public static Arg GetMetadata(string name)
    {
        for (int i = Scopes.Count - 1; i >= 0; i--)
        {
            if (Scopes[i].variables.ContainsKey(name))
            {
                return Scopes[i].variables[name].Item2;
            }
        }

        return null;
    }
}