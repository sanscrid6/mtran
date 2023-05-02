namespace PlusParser.AST.TreeTokens;

public class BaseNode
{
      public virtual string Dump(int level, bool isNode=false)
      {
            return $"{new string(' ', level * 4)}";
      }

      public virtual void Analyze()
      {
            
      }

      public static string DrawLevel(int level)
      {
            if (level > 0)
            {
                  return String.Concat(Enumerable.Repeat("|   ", level));
            }

            return "";
      }

      public virtual object? Execute()
      {
            return default;
      }

      public static string DrawNode(int level)
      {
            return DrawLevel(level - 1)+"└───";
      }
}