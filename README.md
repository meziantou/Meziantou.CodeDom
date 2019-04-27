> The code moved to <https://github.com/meziantou/Meziantou.Framework>

# Meziantou.CodeDom

`Meziantou.CodeDom` is a language agnostic code generator. It is a nice replacement for the old `System.CodeDom`. Indeed `System.CodeDom` has not evolved for years.

`Meziantou.CodeDom` supports most of the modern syntaxes of C#. It also provides nice implicit converters, so your code remain understandable.

The following code:
````
var unit = new CodeCompilationUnit();
var ns = unit.AddNamespace("Meziantou.CodeDom");
var c = ns.AddType(new CodeClassDeclaration("Sample"));
var method = c.AddMember(new CodeMethodDeclaration("Factorial"));
method.ReturnType = typeof(int);
var n = method.AddArgument("n", typeof(int));
method.Modifiers = Modifiers.Public | Modifiers.Static;

method.Statements = new CodeConditionStatement()
{
    Condition = new CodeBinaryExpression(BinaryOperator.LessThanOrEqual, 1, n),
    TrueStatements = new CodeReturnStatement(1),
    FalseStatements = new CodeReturnStatement(new CodeBinaryExpression(
        BinaryOperator.Multiply,
        n,
        new CodeMethodInvokeExpression(method, new CodeBinaryExpression(BinaryOperator.Substract, n, 1))))
};
            
var generator = new CSharpCodeGenerator();
generator.Write(unit);
````

Generates the following C# code:

````
namespace Meziantou.CodeDom
{
    class Sample
    {
        public static int Factorial(int n)
        {
            if ((1 <= n))
            {
                return 1;
            }
            else
            {
                return (n * this.Factorial((n - 1)));
            }
        }
    }
}
````
