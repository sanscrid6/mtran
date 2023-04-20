namespace PlusParser;

class Program
{
    static void Main()
    {
        // try
        // {
            var lines = File.ReadAllText(@"D:\lab\mtran\PlusParser\program.txt");
            var tokens = Lexer.Parse(lines);
            Parser.BuildAST(tokens);
           
            var columnWidth = 20;
            Console.WriteLine($"{"Variable".PadRight(columnWidth)} {"Type".PadRight(columnWidth)}");
            foreach (var (key, value) in Lexer.variables)
            {
                Console.WriteLine($"{key.PadRight(columnWidth)} {value.PadRight(columnWidth)}");
            }
            Console.WriteLine();
            Console.WriteLine($"{"Symbol".PadRight(columnWidth)} {"Type".PadRight(columnWidth)}");

            foreach (var keyword in Lexer.keywords)
            {
                Console.WriteLine($"{keyword.PadRight(columnWidth)} {"Keyword".PadRight(columnWidth)}");
            }
            
            foreach (var keyword in Lexer.operators)
            {
                Console.WriteLine($"{keyword.PadRight(columnWidth)} {"Operator".PadRight(columnWidth)}");
            }
            
            Console.WriteLine();
            Console.WriteLine($"{"Value".PadRight(columnWidth*3)} {"Type".PadRight(columnWidth)}");
            
            foreach (var keyword in Lexer.constants)
            {
                Console.WriteLine($"{keyword.PadRight(columnWidth*3)} {"Constant".PadRight(columnWidth)}");
            }
            //Console.Write("Keywords: ");
            //Console.WriteLine(String.Join(", ", ));
            //Console.Write("Operators: ");
            //Console.WriteLine(String.Join(", ", Lexer.operators));
        
            // Console.WriteLine("no errors");
        // }
        // catch (Exception e)
        // {
            // Console.WriteLine(e.Message);
        // }
    }
}