using System.Collections;
using System.Runtime.InteropServices;

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
    
    // public static void Print<TKey, TVal>(this Dictionary<TKey, TVal> collection) where TKey : notnull
    // {
        // foreach (var (key, value) in collection)
        // {
            // Console.WriteLine($"{key} {value}");            
        // }
    // }
}