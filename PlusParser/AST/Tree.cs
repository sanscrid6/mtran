using PlusParser.Tokens.Tokens;

namespace PlusParser.AST;

interface INode
{
    
}


public class DefaultNode: INode
{
    public TokenBase value;

    public override string ToString()
    {
        return value.ToString();
    }
}

public class ComplexNode: INode
{
    public DefaultNode op;
    public DefaultNode head;
    public DefaultNode body;
    
    public override string ToString()
    {
        return op.ToString();
    }
}


public class Node<T>
{
    public readonly List<Node<T>> children = new();
    public readonly Node<T> prev;
    public readonly T value;

    public Node<T> GetPrev()
    {
        if (prev != null) return prev;
        return this;
    }


    public Node() {
    }

    public Node(T val, Node<T> prev)
    {
        value = val;
        this.prev = prev;
    }

    public Node<T> AddChildren(T val)
    {
        var node = new Node<T>(val, this);
        children.Add(node);
        
        return node;
    }
}

public class Tree<T>
{
    public Node<T> root = new();

    public void Print()
    {
        PrintNode(root, 0);
    }

    private void PrintNode(Node<T> node, int indentLevel)
    {
        Console.WriteLine($"{new string(' ', indentLevel * 4)}{node.value}");

        foreach (var child in node.children)
        {
            PrintNode(child, indentLevel + 1);
        }
    }
}