using System.Collections;
using System.Runtime.InteropServices;
using PlusParser.AST.TreeTokens;

namespace PlusParser;

public static class Extensions
{
    public static void Print(this IEnumerable collection)
    {
        foreach (var o in collection)
        {
            Console.WriteLine(o);            
        }
    }


    public static string DumpList<T>(this List<T> list, int level) where T : BaseNode
    {
        return String.Join("\n", list.Select((l, index) => l.Dump(level, index == 0)));
    }


    public static T If<T>(Func<bool> predicate, T trueCond, T falseCond)
    {
        if (predicate()) return trueCond;

        return falseCond;
    }


    public static List<List<T>> Split<T>(this List<T> collection, Predicate<T> predicate)
    {
        var result = new List<List<T>>();

        int index = 0;
        while (index < collection.Count)
        {
            int splitIndex = collection.FindIndex(index, predicate);
            if (splitIndex == -1)
            {
                splitIndex = collection.Count;
            }
    
            var batch = collection.GetRange(index, splitIndex - index);
            index = splitIndex + 1;
            
            result.Add(batch);
        }

        return result;
    }
    
    
    public static int FindFirstIndex<T>(this List<T> collection, Predicate<T> predicate)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (predicate(collection[i])) return i;
        }

        return -1;
    }
    
    // public static void Print<TKey, TVal>(this Dictionary<TKey, TVal> collection) where TKey : notnull
    // {
        // foreach (var (key, value) in collection)
        // {
            // Console.WriteLine($"{key} {value}");            
        // }
    // }
}