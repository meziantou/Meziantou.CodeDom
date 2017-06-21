using Meziantou.CodeDom;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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
            Console.WriteLine(generator.Write(unit));
        }
    }
}
