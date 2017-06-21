# Meziantou.CodeDom

`Meziantou.CodeDom` is a code generator for C#. It is much easier to use than `System.CodeDom`.

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
