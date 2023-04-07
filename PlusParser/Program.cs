namespace PlusParser;

class Program
{
    static void Main()
    {
        // try
        // {
            string[] lines = File.ReadAllLines(@"D:\lab\PlusParser\PlusParser\program.txt").Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            var tokens = Lexer.Parse(String.Join("\n", lines));
            Parser.BuildAST(tokens);
           
            var columnWidth = 20;
            Console.WriteLine($"{"Variable".PadRight(columnWidth)} {"Type".PadRight(columnWidth)}");
            foreach (var (key, value) in Lexer.variables)
            {
                Console.WriteLine($"{key.value.PadRight(columnWidth)} {value.PadRight(columnWidth)}");
            }
            Console.Write("Keywords: ");
            Console.WriteLine(String.Join(", ", Lexer.keywords));
            Console.Write("Operators: ");
            Console.WriteLine(String.Join(", ", Lexer.operators));
        
            // Console.WriteLine("no errors");
        // }
        // catch (Exception e)
        // {
            // Console.WriteLine(e.Message);
        // }
    }
}