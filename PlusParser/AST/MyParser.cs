using PlusParser.AST.TreeTokens;
using sly.lexer;
using sly.parser.generator;
using sly.parser.parser;
using Type = PlusParser.AST.TreeTokens.Type;

namespace PlusParser.AST;

public class MyParser
{
    private Type GetType(Token<ExpressionToken> type)
    {
        var t = Type.Int;

        switch (type.TokenID)
        {
            case ExpressionToken.INT:
            {
                t = Type.Int;
                break;
            }
            case ExpressionToken.VOID:
            {
                t = Type.Void;
                break;
            }
            case ExpressionToken.CHAR:
            {
                t = Type.Char;
                break;
            }
            case ExpressionToken.STRING:
            {
                t = Type.String;
                break;
            }
            case ExpressionToken.FLOAT:
            {
                t = Type.Float;
                break;
            }
        }

        return t;
    }

    [Production("program : funcdecl+")]
    public BaseNode StatementSequence(List<BaseNode> sequence)
    {
        return new EntryNode(sequence.Cast<FunctionDefinitionNode>().First(f => f.Name == "main"),
                                sequence.Cast<FunctionDefinitionNode>().ToList());
    }

    [Production("block: OPENBLOCK [d] line* CLOSEBLOCK [d]")]
    public BaseNode Block(List<BaseNode> n)
    {
        return new BodyNode(n);
    }

    [Production("cout: COUT [d] (STREAMOUT [d] expression)*")]
    public BaseNode Cout(List<Group<ExpressionToken, BaseNode>> expr)
    {
        return new CoutNode(expr.Select(t => t.Value(0)).ToList());
    }
    
    [Production("return: RETURN [d] expression ?")]
    public BaseNode Return(ValueOption<BaseNode> expr)
    {
        return new ReturnNode(expr.Match((e) => e, () => null));
    }
    
    [Production("cin: CIN [d] STREAMIN [d] var")]
    public BaseNode Cin(BaseNode expr)
    {
        return new CinNode(expr as VariableNode);
    }
    
    [Production("for: FOR [d] LPAREN [d] vardecl SEMICOLON [d] expression SEMICOLON [d] unary RPAREN [d] block")]
    public BaseNode For(BaseNode assign, BaseNode expr, BaseNode incr, BaseNode block)
    {
        return new ForNode(assign, expr as ExpressionNode, incr as UnaryOperationNode, block as BodyNode);
    }
    
    [Production("if: IF [d] LPAREN [d] expression RPAREN [d] [block | line]")]
    public BaseNode If(BaseNode cond, BaseNode body)
    {
        return new IfNode(cond, body);
    }
    
    [Production("while: WHILE [d] LPAREN [d] expression RPAREN [d] block")]
    public BaseNode While(BaseNode cond, BaseNode body)
    {
        return new WhileNode(cond, body);
    }
    
    [Production("switch: SWITCH [d] LPAREN [d] var RPAREN [d] OPENBLOCK [d] case* CLOSEBLOCK [d]")]
    public BaseNode Switch(BaseNode var, List<BaseNode> cases)
    {
        return new SwitchNode(var as VariableNode, cases.Cast<CaseNode>().ToList());
    }

    [Production("funcinit: expression COMA ?")]
    public BaseNode FuncInit(BaseNode n, Token<ExpressionToken> coma)
    {
        return n;
    }

    [Production("funccall: var [d] LPAREN [d] funcinit* RPAREN [d]")]
    public BaseNode FunctionCall(BaseNode var, List<BaseNode> args)
    {
        return new FunctionCallNode(var as VariableNode, args);
    }
    
     
    [Production("case: CASE [d] [CHAR_LITERAL | INT_LITERAL | FLOAT_LITERAL] COLON [d] line* BREAK [d] SEMICOLON [d]")]
    public BaseNode Case(Token<ExpressionToken> type, List<BaseNode> lines)
    {
        BaseNode t = null;
        switch (type.TokenID)
        {
            case ExpressionToken.CHAR_LITERAL:
            {
                t = new CharConstantNode(type.CharValue);
                break;
            }
            case ExpressionToken.INT_LITERAL:
            {
                t = new IntConstantNode(type.IntValue);
                break;
            }
            case ExpressionToken.FLOAT_LITERAL:
            {
                t = new FloatConstantNode((float)type.DoubleValue);
                break;
            }
        }
        return new CaseNode(t, new BodyNode(lines));
    }

