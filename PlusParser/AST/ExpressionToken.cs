using sly.lexer;

namespace PlusParser.AST;

public enum ExpressionToken
{
    #region Literals
    
    [Lexeme("[0-9]+\\.[0-9]+")]
    FLOAT_LITERAL = 1,
    
    [Lexeme("[0-9]+")]
    INT_LITERAL = 2,
    
    [Lexeme(@"'[^']'")]
    CHAR_LITERAL = 3,
    
    [Lexeme(@"""[^""]+""")]
    STRING_LITERAL = 4,
    
    [Lexeme(@"\/\/[^\n]+", isSkippable:true)] 
    COMMENT = 5,
    
    #endregion

    #region Arifmetic
    
    [Lexeme(@"\+\+")]
    INC = 10,
    
    [Lexeme(@"--")]
    DEC = 11,

    [Lexeme(@"\+")]
    PLUS = 12,

    [Lexeme(@"\-")]
    MINUS = 13,
    
    [Lexeme(@"\*")]
    MUL = 14,
    
    [Lexeme("/")]
    DIV = 15,

    #endregion

    #region Stream

    [Lexeme(@"<<")]
    STREAMOUT = 16,
    
    [Lexeme(@">>")]
    STREAMIN = 17,

    #endregion

    #region Boolean
    
    [Lexeme("==")]
    EQ = 20,
    
    [Lexeme("<=")]
    LTE = 21,
    
    [Lexeme(">=")]
    GTE = 22,
    
    [Lexeme("<")]
    LT = 23,
    
    [Lexeme(">")]
    GT = 24,
    
    [Lexeme("&&")]
    AND = 25,
    
    [Lexeme(@"\|\|")]
    OR = 26,

    #endregion
    
    #region Operators

    [Lexeme(@"\(")]
    LPAREN = 30,

    [Lexeme(@"\)")]
    RPAREN = 31,
    
    [Lexeme(@"\{")]
    OPENBLOCK = 32,

    [Lexeme(@"\}")]
    CLOSEBLOCK = 33,
    
    [Lexeme(@":")]
    COLON = 34,
    
    [Lexeme(@";")]
    SEMICOLON = 35,
    
    [Lexeme(@"=")]
    ASSIGN = 36,
    
    [Lexeme(@",")]
    COMA = 37,
    
    [Lexeme(@"\[")]
    LSQUARE = 38,
    
    [Lexeme(@"\]")]
    RSQUARE = 39,
    
    #endregion

    #region Keywords
    
    [Lexeme("if")]
    IF = 50,
    
    [Lexeme("else")]
    ELSE = 51,
    
    [Lexeme("return")]
    RETURN = 52,
    
    [Lexeme("int")]
    INT = 53,
    
    [Lexeme("string")]
    STRING = 54,
    
    [Lexeme("float")]
    FLOAT = 55,
    
    [Lexeme("char")]
    CHAR = 56,
    
    [Lexeme("for")]
    FOR = 57,
    
    [Lexeme("while")]
    WHILE = 58,
    
    [Lexeme("case")]
    CASE = 59,
    
    [Lexeme("switch")]
    SWITCH = 60,
    
    [Lexeme(@"using namespace \w+;\s+", true)]
    USING = 61,
    
    [Lexeme(@"#include <\w+>\s+", true)]
    INCLUDE = 62,
    
    [Lexeme(@"void")]
    VOID = 63,
    
    [Lexeme(@"break")]
    BREAK = 64,
    
    [Lexeme(@"goto")]
    GOTO = 65,



    /*[Lexeme("class")]
    CLASS = 65,
    
    [Lexeme("public")]
    PUBLIC = 66,
    
    [Lexeme(@"\.")]
    DOT = 67,
    
    [Lexeme(@"Car")]
    CAR = 68,
    
    */

    #endregion
    
    [Lexeme("cin")]
    CIN = 100,
    
    [Lexeme("cout")]
    COUT = 101,

    [Lexeme(@"\w+")] 
    VARIABLE = 102,

    [Lexeme(@"[ \t]+",  true)] 
    WS = 103,
    
    [Lexeme(@"\r?\n", true, true)] 
    EOL = 104,
}