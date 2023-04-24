using PlusParser.AST;
using PlusParser.AST.TreeTokens;
using sly.parser;
using sly.parser.generator;
using sly.parser.syntax.tree;

namespace PlusParser;


class Program
{
    static void PrintTree(ISyntaxNode<ExpressionToken>? node, int depth = 0)
    {
        if (node == null)
        {
            return;
        }

        if (node is SyntaxNode<ExpressionToken> sn)
        {
            //Console.WriteLine($"{new string(' ', depth * 4)}{node.Name}");

            foreach (var n in sn.Children)
            {
                PrintTree(n, depth + 1);
            }
        }

        if (node is SyntaxLeaf<ExpressionToken> sl)
        {
            Console.WriteLine($"{new string(' ', depth)}{sl.Token.Value}");

        }
    }

    static void Main()
    {
        Parser<ExpressionToken, BaseNode> parser = null;

        MyParser myParserDefinition = new MyParser();
        var parserBuilder = new ParserBuilder<ExpressionToken, BaseNode>();

        var parserResult = parserBuilder.BuildParser(myParserDefinition, ParserType.EBNF_LL_RECURSIVE_DESCENT, "statement");
      
        if (parserResult.IsOk) {
            parser = parserResult.Result;
        }
        else {
            foreach(var error in parserResult.Errors) {
                Console.WriteLine($"{error.Code} : {error.Message}");
            }    
        }

        string expression = @"
#include <iostream>
using namespace std;

int main(){
 float firstNum = 0.00;
    string text = ""sum is"";
        int sum = qq;
cout << ""Enter your operater: +, -, *, /: \n"";

    for (int i = 0; i < 5; i++){
        sum = sum + i;
    }

    if(a < 2){
        count++;
    }

 while(a < 2 || b > 3){
        count++;
    }
    
quickSort(arr, start, p - 1);
     switch(setOperator) {
        case '+':
            cout << ""The answer is: "" << firstNum + secondNum;
        break;
case '+':
            cout << ""The answer is: "" << firstNum + secondNum;
        break;
case '+':
            cout << ""The answer is: "" << firstNum + secondNum;
        break;
        
    }

     return ;   
    }
";

        var l = parser.Lexer.Tokenize(expression);
        Console.WriteLine(l.Tokens.Count);
        foreach (var t in l.Tokens) 
        {
            Console.WriteLine(t.TokenID);
        }

        var r = parser?.Parse(expression);
        
        //Console.WriteLine((r.Result as VariableDeclarationNode).Value);
        //var s = r.SyntaxTree.Dump("  ");
        //Console.WriteLine(s);
        
        PrintTree(r.SyntaxTree);
        
        if (r is {IsError: false})
        {
            Console.WriteLine($"result of {expression}  is {r.Result}");
        }
        else
        {
            if (r?.Errors != null && r.Errors.Any())
            {
                // display errors
                r.Errors.ForEach(error => Console.WriteLine());
            }
        }
        
        
        
        
        
        // try
        // {
        //System.Diagnostics.Process.Start(@"D:\lab\mtran\PlusParser\test.cs");
            /*var lines = File.ReadAllText(@"D:\lab\mtran\PlusParser\program.txt");
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
            }*/
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