    [Production("line: for")]
    [Production("line: if")]
    [Production("line: while")]
    [Production("line: switch")]
    public BaseNode Forward(BaseNode n)
    {
        return n;
    }

    [Production("line: unary (SEMICOLON [d])?")]
    [Production("line: assign (SEMICOLON [d])?")]
    [Production("line: vardecl (SEMICOLON [d])?")]
    [Production("line: cout (SEMICOLON [d])?")]
    [Production("line: cin (SEMICOLON [d])?")]
    [Production("line: return (SEMICOLON [d])?")]
    [Production("line: funccall (SEMICOLON [d])?")]
    [Production("line: arrdecl (SEMICOLON [d])?")]
    public BaseNode Line(BaseNode sequence, ValueOption<Group<ExpressionToken, BaseNode>> option)
    {
        if (option.IsNone)
        {
            throw new Exception("cant find semicolon");
        }

        return sequence;
    }

    [Production("arg: [INT | FLOAT | STRING | CHAR ] VARIABLE LSQUARE ? RSQUARE ? COMA ?")]
    public BaseNode Arg(Token<ExpressionToken> type, Token<ExpressionToken> name, Token<ExpressionToken> lsquare, Token<ExpressionToken> rsquare, Token<ExpressionToken> coma)
    {
        if (!lsquare.IsEmpty && rsquare.IsEmpty)
        {
            throw new Exception("cant find ]");
        }
        
        if (lsquare.IsEmpty && !rsquare.IsEmpty)
        {
            throw new Exception("cant find [");
        }

        var t = GetType(type);

        return new ArgNode(t, name.Value, !lsquare.IsEmpty);
    }

    [Production("funcdecl: [INT | FLOAT | STRING | CHAR | VOID] VARIABLE LPAREN [d] arg* RPAREN [d] block")]
    public BaseNode FuncDecl(Token<ExpressionToken> type, Token<ExpressionToken> name, List<BaseNode> args, BaseNode block)
    {
        var t = GetType(type);

        return new FunctionDefinitionNode(name.Value, args.Cast<ArgNode>().ToList(), t, block as BodyNode); 
    }
    
    [Production("arrdecl: [INT | FLOAT | STRING | CHAR] VARIABLE LSQUARE [d] RSQUARE [d] ASSIGN [d] OPENBLOCK [d] arrinit+ CLOSEBLOCK [d] ")]
    public BaseNode ArrDecl(Token<ExpressionToken> type, Token<ExpressionToken> name, List<BaseNode> init)
    {
        var t = GetType(type);
        
        return new VariableDeclarationNode(name.Value, t, new ArrInitNode<BaseNode>(init), true);
    }
    
    [Production("arrinit: [INT_LITERAL | FLOAT_LITERAL | CHAR_LITERAL] COMA ? ")]
    public BaseNode ArrInit(Token<ExpressionToken> type, Token<ExpressionToken> coma)
    {
        switch (type.TokenID)
        {
            case ExpressionToken.INT_LITERAL:
                return new IntConstantNode(type.IntValue);
            case ExpressionToken.CHAR_LITERAL:
                return new CharConstantNode(type.CharValue);
            case ExpressionToken.FLOAT_LITERAL:
                return new FloatConstantNode((float) type.DoubleValue);
        }

        throw new Exception($"cant find type ${type.TokenID}");
    }

    [Production("vardecl: [INT | FLOAT | STRING | CHAR] VARIABLE (ASSIGN [d] expression) ?")]
    //[Production("vardecl: [INT | FLOAT | STRING | CHAR] VARIABLE (ASSIGN [d] funccall) ?")]
    public BaseNode TypeDecl(Token<ExpressionToken> type, Token<ExpressionToken> name,ValueOption<Group<ExpressionToken, BaseNode>> expr)
    {
        var t = GetType(type);

        if (expr.IsSome)
        {
            var v = expr.Match(v => v, () => null);
            return new VariableDeclarationNode(name.Value, t, v.ItemsByName["expression"].Value);
        }
        
        return new VariableDeclarationNode(name.Value, t, null);
    }
    
    
    [Production("vardecl: [INT | FLOAT | STRING | CHAR] VARIABLE (ASSIGN [d] funccall) ?")]
    public BaseNode TypeDeclFunc(Token<ExpressionToken> type, Token<ExpressionToken> name,ValueOption<Group<ExpressionToken, BaseNode>> expr)
    {
        var t = GetType(type);

        if (expr.IsSome)
        {
            var v = expr.Match(v => v, () => null);
            return new VariableDeclarationNode(name.Value, t, v.ItemsByName["funccall"].Value);
        }
        
        return new VariableDeclarationNode(name.Value, t, null);
    }


