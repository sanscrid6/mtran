using System.Formats.Asn1;

namespace PlusParser.AST.TreeTokens;

public class VariableDeclarationNode: BaseNode
{
    public readonly Type Type;
    public readonly string Name;
    public readonly BaseNode? Value;
    public readonly bool IsArray;
    
    public VariableDeclarationNode(string name, Type type, BaseNode expr, bool isArray)
    {
        Type = type;
        Name = name;
        Value = expr;
        IsArray = isArray;
    }

    public override void Analyze()
    {
        if (Tables.variablesSemantic.ContainsKey(Name))
        {
            Tables.variablesSemantic.Remove(Name);
        }
        
        Tables.variablesSemantic.Add(Name, new Arg
        {
            name = Name,
            type = Type,
            isArr = IsArray
        });

        if (Value is LiteralNode)
        {
            if (Type == Type.Float && Value is not FloatConstantNode)
            {
                throw new Exception($"expected right operand to be float");
            }
            if (Type == Type.Char && Value is not CharConstantNode)
            {
                throw new Exception($"expected right operand to be char");
            }
            if (Type == Type.Int && Value is not IntConstantNode)
            {
                throw new Exception($"expected right operand to be int");
            }
            if (Type == Type.String && Value is not StringConstantNode)
            {
                throw new Exception($"expected right operand to be string");
            }
        }
        else if (Value is ArrInitNode<BaseNode> arrInitNode)
        {
            if (Type == Type.Int)
            {
                if (!arrInitNode.Init.All(n => n is IntConstantNode))
                {
                    throw new Exception("array initialization should be same type");
                }
            }
            if (Type == Type.Char)
            {
                if (!arrInitNode.Init.All(n => n is CharConstantNode))
                {
                    throw new Exception("array initialization should be same type");
                }
            }
            if (Type == Type.Float)
            {
                if (!arrInitNode.Init.All(n => n is FloatConstantNode))
                {
                    throw new Exception("array initialization should be same type");
                }
            }
            if (Type == Type.String)
            {
                if (!arrInitNode.Init.All(n => n is StringConstantNode))
                {
                    throw new Exception("array initialization should be same type");
                }
            }
        }
        
        Value?.Analyze();
    }

    public override object? Execute()
    {
        Tables.AddVariable(Name, Value?.Execute(), new Arg
        {
            isArr = IsArray,
            name = Name,
            type = Type
        });
        
        return null;
    }

    public VariableDeclarationNode(string name, Type type, BaseNode expr)
    {
        Type = type;
        Name = name;
        Value = expr;
    }

    public override string Dump(int level, bool isNode = false)
    {
        if (IsArray)
        {
            return $"{(!isNode ? DrawLevel(level) : DrawNode(level))}{Type.ToString().ToLower()} {Name}[]\n" +
                   DrawNode(level + 1) + "value:\n" + 
                   Extensions.If(() => Value != null, Value?.Dump(level + 2), $"{DrawNode(level+2)}Empty");
        }

        return $"{(!isNode ? DrawLevel(level) : DrawNode(level))}{Type.ToString().ToLower()} {Name}\n" +
               DrawNode(level + 1) + "value:\n" + 
               Extensions.If(() => Value != null, Value?.Dump(level + 2), $"{DrawNode(level+2)}Empty");
    }
}