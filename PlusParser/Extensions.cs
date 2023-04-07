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