using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Leleko.CSharp
{
    class Var
    {
        double handle;
        Type type;
    }
    unsafe class Program
    {
        static void ExampleArifmethic()
        {
            // Поддерживаемые арифметические операции {+,-,/,*,^}, приоритетность операций в соответствии с математическими стандартами
            // Поддерживаемые константы - (Pi, pi), (E, e)

            // Supported arifmethic operators {+,-,/,*,^}, priority of operators has standart mathematic
            // Supported constancts - (Pi, pi), (E, e)

            string s = "((2+Pi)/3e+2)^(2*1.2-E)";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, null, null)); // вычислить значение выражения
        }

        static void ExampleScalarParameters()
        {
            //Поддерживаются параметры длиной от 1 до 255 символов, маска [a-zA-Z][a-zA-Z0-9]*
            //Параметры чувствительны к регистру
            //Параметры передаются в составе словаря IDictionary<string, double>

            //Supported parameters name length less then 255 symbols, constraned mask [a-zA-Z][a-zA-Z0-9]*
            //Register is important
            //Parameters box in IDictionaty<string, double>

            IDictionary<string, double> parameters = new Dictionary<string, double>();
            parameters.Add("Rom", 12);
            parameters.Add("X", 3);

            string s = "X+Rom";

            Console.WriteLine("'{0}' = {1}",s,CalcScript.Evaluate(s, parameters, null));

            //Поддерживается оператор {=}, он же оператор инициализации
            
            //Supported set operator {=}, it's init operator if value is null

            s = "Y=X-Rom";
            Console.WriteLine("'{0}' = {1}",s,CalcScript.Evaluate(s, parameters, null));
            Console.WriteLine("{0} = {1}","Y",parameters["Y"]);

            s = "Y=Y*(X=X+1)";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            Console.WriteLine("{0} = {1}, {2} = {3}", "Y", parameters["Y"], "X", parameters["X"]);
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            Console.WriteLine("{0} = {1}, {2} = {3}", "Y", parameters["Y"], "X", parameters["X"]);

            s = "Z=3";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            s = "Y/Z";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
        }

        static void ExampleLogical()
        {
            //Поддерживаются логические операции {!,&&,||}
            //(!) поскольку все операции проходят с типом double, то существует упрощение {0}->False, {*:!=0}->True, т.е x=2 => x is True

            //Supported Logical operation {!,&&,||}
            //(!) converted {0}->False, {*:!=0}->True

            IDictionary<string, double> parameters = new Dictionary<string, double>();
            parameters.Add("Rom", 3);
            parameters.Add("X", 0);

            string s = "X && Rom";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            s = "X || Rom";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            s = "!X";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
        }

        static void ExampleCompare()
        {
            //Поддерживаются математические операторы сравнения стиля C {>,>=,==,!=,<=,<}

            //Supported compartion operators C style {>,>=,==,!=,<=,<}

            IDictionary<string, double> parameters = new Dictionary<string, double>();
            parameters.Add("Rom", 3);
            parameters.Add("X", 0);

            string s = "X < Rom";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            s = "X == Rom";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
        }

        static void ExampleListParameters()
        {
            //Одно из ключевых отличий моего проекта от прочих OpenSource аналогов - поддержна работы со списками - параметрами
            //Все списки-параметры должны быть унаследованы от IList<double>

            //One of the features of my progect - IList<double> parameters support
            
            List<double> Mem = new List<double> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            Dictionary<string, IList<double>> lists = new Dictionary<string, IList<double>>();
            lists.Add("Mem", Mem);

            string s = "Mem[2] + Mem[4]";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, null, null));

        }

        static double Avg(double x, double y, double z) { return (x + y + z) / 3; }
        static void ExampleUserFunction()
        {
            // Доступно добавление пользовательских функций для вызова внутри скрипта
            // Имена функций чувствительны к регистру
            // Ограничение - возвращаемый тип - double и типы параметров - {double,&double}, количество параметров от 1 до 4х

            // Supported added user function for call into script after
            // Constraints - type(ReturnedType) is double, type(parameters) is {double, ref double, out double}, count of parameters is [0;4]

            CalcScript.Functions.Set(Avg);
            string s = "Avg(1,3,4)";
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, null, null));
        }

        static void ExampleIfElse()
        {
            // If(<condition>,<then>,<else>) Or if(...)

            //(!) функция If является жадной - т.е. выражение и выражение <then> и выражение <else> будут вычислены независимо от <condition>, а вот который результат будет возвращен функцией 
            //(!) function If is greedy - expressions <then> and <else> will be evaluated independently of <condition>

            Dictionary<string, double> parameters = new Dictionary<string, double>();
            parameters.Add("x", 2);

            string s = "if(x>0,x=x+1,x=x-1)"; // we think that this is 3, and x is 3, because (x=2)>0, but x=x-1 will be calculated to and function return 3, but x is 2;
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));

            s = "x=if(x>0,x+1,x-1)"; // right variant
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
            Console.WriteLine("'{0}' = {1}", s, CalcScript.Evaluate(s, parameters, null));
        }

        public delegate double FuncTest(double x, double y, double Zeta);
        static void ExampleCompilation()
        {
            // Любое выражение которое может быть транслировано может быть скомпилировано
            // Every expression who make be translated, can be compilated

            // Имена параметров должны соответствовать именам параметров делегата
            // The parameter names must be equals parameter names of delegate

            string s = "(x+y)*Zeta";
            var FCompile = CalcScript.Compilate(typeof(FuncTest), s) as FuncTest;
            Console.WriteLine("'{0}' = {1}", s, FCompile(1, 2, 5)); // FCompile(x,y,Zeta)
        }

        public delegate double FuncTestExt(out double result, ref double x, IList<double> L);
        static void ExampleCompilationExtension()
        {
            string s = "result=(x=x+L[0])*(L[2]=L[2]+2)";
            var FCompile = CalcScript.Compilate(typeof(FuncTestExt), s) as FuncTestExt;
            List<double> L = new List<double> { 1, 2, 3, 4, 5 };
            double x = 1;
            double result;
            Console.WriteLine("'{0}' = {1}, x = {2}, L[2]={3}, result = {4}", s, FCompile(out result, ref x, L), x, L[2], result);
            Console.WriteLine("'{0}' = {1}, x = {2}, L[2]={3}, result = {4}", s, FCompile(out result, ref x, L), x, L[2], result);
            Console.WriteLine("'{0}' = {1}, x = {2}, L[2]={3}, result = {4}", s, FCompile(out result, ref x, L), x, L[2], result);
        }


        static void Main(string[] args)
        {
            //Console.WriteLine((Math.Pow(1.24,1.0/24)-1)*12);
            ExampleScalarParameters();
        }
    }
}