    [Production("unary: VARIABLE DEC")]
    [Production("unary: VARIABLE INC")]
    public BaseNode Inc(Token<ExpressionToken> variable, Token<ExpressionToken> op)
    {
        switch (op.TokenID)
        {
            case ExpressionToken.INC:
            {
                return new UnaryOperationNode(new VariableNode(variable.Value), UnaryOperation.Inc);
            }
            case ExpressionToken.DEC:
            {
                return new UnaryOperationNode(new VariableNode(variable.Value), UnaryOperation.Dec);
            }
        }

        return null;
    }
    
    [Production("assign: VARIABLE ASSIGN [d] expression")]
    public BaseNode AssignStmt(Token<ExpressionToken> variable, BaseNode value)
    {
        var assign = new AssignStatement(variable.StringWithoutQuotes, value);
        return assign;
    }


    [Production("primary: FLOAT_LITERAL")]
    public BaseNode FloatLiteral(Token<ExpressionToken> token)
    {
        return new FloatConstantNode((float)token.DoubleValue);
    }
    
    [Production("primary: INT_LITERAL")]
    public BaseNode IntLiteral(Token<ExpressionToken> token)
    {
        return new IntConstantNode(token.IntValue);
    }
    
    [Production("primary: STRING_LITERAL")]
    public BaseNode StringLiteral(Token<ExpressionToken> token)
    {
        return new StringConstantNode(token.StringWithoutQuotes);
    }
    
    [Production("primary: CHAR_LITERAL")]
    public BaseNode CharLiteral(Token<ExpressionToken> token)
    {
        return new CharConstantNode(token.CharValue);
    }

    [Production("var: VARIABLE")]
    public BaseNode Variable(Token<ExpressionToken> token)
    {
        return new VariableNode(token.Value);
    }
    
    [Production("primary: var")]
    public BaseNode Var(BaseNode n)
    {
        return n;
    }
    
    [Production("operand: primary")]
    public BaseNode Operand(BaseNode node)
    {
        return node;
    }

    [Production("expression: term [ PLUS | MINUS | MUL | DIV ] expression")]
    public BaseNode Expression(BaseNode left, Token<ExpressionToken> operatorToken, BaseNode right)
    {
        BaseNode result = null;

        switch (operatorToken.TokenID)
        {
            case ExpressionToken.PLUS:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Plus);
                break;
            }
            case ExpressionToken.MINUS:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Minus);
                break;
            }
            case ExpressionToken.MUL:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Mul);
                break;
            }
            case ExpressionToken.DIV:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Div);
                break;
            }
        }

        return result!;
    }
    
    [Production("expression: term [ GT | GTE | LT | LTE | EQ ] expression")]
    public BaseNode Comparison(BaseNode left, Token<ExpressionToken> operatorToken, BaseNode right)
    {
        BaseNode result = null;

        switch (operatorToken.TokenID)
        {
            case ExpressionToken.EQ:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Eq);
                break;
            }
            case ExpressionToken.LT:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Lt);
                break;
            }
            case ExpressionToken.LTE:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Lte);
                break;
            }
            case ExpressionToken.GT:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Gt);
                break;
            }
            
            case ExpressionToken.GTE:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Gte);
                break;
            }
        }

        return result!;
    }
    
    [Production("expression: term [ AND | OR ] expression")]
    public BaseNode Logic(BaseNode left, Token<ExpressionToken> operatorToken, BaseNode right)
    {
        BaseNode result = null;

        switch (operatorToken.TokenID)
        {
            case ExpressionToken.OR:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.Or);
                break;
            }
            case ExpressionToken.AND:
            {
                result = new BinaryOperationNode(left, right, BinaryOperation.And);
                break;
            }
        }

        return result!;
    }

    [Production("expression: term")]
    public BaseNode ExpressionTerm(BaseNode termValue)
    {
        return termValue;
    }

    [Production("term: operand")]
    public BaseNode TermOperand(BaseNode factorValue)
    {
        return factorValue;
    }
    
    [Production("term: VARIABLE LSQUARE [d] expression RSQUARE [d]")]
    public BaseNode TermArr(Token<ExpressionToken> variable, BaseNode expr)
    {
        return new BinaryOperationNode(new VariableNode(variable.Value), expr, BinaryOperation.ArrVal);
    }
}
