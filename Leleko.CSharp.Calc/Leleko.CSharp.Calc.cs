using System;
using System.Collections.Generic;
using System.Reflection;

#if COMPILABLE
using System.Reflection.Emit;
#endif

using System.Runtime;
using System.Runtime.InteropServices;

using System.Threading;

using Leleko.CSharp.Calc.Internal;

namespace Leleko.CSharp
{
    namespace Calc.Internal
    {
        #region [ Help Declaration ]
#if COMPILABLE
        /// <summary>
        /// function forusing with double type
        /// </summary>
        internal static class HelpFunctions
        {
            public static double And(double x, double y) { return Convert.ToDouble(x != 0 && y != 0); }
            public static double Or(double x, double y) { return Convert.ToDouble(x != 0 || y != 0); }
            public static double Ceq(double x, double y) { return Convert.ToDouble(x == y); }
            public static double NotCeq(double x, double y) { return Convert.ToDouble(x != y); }
            public static double Clt(double x, double y) { return Convert.ToDouble(x < y); }
            public static double Ctg(double x, double y) { return Convert.ToDouble(x > y); }
            public static double CltCeq(double x, double y) { return Convert.ToDouble(x <= y); }
            public static double CtgCeq(double x, double y) { return Convert.ToDouble(x >= y); }


            public static double If(double condition, double then, double @else) { return (condition != 0) ? then : @else; }

            public static void SetValueInRef(double value, ref double @ref) { @ref = value; }

            public static double GetValueFromIList(double index, IList<double> ilist)
            {
                return ilist[(int)index];
            }
            public static double SetValueIntoIList(double index, double value, IList<double> ilist)
            {
                ilist[(int)index] = value;
                return value;
            }
        }
        /// <summary>
        /// methods info for Emit
        /// </summary>
        internal static class HelpMethods
        {
            public static readonly MethodInfo IfMethod = HelpTypes.HelpFunctionsType.GetMethod("If", BindingFlags.Static | BindingFlags.Public);

            public static readonly MethodInfo SetValueInRefMethod = HelpTypes.HelpFunctionsType.GetMethod("SetValueInRef", BindingFlags.Static | BindingFlags.Public);

            public static readonly MethodInfo GetValueFromIListMethod = HelpTypes.HelpFunctionsType.GetMethod("GetValueFromIList", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo SetValueIntoIListMethod = HelpTypes.HelpFunctionsType.GetMethod("SetValueIntoIList", BindingFlags.Static | BindingFlags.Public);

            public static readonly MethodInfo AndMethod = HelpTypes.HelpFunctionsType.GetMethod("And", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo OrMethod = HelpTypes.HelpFunctionsType.GetMethod("Or", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo CeqMethod = HelpTypes.HelpFunctionsType.GetMethod("Ceq", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo NotCeqMethod = HelpTypes.HelpFunctionsType.GetMethod("NotCeq", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo Clt = HelpTypes.HelpFunctionsType.GetMethod("Clt", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo Ctg = HelpTypes.HelpFunctionsType.GetMethod("Ctg", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo CltCeq = HelpTypes.HelpFunctionsType.GetMethod("CltCeq", BindingFlags.Static | BindingFlags.Public);
            public static readonly MethodInfo CtgCeq = HelpTypes.HelpFunctionsType.GetMethod("CtgCeq", BindingFlags.Static | BindingFlags.Public);

            public static readonly MethodInfo AbsMethod = HelpTypes.MathType.GetMethod("Abs", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo AcosMethod = HelpTypes.MathType.GetMethod("Acos", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo AsinMethod = HelpTypes.MathType.GetMethod("Asin", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo AtanMethod = HelpTypes.MathType.GetMethod("Atan", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo CosMethod = HelpTypes.MathType.GetMethod("Cos", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo CoshMethod = HelpTypes.MathType.GetMethod("Cosh", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo ExpMethod = HelpTypes.MathType.GetMethod("Exp", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo LogMethod = HelpTypes.MathType.GetMethod("Log", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo Log_2Method = HelpTypes.MathType.GetMethod("Log", HelpTypes.DoubleTypesTwo);
            public static readonly MethodInfo Log10Method = HelpTypes.MathType.GetMethod("Log10", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo MaxMethod = HelpTypes.MathType.GetMethod("Max", HelpTypes.DoubleTypesTwo);
            public static readonly MethodInfo MinMethod = HelpTypes.MathType.GetMethod("Min", HelpTypes.DoubleTypesTwo);
            public static readonly MethodInfo PowMethod = HelpTypes.MathType.GetMethod("Pow", HelpTypes.DoubleTypesTwo);
            public static readonly MethodInfo SinMethod = HelpTypes.MathType.GetMethod("Sin", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo SinhMethod = HelpTypes.MathType.GetMethod("Sinh", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo SqrtMethod = HelpTypes.MathType.GetMethod("Sqrt", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo TanMethod = HelpTypes.MathType.GetMethod("Tan", HelpTypes.DoubleTypesOne);
            public static readonly MethodInfo TanhMethod = HelpTypes.MathType.GetMethod("Tanh", HelpTypes.DoubleTypesOne);
        }
#endif
        /// <summary>
        /// types
        /// </summary>
        internal static class HelpTypes
        {
            public static readonly Type Delegate = typeof(Delegate);

            public static readonly Type Func0 = typeof(Func0);
            public static readonly Type Func1 = typeof(Func1);
            public static readonly Type Func2 = typeof(Func2);
            public static readonly Type Func3 = typeof(Func3);
            public static readonly Type Func4 = typeof(Func4);

#if COMPILABLE
            public static readonly Type IDictionaryType = typeof(IDictionary<string, double>);
            public static readonly Type MathType = typeof(System.Math);
            public static readonly Type HelpFunctionsType = typeof(HelpFunctions);
            public static readonly Type DoubleType = typeof(double);
            public static readonly Type DoubleTypeRef = DoubleType.MakeByRefType();
            public static readonly Type IListType = typeof(IList<double>);


            public static readonly Type[] DoubleTypesOne = new Type[] { DoubleType };
            public static readonly Type[] DoubleTypesTwo = new Type[] { DoubleType, DoubleType };

            public static readonly Type[] CalcDelegateParamTypes = new Type[] { IDictionaryType };
#endif
        }

        /// <summary>
        /// reflection
        /// </summary>
        internal static class Reflection
        {
            /// <summary>
            /// convert IntPrt To [delegateType]
            /// </summary>
            /// <param name="ptr">function pointer</param>
            /// <param name="delegateType">typeof(TDelegate)</param>
            /// <returns>delegate or null</returns>
            internal delegate Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type delegateType);
            /// <summary>
            /// IntPtr to Delegate converter
            /// </summary>
            internal static readonly GetDelegateForFunctionPointerInternal GetDelegateFrom =
                Delegate.CreateDelegate
                (
                    typeof(GetDelegateForFunctionPointerInternal),
                    typeof(Marshal).GetMethod("GetDelegateForFunctionPointerInternal", BindingFlags.NonPublic | BindingFlags.Static)
                ) as GetDelegateForFunctionPointerInternal;

#if COMPILABLE
            /// <summary>
            /// typeof(HandleFrom) is typeof(HandleTo)
            /// </summary>
            /// <param name="handleFrom">checking type</param>
            /// <param name="handleTo">base type or interface</param>
            /// <returns>result</returns>
            delegate bool CanCast(ref RuntimeTypeHandle handleFrom, IntPtr handleTo);
            /// <summary>
            /// typeof(HandleFrom) is typeof(HandleTo)
            /// </summary>
            static readonly CanCast CanCastTo =
                Delegate.CreateDelegate
                (
                    typeof(CanCast),
                    typeof(RuntimeTypeHandle).GetMethod("CanCastTo", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(IntPtr) }, null)
                )
                as CanCast;
            /// <summary>
            /// {From} is {To}
            /// </summary>
            /// <param name="From">checking type</param>
            /// <param name="To">base type or interface</param>
            /// <returns>result</returns>
            public static bool Is(Type From, Type To)
            {
                RuntimeTypeHandle handleFrom = From.TypeHandle;
                return CanCastTo(ref handleFrom, To.TypeHandle.Value);
            }
#endif
        }
        #endregion

        #region [ Delegates ]
        /// <summary>
        /// function with 0 arguments
        /// </summary>
        /// <returns>result</returns>
        public delegate double Func0();
        /// <summary>
        /// function with 1 argument
        /// </summary>
        /// <param name="arg1">argument #1</param>
        /// <returns>result</returns>
        public delegate double Func1(double arg1);                                     
        /// <summary>
        /// function with 2 arguments
        /// </summary>
        /// <param name="arg1">argument #1</param>
        /// <param name="arg2">argument #2</param>
        /// <returns>result</returns>
        public delegate double Func2(double arg1, double arg2);                           
        /// <summary>
        /// function with 3 arguments
        /// </summary>
        /// <param name="arg1">argument #1</param>
        /// <param name="arg2">argument #2</param>
        /// <param name="arg3">argument #3</param>
        /// <returns>result</returns>
        public delegate double Func3(double arg1, double arg2, double arg3);             
        /// <summary>
        /// function with 4 arguments
        /// </summary>
        /// <param name="arg1">argument #1</param>
        /// <param name="arg2">argument #2</param>
        /// <param name="arg3">argument #3</param>
        /// <param name="arg4">argument #4</param>
        /// <returns>result</returns>
        public delegate double Func4(double arg1, double arg2, double arg3, double arg4);
        #endregion
    }

    /// <summary>
    /// Calculator of the mathematical expression
    /// </summary>
    public unsafe static class CalcScript
    {
        /// <summary>
        /// maximum of evaluation stack size ( recommended 256-1024 )
        /// </summary>
        private const int StackMaxSize = 512;   // максимальная глубина стека вычислений
        /// <summary>
        /// maximum of numbers arguments in functions count
        /// </summary>
        private const int NumArgsMaxCount = 1;  // [0-9] максимальное количество аргументов в линкуемых функциях

        /// <summary>
        /// functions, whose was added by user to use from CalcScript
        /// </summary>
        public static class Functions // линкуемые функции
        {
            /// <summary>
            /// functions, whose was added by user
            /// </summary>
            internal static readonly Dictionary<string, IntPtr> functionList = new Dictionary<string, IntPtr>();

            /// <summary>
            /// return enumerator of the [funcNameKey, IntPtr]
            /// </summary>
            /// <returns>enumerator</returns>
            public static Dictionary<string, IntPtr>.Enumerator GetEnumerator() { return functionList.GetEnumerator(); }
            /// <summary>
            /// get collection of the [funkNameKey]
            /// </summary>
            public static Dictionary<string, IntPtr>.KeyCollection NameCollection { get { return functionList.Keys; } }
            /// <summary>
            /// get function by {funcNameKey} = {funcName} + {argsCount}
            /// </summary>
            /// <param name="funcNameKey">{funcName} + {argsCount}</param>
            /// <returns>result or null</returns>
            public static Delegate GetByName(string funcNameKey) 
            {
                IntPtr value;
                if (functionList.TryGetValue(funcNameKey, out value))
                {
                    return Reflection.GetDelegateFrom(value, HelpTypes.Delegate);
                }
                else return null;
                
            }
            /// <summary>
            /// get function by {funcNameKey} = {funcName} + {argsCount}
            /// </summary>
            /// <param name="funcName">function name</param>
            /// <param name="argsCount">count of arguments</param>
            /// <returns>result or null</returns>
            public static Delegate GetByName(string funcName, int argsCount) 
            {
                IntPtr value;
                if (functionList.TryGetValue(funcName + argsCount, out value))
                {
                    return Reflection.GetDelegateFrom(value, HelpTypes.Delegate);
                }
                else return null;
            }

            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Delegate @delegate) { Set(@delegate, @delegate.Method.Name); }
            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func0 @delegate) { Set(@delegate, @delegate.Method.Name); }
            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func1 @delegate) { Set(@delegate, @delegate.Method.Name); }
            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func2 @delegate) { Set(@delegate, @delegate.Method.Name); }
            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func3 @delegate) { Set(@delegate, @delegate.Method.Name); }
            /// <summary>
            /// Adding function to use
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <exception cref="System.NullReferenceException">@delegate is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func4 @delegate) { Set(@delegate, @delegate.Method.Name); }

            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Delegate @delegate, string functionName)
            {
                Type doubleType = typeof(double);
                MethodInfo method = @delegate.Method;
                if (method.ReturnType == doubleType)
                {
                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Length < 5 && parameters.Length > -1)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            if (parameters[i].ParameterType != doubleType)
                                throw new ArgumentException("All parameters must be the double(float64) type");
                        }
                        Type delegateType = null;
                        switch (parameters.Length)
                        {
                            case 0: delegateType = HelpTypes.Func0; break;
                            case 1: delegateType = HelpTypes.Func1; break;
                            case 2: delegateType = HelpTypes.Func2; break;
                            case 3: delegateType = HelpTypes.Func3; break;
                            case 4: delegateType = HelpTypes.Func4; break;
                        }
                        Functions.functionList[functionName + parameters.Length] = Marshal.GetFunctionPointerForDelegate(Delegate.CreateDelegate(delegateType, @delegate.Method));
                        return;
                    }
                    else throw new ArgumentException("Count of parameters must be [0;4]");
                }
                else throw new ArgumentException("Return parameters must be double(float64) type");
            }
            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func0 @delegate, string functionName) { functionList[functionName + "0"] = Marshal.GetFunctionPointerForDelegate(@delegate); }
            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func1 @delegate, string functionName) { functionList[functionName + "1"] = Marshal.GetFunctionPointerForDelegate(@delegate); }
            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func2 @delegate, string functionName) { functionList[functionName + "2"] = Marshal.GetFunctionPointerForDelegate(@delegate); }
            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func3 @delegate, string functionName) { functionList[functionName + "3"] = Marshal.GetFunctionPointerForDelegate(@delegate); }
            /// <summary>
            /// Adding function with choose name to use 
            /// </summary>
            /// <param name="delegate">function(count of parameters = [1;4], return type - double, params types - double</param>
            /// <param name="functionName">special name for this function</param>
            /// <exception cref="System.NullReferenceException">@delegate is null or functionName is null</exception>
            /// <exception cref="System.ArgumentException">function is not complete conditions</exception>
            public static void Set(Func4 @delegate, string functionName) { functionList[functionName + "4"] = Marshal.GetFunctionPointerForDelegate(@delegate); }
        }
        /// <summary>
        /// operands for calculator
        /// </summary>
        private enum OpCode : byte // операнды
        {
            /// <summary>
            /// empty operand, signalized about end of operand stack
            /// </summary>
            _Empty = 128,
            /// <summary>
            /// signalized about opening bracket
            /// </summary>
            _Open,

            /// <summary>
            /// stores the value on top of the vlaues stack in the parameters list at a specified name
            /// </summary>
            Starg_r8,
            /// <summary>
            /// stores the value of list[i] on top of the vlaues stack in the parameters list at a specified name
            /// </summary>
            Stitem_r8,

            
            /// <summary>
            /// computes the bitwise AND of two values and pushes the result onto the evaluation stack
            /// </summary>
            And,
            /// <summary>
            /// compute the bitwise complement of the two values on top of the stack and pushes the result onto the evaluation stack
            /// </summary>
            Or,
            /// <summary>
            /// compares two values. If they are equal, the integer value 1 (float64) is pushed onto the evaluation stack; otherwise 0 (float64) is pushed onto the evaluation stack
            /// </summary>
            Ceq,
            /// <summary>
            /// compares two values. If they are equal, the integer value 0 (float64) is pushed onto the evaluation stack; otherwise 1 (float64) is pushed onto the evaluation stack
            /// </summary>
            NotCeq,
            /// <summary>
            /// compares two values. If the first value is less than the second, the integer value 1 (float64) is pushed onto the evaluation stack; otherwise 0 (float64) is pushed onto the evaluation stack
            /// </summary>
            Clt,
            /// <summary>
            /// compares two values. If the first value is more than the second, the integer value 1 (float64) is pushed onto the evaluation stack; otherwise 0 (float64) is pushed onto the evaluation stack
            /// </summary>
            Ctg,
            /// <summary>
            /// compares two values. If the first value is less or equals than the second, the integer value 1 (float64) is pushed onto the evaluation stack; otherwise 0 (float64) is pushed onto the evaluation stack
            /// </summary>
            CltCeq,
            /// <summary>
            /// compares two values. If the first value is more or equals than the second, the integer value 1 (float64) is pushed onto the evaluation stack; otherwise 0 (float64) is pushed onto the evaluation stack
            /// </summary>
            CtgCeq,

            /// <summary>
            /// adds two values and pushes the result onto the evaluation stack
            /// </summary>
            Add,
            /// <summary>
            /// subtracts one value from another and pushes the result onto the evaluation stack
            /// </summary>
            Sub,
            
            /// <summary>
            /// multiplies two values and pushes the result on the evaluation stack
            /// </summary>
            Mul,
            /// <summary>
            /// divides two values and pushes the result onto the evaluation stack
            /// </summary>
            Div,
            /// <summary>
            /// divides two values and pushes the remainder onto the evaluation stack
            /// </summary>
            Rem,
            /// <summary>
            /// pushes a specified number raised to the specified power onto the evaluation stack
            /// </summary>
            Pow,

            /// <summary>
            /// computes the bitwise complement of value on top of the stack and pushes the result onto the evaluation stack
            /// </summary>
            Not,
            /// <summary>
            /// negates a value and pushes the result onto the evaluation stack
            /// </summary>
            Neg,

            /// <summary>
            /// Math.Abs(x)
            /// </summary>
            FnAbs,
            /// <summary>
            /// Math.Acos(x)
            /// </summary>
            FnAcos,
            /// <summary>
            /// Math.Asin(x)
            /// </summary>
            FnAsin,
            /// <summary>
            /// Math.Atan(x)
            /// </summary>
            FnAtan,
            /// <summary>
            /// Math.Cos(x)
            /// </summary>
            FnCos,
            /// <summary>
            /// Math.Cosh(x)
            /// </summary>
            FnCosh,
            /// <summary>
            /// Math.Exp(x)
            /// </summary>
            FnExp,
            /// <summary>
            /// Math.Log(x)
            /// </summary>
            FnLog,
            /// <summary>
            /// Math.Log_2(x)
            /// </summary>
            FnLog_2,
            /// <summary>
            /// Math.Log10(x)
            /// </summary>
            FnLog10,
            /// <summary>
            /// If(condition,then,else)
            /// </summary>
            FnIf,
            /// <summary>
            /// Math.Max(x)
            /// </summary>
            FnMax,
            /// <summary>
            /// Math.Min(x)
            /// </summary>
            FnMin,
            /// <summary>
            /// Math.Sin(x)
            /// </summary>
            FnSin,
            /// <summary>
            /// Math.Sinh(x)
            /// </summary>
            FnSinh,
            /// <summary>
            /// Math.Sqrt(x)
            /// </summary>
            FnSqrt,
            /// <summary>
            /// Math.Tan(x)
            /// </summary>
            FnTan,
            /// <summary>
            /// Math.Tanh(x)
            /// </summary>
            FnTanh,

            /// <summary>
            /// invoke
            /// </summary>
            Call0,
            /// <summary>
            /// invoke()
            /// </summary>
            Call1,
            /// <summary>
            /// invoke(,)
            /// </summary>
            Call2,
            /// <summary>
            /// invoke(,,)
            /// </summary>
            Call3,
            /// <summary>
            /// invoke(,,,)
            /// </summary>
            Call4,

            /// <summary>
            /// pushes value(double) of parameter list[i] onto the evaluation stack
            /// </summary>
            Lditem_r8,
            /// <summary>
            /// pushes value(double) of parameter onto the evaluation stack
            /// </summary>
            Ldarg_r8,
            /// <summary>
            /// pushes value(double) onto the evaluation stack
            /// </summary>
            Ldind_r8,
        }

        #region [ Buffer Block ]
        /// <summary>
        /// class buffer of calculation
        /// </summary>
        private class Buffer // класс буфера вычислителя
        {
            /// <summary>
            /// buffer to store temporary name in the parsing process
            /// </summary>
            internal string _nameKey = new string(' ', 512);
            /// <summary>
            /// buffer for emulation operands stack in parsing process
            /// </summary>
            internal OpCode[] _opcodes = new OpCode[StackMaxSize];
            /// <summary>
            /// buffer for emulation values stack in parsing process
            /// </summary>
            internal double[] _values = new double[StackMaxSize];
#if COMPILABLE
            /// <summary>
            /// buffer for store indexes of params
            /// </summary>
            internal Dictionary<string, int> _indexDixtionary = new Dictionary<string, int>();
#endif
        }
        /// <summary>
        /// for every thread - create buffer // need for multithreaded calculation
        /// </summary>
        [ThreadStatic]
        private static Buffer buffer; // отдельный буфер для каждого потока = потокобезопасность всей сборки
        #endregion

        #region [ Kernel Block ]
        /// <summary>
        /// Kernel of CalcScript evaluation
        /// </summary>
        private interface IKernel // абстрактное ядро вычислителя
        {
            /// <summary>
            /// push value in evaluation stack
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="value">value to adding</param>
            /// <param name="param_a">special variant parameter</param>
            void PushValue(ref double* lpvalues, double value, object param_a); // добавление значения в стек
            /// <summary>
            /// caluculate operand
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="opcode">calculating operand</param>
            /// <param name="nameKey">buffer for store argument name</param>
            /// <param name="pnameKey">pointer to [nameKey]</param>
            /// <param name="param_a">special variant parameter</param>
            /// <param name="param_b">special variant parameter</param>
            /// <exception cref="System.NotSupportedException">operand is not supported</exception>
            void CalcOpCodes(ref double* lpvalues, OpCode opcode, string nameKey, char* pnameKey, object param_a, object param_b); // вычисление очередного операнда
        }
        /// <summary>
        /// ikernel for script evaluation
        /// </summary>
        private sealed class ScriptKernel : IKernel // ядро интерпретатора
        {
            /// <summary>
            /// push value in evaluation stack
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="value">value to adding</param>
            /// <param name="param_a">special variant parameter</param>
            public void PushValue(ref double* lpvalues, double value, object param_a)
            {
                *++lpvalues = value;
            }
            /// <summary>
            /// caluculate operand
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="opcode">calculating operand</param>
            /// <param name="nameKey">buffer for store argument name</param>
            /// <param name="pnameKey">pointer to [nameKey]</param>
            /// <param name="param_a">special variant parameter</param>
            /// <param name="param_b">special variant parameter</param>
            /// <exception cref="System.NotSupportedException">operand is not supported</exception>
            public void CalcOpCodes(ref double* lpvalues, OpCode opcode, string nameKey, char* pnameKey, object param_a, object param_b)
            {
                double arg1, arg2, arg3, arg4;
#if ARRAYPARAMETERSUPPORT
                IList<double> arglist;
#endif
                double* pvalues = lpvalues;
                switch (opcode)
                {
                    #region [ Parameters ]
                    case OpCode.Ldarg_r8:
                        arg1 = *pvalues--;
                        ExtractNameKey(pnameKey, *(char**)pvalues, (int)arg1);
                        if (param_a != null)
                        {
                            if ((param_a as IDictionary<string, double>).TryGetValue(nameKey, out arg2))
                            {
                                *pvalues = arg2;
                                break;
                            }
                            else goto to_scalarparams_null;
                        }
                        else goto to_scalarparams_null;
                    case OpCode.Starg_r8:
                        arg1 = *pvalues--;
                        arg2 = *pvalues--;
                        ExtractNameKey(pnameKey, *(char**)pvalues, (int)arg2);
                        if (param_a != null)
                        {
                            (param_a as IDictionary<string, double>)[nameKey] = arg1;
                            *pvalues = arg1;
                            break;
                        }
                        else goto to_scalarparams_null;
#if ARRAYPARAMETERSUPPORT
                    case OpCode.Lditem_r8:
                        arg1 = *pvalues--;
                        arg2 = *pvalues--;
                        ExtractNameKey(pnameKey, *(char**)pvalues, (int)arg2);
                        if (param_b != null)
                        {
                            if ((param_b as IDictionary<string, IList<double>>).TryGetValue(nameKey, out arglist))
                            {
                                try
                                {
                                    *pvalues = arglist[(int)arg1];
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    arg2 = arg1;
                                    goto to_argument_outofrange;
                                }
                                break;
                            }
                            else goto to_listparam_null;
                        }
                        else goto to_listparam_null;
                    case OpCode.Stitem_r8:
                        arg1 = *pvalues--;
                        arg2 = *pvalues--;
                        arg3 = *pvalues--;
                        ExtractNameKey(pnameKey, *(char**)pvalues, (int)arg3);
                        if (param_b != null)
                        {
                            if ((param_b as IDictionary<string, IList<double>>).TryGetValue(nameKey, out arglist))
                            {
                                try
                                {
                                    arglist[(int)arg2] = arg1;
                                    *pvalues = arg1;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    goto to_argument_outofrange;
                                }
                                break;
                            }
                            else goto to_listparam_null;
                        }
                        else goto to_listparam_null;
#endif
                    #endregion
                    #region [ Mathematics ]
                    case OpCode.Neg: *pvalues = -*pvalues; return;
                    case OpCode.Add: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = arg1 + arg2; break;
                    case OpCode.Sub: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = arg1 - arg2; break;
                    case OpCode.Mul: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = arg1 * arg2; break;
                    case OpCode.Div: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = arg1 / arg2; break;
                    case OpCode.Rem: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = arg1 % arg2; break;
                    case OpCode.Pow: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Math.Pow(arg1, arg2); break;
                    #endregion
                    #region [ Fuctions ]
                    case OpCode.FnAbs: *pvalues = Math.Abs(*pvalues); return;
                    case OpCode.FnAcos: *pvalues = Math.Acos(*pvalues); return;
                    case OpCode.FnAsin: *pvalues = Math.Asin(*pvalues); return;
                    case OpCode.FnAtan: *pvalues = Math.Atan(*pvalues); return;
                    case OpCode.FnCos: *pvalues = Math.Cos(*pvalues); return;
                    case OpCode.FnCosh: *pvalues = Math.Cosh(*pvalues); return;
                    case OpCode.FnExp: *pvalues = Math.Exp(*pvalues); return;
                    case OpCode.FnLog: *pvalues = Math.Log(*pvalues); return;
                    case OpCode.FnLog_2: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Math.Log(arg1, arg2); break;
                    case OpCode.FnLog10: *pvalues = Math.Log10(*pvalues); return;
                    case OpCode.FnMax: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Math.Max(arg1, arg2); break;
                    case OpCode.FnIf: 
                        arg3 = *pvalues; 
                        arg2 = *--pvalues; 
                        arg1 = *--pvalues; 
                        *pvalues = (arg1 != 0) ? arg2 : arg3; 
                        break;
                    case OpCode.FnMin: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Math.Min(arg1, arg2); break;
                    case OpCode.FnSin: *pvalues = Math.Sin(*pvalues); return;
                    case OpCode.FnSinh: *pvalues = Math.Sinh(*pvalues); return;
                    case OpCode.FnSqrt: *pvalues = Math.Sqrt(*pvalues); return;
                    case OpCode.FnTan: *pvalues = Math.Tan(*pvalues); return;
                    case OpCode.FnTanh: *pvalues = Math.Tanh(*pvalues); return;
                    #endregion
                    #region [ Conditions ]
                    case OpCode.Not: *pvalues = Convert.ToDouble(*pvalues == 0); return;
                    case OpCode.And: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 != 0 && arg2 != 0); break;
                    case OpCode.Or: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 != 0 || arg2 != 0); break;
                    case OpCode.Ceq: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 == arg2); break;
                    case OpCode.NotCeq: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 != arg2); break;
                    case OpCode.Clt: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 < arg2); break;
                    case OpCode.Ctg: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 > arg2); break;
                    case OpCode.CltCeq: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 <= arg2); break;
                    case OpCode.CtgCeq: arg2 = *pvalues; arg1 = *--pvalues; *pvalues = Convert.ToDouble(arg1 >= arg2); break;
                    #endregion
                    #region [ Call ]
                    //   
                    case OpCode.Call0: *pvalues = (Reflection.GetDelegateFrom(*(IntPtr*)pvalues,HelpTypes.Delegate) as Func0)(); return;
                    case OpCode.Call1: arg1 = *pvalues--; *pvalues = (Reflection.GetDelegateFrom(*(IntPtr*)pvalues, HelpTypes.Delegate) as Func1)(arg1); break;
                    case OpCode.Call2: arg2 = *pvalues--; arg1 = *pvalues--; *pvalues = (Reflection.GetDelegateFrom(*(IntPtr*)pvalues, HelpTypes.Delegate) as Func2)(arg1, arg2); break;
                    case OpCode.Call3: arg3 = *pvalues--; arg2 = *pvalues--; arg1 = *pvalues--; *pvalues = (Reflection.GetDelegateFrom(*(IntPtr*)pvalues, HelpTypes.Delegate) as Func3)(arg1, arg2, arg3); break;
                    case OpCode.Call4: arg4 = *pvalues--; arg3 = *pvalues--; arg2 = *pvalues--; arg1 = *pvalues--; *pvalues = (Reflection.GetDelegateFrom(*(IntPtr*)pvalues, HelpTypes.Delegate) as Func4)(arg1, arg2, arg3, arg4); break;
                    #endregion
                    case OpCode._Open: return;
                    default: throw new NotSupportedException(string.Format("Operand <{0}> not supported", opcode));
                }
                lpvalues = pvalues;
                return;
            // scalarParams is null
            to_scalarparams_null:
                throw new ArgumentNullException(nameKey);
#if ARRAYPARAMETERSUPPORT
            to_listparam_null:
                throw new ArgumentNullException(string.Concat(nameKey, "[...]"));
            to_argument_outofrange:
                throw new ArgumentOutOfRangeException(string.Concat(nameKey,"[",((int)arg2).ToString(),"]"));
#endif
            }
        }
        /// <summary>
        /// initialization of scriptKernel
        /// </summary>
        private static readonly ScriptKernel scriptKernel = new ScriptKernel();

#if COMPILABLE 
        /// <summary>
        /// ikernel for delegate compilation
        /// </summary>
        private sealed class CompileKernel : IKernel // ядро компилятора
        {
            /// <summary>
            /// push value in evaluation stack
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="value">value to adding</param>
            /// <param name="param_a">special variant parameter</param>
            public void PushValue(ref double* lpvalues, double value, object param_a)
            {
                (param_a as ILGenerator).Emit(OpCodes.Ldc_R8, value);
            }
            /// <summary>
            /// caluculate operand
            /// </summary>
            /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
            /// <param name="opcode">calculating operand</param>
            /// <param name="nameKey">buffer for store argument name</param>
            /// <param name="pnameKey">pointer to [nameKey]</param>
            /// <param name="param_a">special variant parameter</param>
            /// <param name="param_b">special variant parameter</param>
            /// <exception cref="System.NotSupportedException">operand is not supported</exception>
            public void CalcOpCodes(ref double* lpvalues, OpCode opcode, string nameKey, char* pnameKey, object param_a, object param_b)
            {
                double argument;
                double* pvalues = lpvalues;
                ILGenerator ilGenerator = param_a as ILGenerator;
                Dictionary<string, int> indexDictionary = param_b as Dictionary<string, int>;
                System.Reflection.Emit.OpCode eopcode;
                int index;
                bool isref = false;
                switch (opcode)
                {
                    #region [ Parameters ] // operands associated with parameters
                    case OpCode.Ldarg_r8:
                        argument = *pvalues--; ExtractNameKey(pnameKey, *(char**)pvalues--, (int)argument);     // extract parameter name from expression in to [nameKey]
                        if ((param_b as Dictionary<string, int>).TryGetValue(nameKey, out index))               // get index of parameter
                        {
                            if (index < 0)                                                                      // if [index]<0 then this is ref parameter
                            {
                                isref = true;                                                                   // set flag
                                index = -index - 1;                                                             // set current index of parameter
                            }
                            switch (index)
                            {
                                case 0: eopcode = OpCodes.Ldarg_0; goto to_1_4;
                                case 1: eopcode = OpCodes.Ldarg_1; goto to_1_4;
                                case 2: eopcode = OpCodes.Ldarg_2; goto to_1_4;
                                case 3: eopcode = OpCodes.Ldarg_3; goto to_1_4;
                                default:    // hard il instruction
                                    ilGenerator.Emit((index < 256) ? OpCodes.Ldarg_S : OpCodes.Ldarg, index); goto to_is_ref;
                                to_1_4:     // easy il instruction - fast
                                    ilGenerator.Emit(eopcode);
                                to_is_ref:  // if ref then extract value from ref
                                    if (isref) ilGenerator.Emit(OpCodes.Ldind_R8);
                                    break;
                            }
                            break;
                        }
                        else goto to_argumentexception;
                    case OpCode.Starg_r8:
                        argument = *pvalues--; ExtractNameKey(pnameKey, *(char**)pvalues--, (int)argument);   // extract parameter name from expression in to [nameKey]
                        if ((param_b as Dictionary<string, int>).TryGetValue(nameKey, out index))               // get index of parameter
                        {
                            if (index < 0)                                                                      // if [index]<0 then this is ref parameter
                            {
                                isref = true;                                                                   // set flag
                                index = -index - 1;                                                             // set current index of parameter
                            }
                            ilGenerator.Emit(OpCodes.Dup);                                                      // dublicate value into stack
                            if (isref)      // if ref then put value into ref
                            {
                                ilGenerator.Emit((index < 256) ? OpCodes.Ldarg_S : OpCodes.Ldarg, index);
                                ilGenerator.Emit(OpCodes.Call, HelpMethods.SetValueInRefMethod);
                                break;
                            }
                            else
                            {
                                ilGenerator.Emit((index < 256) ? OpCodes.Starg_S : OpCodes.Starg, index);
                                break;
                            }
                        }
                        else goto to_argumentexception;
#if ARRAYPARAMETERSUPPORT
                    case OpCode.Lditem_r8:
                        argument = *pvalues--; ExtractNameKey(pnameKey, *(char**)pvalues--, (int)argument);     // extract parameter name from expression in to [nameKey]
                        if ((param_b as Dictionary<string, int>).TryGetValue(nameKey, out index))               // get index of parameter
                        {
                            switch (index)
                            {
                                case 0: eopcode = OpCodes.Ldarg_0; goto to_1_4;
                                case 1: eopcode = OpCodes.Ldarg_1; goto to_1_4;
                                case 2: eopcode = OpCodes.Ldarg_2; goto to_1_4;
                                case 3: eopcode = OpCodes.Ldarg_3; goto to_1_4;
                                default:    // hard il instruction
                                    ilGenerator.Emit((index < 256) ? OpCodes.Ldarg_S : OpCodes.Ldarg, index); goto to_call;
                                to_1_4:     // easy il instruction - fast
                                    ilGenerator.Emit(eopcode);
                                to_call:  // if ref then extract value from ref
                                    ilGenerator.Emit(OpCodes.Call, HelpMethods.GetValueFromIListMethod);
                                    break;
                            }
                            break;
                        }
                        else goto to_argumentexception;
                    case OpCode.Stitem_r8:
                        argument = *pvalues--; ExtractNameKey(pnameKey, *(char**)pvalues--, (int)argument);     // extract parameter name from expression in to [nameKey]
                        if ((param_b as Dictionary<string, int>).TryGetValue(nameKey, out index))               // get index of parameter
                        {
                            switch (index)
                            {
                                case 0: eopcode = OpCodes.Ldarg_0; goto to_1_4;
                                case 1: eopcode = OpCodes.Ldarg_1; goto to_1_4;
                                case 2: eopcode = OpCodes.Ldarg_2; goto to_1_4;
                                case 3: eopcode = OpCodes.Ldarg_3; goto to_1_4;
                                default:    // hard il instruction
                                    ilGenerator.Emit((index < 256) ? OpCodes.Ldarg_S : OpCodes.Ldarg, index); goto to_call;
                                to_1_4:     // easy il instruction - fast
                                    ilGenerator.Emit(eopcode);
                                to_call:  // if ref then extract value from ref
                                    ilGenerator.Emit(OpCodes.Call, HelpMethods.SetValueIntoIListMethod);
                                    break;
                            }
                            break;
                        }
                        else goto to_argumentexception;
#endif
                    #endregion
                    #region [ Mathematics ]
                    case OpCode.Neg: ilGenerator.Emit(OpCodes.Neg); return;
                    case OpCode.Add: ilGenerator.Emit(OpCodes.Add); return;
                    case OpCode.Sub: ilGenerator.Emit(OpCodes.Sub); return;
                    case OpCode.Mul: ilGenerator.Emit(OpCodes.Mul); return;
                    case OpCode.Div: ilGenerator.Emit(OpCodes.Div); return;
                    case OpCode.Rem: ilGenerator.Emit(OpCodes.Rem); return;
                    case OpCode.Pow: ilGenerator.Emit(OpCodes.Call, HelpMethods.PowMethod); return;
                    #endregion
                    #region [ Fuctions ]
                    case OpCode.FnAbs: ilGenerator.Emit(OpCodes.Call, HelpMethods.AbsMethod); return;
                    case OpCode.FnAcos: ilGenerator.Emit(OpCodes.Call, HelpMethods.AcosMethod); return;
                    case OpCode.FnAsin: ilGenerator.Emit(OpCodes.Call, HelpMethods.AsinMethod); return;
                    case OpCode.FnAtan: ilGenerator.Emit(OpCodes.Call, HelpMethods.AtanMethod); return;
                    case OpCode.FnCos: ilGenerator.Emit(OpCodes.Call, HelpMethods.CosMethod); return;
                    case OpCode.FnCosh: ilGenerator.Emit(OpCodes.Call, HelpMethods.CoshMethod); return;
                    case OpCode.FnExp: ilGenerator.Emit(OpCodes.Call, HelpMethods.ExpMethod); return;
                    case OpCode.FnLog: ilGenerator.Emit(OpCodes.Call, HelpMethods.LogMethod); return;
                    case OpCode.FnLog_2: ilGenerator.Emit(OpCodes.Call, HelpMethods.Log_2Method); return;
                    case OpCode.FnLog10: ilGenerator.Emit(OpCodes.Call, HelpMethods.Log10Method); return;
                    case OpCode.FnIf: ilGenerator.Emit(OpCodes.Call, HelpMethods.IfMethod); return;
                    case OpCode.FnMax: ilGenerator.Emit(OpCodes.Call, HelpMethods.MaxMethod); return;
                    case OpCode.FnMin: ilGenerator.Emit(OpCodes.Call, HelpMethods.MinMethod); return;
                    case OpCode.FnSin: ilGenerator.Emit(OpCodes.Call, HelpMethods.SinMethod); return;
                    case OpCode.FnSinh: ilGenerator.Emit(OpCodes.Call, HelpMethods.SinhMethod); return;
                    case OpCode.FnSqrt: ilGenerator.Emit(OpCodes.Call, HelpMethods.SqrtMethod); return;
                    case OpCode.FnTan: ilGenerator.Emit(OpCodes.Call, HelpMethods.TanMethod); return;
                    case OpCode.FnTanh: ilGenerator.Emit(OpCodes.Call, HelpMethods.TanhMethod); return;
                    #endregion
                    #region [ Conditions ]
                    case OpCode.Not: ilGenerator.Emit(OpCodes.Conv_I4); ilGenerator.Emit(OpCodes.Ldc_I4_0); ilGenerator.Emit(OpCodes.Ceq); ilGenerator.Emit(OpCodes.Conv_R8); return;
                    case OpCode.And: ilGenerator.Emit(OpCodes.Call, HelpMethods.AndMethod); return;
                    case OpCode.Or: ilGenerator.Emit(OpCodes.Call, HelpMethods.OrMethod); return;
                    case OpCode.Ceq: ilGenerator.Emit(OpCodes.Call, HelpMethods.CeqMethod); return;
                    case OpCode.NotCeq: ilGenerator.Emit(OpCodes.Call, HelpMethods.NotCeqMethod); return;
                    case OpCode.Clt: ilGenerator.Emit(OpCodes.Call, HelpMethods.Clt); return;
                    case OpCode.Ctg: ilGenerator.Emit(OpCodes.Call, HelpMethods.Ctg); return;
                    case OpCode.CltCeq: ilGenerator.Emit(OpCodes.Call, HelpMethods.CltCeq); return;
                    case OpCode.CtgCeq: ilGenerator.Emit(OpCodes.Call, HelpMethods.CtgCeq); return;
                    #endregion
                    #region [ Call ]
                    case OpCode.Call0:
                    case OpCode.Call1:
                    case OpCode.Call2:
                    case OpCode.Call3:
                    case OpCode.Call4: ilGenerator.Emit(OpCodes.Call, Reflection.GetDelegateFrom(*(IntPtr*)pvalues--, HelpTypes.Delegate).Method); break;
                    #endregion
                    case OpCode._Open: return;
                    default: throw new NotSupportedException(string.Format("Operand <{0}> not supported", opcode));
                }
                lpvalues = pvalues;
                return;
            to_argumentexception:
                throw new ArgumentNullException(nameKey);
            }
        }
        /// <summary>
        /// initialization of compileKernel
        /// </summary>
        private static readonly CompileKernel compileKernel = new CompileKernel();
#endif
        #endregion

        /// <summary>
        /// fast exponentiation
        /// </summary>
        /// <param name="degree">degree</param>
        /// <returns>result</returns>
        static double Pow10Fast(int degree) // быстрое вычисление 10 в степени degree
        {
            if (degree < 309) // double.MaxValue = 1,79769313486232E+308, if more then - infinum
            {
                double value = 1.0;
                if ((degree & 1) == 1) value = 10.0;
                if (((degree >> 1) & 1) == 1) value *= 1e+2;
                if (((degree >> 2) & 1) == 1) value *= 1e+4;
                if (((degree >> 3) & 1) == 1) value *= 1e+8;
                if (((degree >> 4) & 1) == 1) value *= 1e+16;
                if (((degree >> 5) & 1) == 1) value *= 1e+32;
                if (((degree >> 6) & 1) == 1) value *= 1e+64;
                if (((degree >> 7) & 1) == 1) value *= 1e+128;
                if (((degree >> 8) & 1) == 1) value *= 1e+256;
                return value;
            }
            else return double.PositiveInfinity;
        }
        /// <summary>
        /// calculate number of function arguments
        /// </summary>
        /// <param name="pwcstr">pointer to area of the arguments of the functionn</param>
        /// <returns>count of arguments in function</returns>
        /// <exception cref="FormatException">close Bracket not found</exception>
        static int ArgsCount(char* pwcstr) // подсчет количества аргументов в функции
        {
            char* cur = pwcstr;
        to_first:
            switch (*cur)
            {
                case ' ':
                case '\t': cur++; goto to_first;
                case ')': return 0; // отсутсвие аргументов
                default: break;
            }
            int brbalance = 0, count = 1;
            for (; ; cur++)
                switch (*cur)
                {
                    case '(': brbalance++; continue;
                    case ')':
                        if (brbalance == 0) return count;
                        else { --brbalance; continue; }
                    case ',':
                        if (brbalance == 0) count++;
                        break;
                    case '\0': throw new FormatException("Closed bracket not found in expression: " + (new string(pwcstr - 1)));
                }
        }
        /// <summary>
        /// extract [nameKey] from expression
        /// </summary>
        /// <param name="pnameKey">pointer to the [nameKey]</param>
        /// <param name="pname">pointer to the name in the expression</param>
        /// <param name="length">the number of characters in the name</param>
        static void ExtractNameKey(char* pnameKey, char* pname, int length) // извлечение имени параметра длины(length) из строки(pname) в буффер ключа(pnameKey)
        {
            *(((int*)pnameKey) - 1) = length; // устанавливаем длину ключа
            for (char* pnameKey_end = pnameKey + length; pnameKey < pnameKey_end; *(pnameKey++) = *(pname++)) ; // посимвольно копируем имя параметра в ключ
            *pnameKey = '\0'; // устанавливаем символ окончания строки стандарта ANSI
        }

        /// <summary>
        /// try get function with [nameKey] signature
        /// </summary>
        /// <param name="pcopcodes">poiner to top opcode in evaluation stack</param>
        /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
        /// <param name="nameKey">buffer for store argument name</param>
        /// <param name="pnameKey">pointer to [nameKey]</param>
        /// <param name="argscount">number of function arguments</param>
        /// <param name="functionList">list of added functions</param>
        /// <returns>success</returns>
        // пытаемся распарсить функцию, для скорости применяется сортировка по особому hash
        static bool TryParseFunction(OpCode* pcopcodes, ref double* lpvalues, string nameKey, char* pnameKey, int argscount, Dictionary<string, IntPtr> functionList)
            
        {
            switch (argscount * 100 + nameKey.Length) // расчета хэша
            {
                case 103: // 100+2+1
                    switch (*pnameKey)
                    {
                        case 'C':
                        case 'c':
                            if (*++pnameKey == 'h') { *pcopcodes = OpCode.FnCosh; return true; }
                            else goto to_default;
                        case 'L':
                        case 'l':
                            switch (*++pnameKey)
                            {
                                case 'g': *pcopcodes = OpCode.FnLog10; return true;
                                case 'n': *pcopcodes = OpCode.FnLog; return true;
                                default: goto to_default;
                            }
                        case 'S':
                        case 's':
                            if (*++pnameKey == 'h') { *pcopcodes = OpCode.FnSinh; return true; }
                            else goto to_default;
                        case 'T':
                        case 't':
                            if (*++pnameKey == 'h') { *pcopcodes = OpCode.FnTanh; return true; }
                            else goto to_default;
                        default: goto to_default;
                    }
                case 104: // 100+3+1
                    switch (*pnameKey)
                    {
                        case 'A':
                        case 'a':
                            if (*++pnameKey == 'b' && *++pnameKey == 's') { *pcopcodes = OpCode.FnAbs; return true; }
                            else goto to_default;
                        case 'C':
                        case 'c':
                            if (*++pnameKey == 'o' && *++pnameKey == 's') { *pcopcodes = OpCode.FnCos; return true; }
                            else goto to_default;
                        case 'E':
                        case 'e':
                            if (*++pnameKey == 'x' && *++pnameKey == 'p') { *pcopcodes = OpCode.FnExp; return true; }
                            else goto to_default;
                        case 'L':
                        case 'l':
                            if (*++pnameKey == 'o' && *++pnameKey == 'g') { *pcopcodes = OpCode.FnLog; return true; }
                            else goto to_default;
                        case 'S':
                        case 's':
                            if (*++pnameKey == 'i' && *++pnameKey == 'n') { *pcopcodes = OpCode.FnSin; return true; }
                            else goto to_default;
                        case 'T':
                        case 't':
                            if (*++pnameKey == 'a' && *++pnameKey == 'n') { *pcopcodes = OpCode.FnTan; return true; }
                            else goto to_default;
                        default: goto to_default;
                    }
                case 105: //100+4+1
                    switch (*pnameKey)
                    {
                        case 'A':
                        case 'a':
                            switch (*++pnameKey)
                            {
                                case 'C':
                                case 'c':
                                    if (*++pnameKey == 'o' && *++pnameKey == 's') { *pcopcodes = OpCode.FnAcos; return true; }
                                    else goto to_default;
                                case 'S':
                                case 's':
                                    if (*++pnameKey == 'i' && *++pnameKey == 'n') { *pcopcodes = OpCode.FnAsin; return true; }
                                    else goto to_default;
                                case 'T':
                                case 't':
                                    if (*++pnameKey == 'a' && *++pnameKey == 'n') { *pcopcodes = OpCode.FnAtan; return true; }
                                    else goto to_default;
                                default: goto to_default;
                            }
                        case 'C':
                        case 'c':
                            if (*++pnameKey == 'o' && *++pnameKey == 's' && *++pnameKey == 'h') { *pcopcodes = OpCode.FnCosh; return true; }
                            else goto to_default;
                        case 'S':
                        case 's':
                            switch (*++pnameKey)
                            {
                                case 'i':
                                    if (*++pnameKey == 'n' && *++pnameKey == 'h') { *pcopcodes = OpCode.FnSinh; return true; }
                                    else goto to_default;
                                case 'q':
                                    if (*++pnameKey == 'r' && *++pnameKey == 't') { *pcopcodes = OpCode.FnSqrt; return true; }
                                    else goto to_default;
                                default: goto to_default;
                            }
                        case 'T':
                        case 't':
                            if (*++pnameKey == 'a' && *++pnameKey == 'n' && *++pnameKey == 'h') { *pcopcodes = OpCode.FnTanh; return true; }
                            else goto to_default;
                        default: goto to_default;
                    }
                case 204: // 200+3+1
                    switch (*pnameKey)
                    {
                        case 'L':
                        case 'l':
                            if (*++pnameKey == 'o' && *++pnameKey == 'g') { *pcopcodes = OpCode.FnLog_2; return true; }
                            else goto to_default;
                        
                        case 'M':
                        case 'm':
                            switch (*++pnameKey)
                            {
                                case 'a':
                                    if (*++pnameKey == 'x') { *pcopcodes = OpCode.FnMax; return true; }
                                    else goto to_default;
                                case 'i':
                                    if (*++pnameKey == 'n') { *pcopcodes = OpCode.FnMin; return true; }
                                    else goto to_default;
                                default: goto to_default;
                            }
                        default: goto to_default;
                    }
                case 303: // 300+2+1
                    switch (*pnameKey)
                    {
                        case 'I':
                        case 'i':
                            if (*++pnameKey == 'f') { *pcopcodes = OpCode.FnIf; return true; }
                            else goto to_default;
                        default: goto to_default;
                    }
                default:
                to_default:
                    IntPtr delegatePtr;
                    if (functionList.TryGetValue(nameKey, out delegatePtr))
                    {
                        *(IntPtr*)(++lpvalues) = delegatePtr;
                        *pcopcodes = (OpCode)((int)OpCode.Call0 + argscount); //OpCodes.Calli
                        return true;
                    }
                    else return false;
            }
        }
        /// <summary>
        /// parse positive float64 value from chars stream onto evaluation stack
        /// </summary>
        /// <param name="lpwstr">reference to pointer to current position of parsing cursor in stream</param>
        static double ParseValue(ref char* lpwstr) // парсинг константы
        {
            double value = 0d, mlt = 1d;
            int degree = 1;
            bool degree_sign = true;

            char* cur = lpwstr;
        to_parse_real:
            #region [ real ]
            switch (*cur++)
            {
                case '0': value = value * 10; goto to_parse_real;
                case '1': value = value * 10 + 1; goto to_parse_real;
                case '2': value = value * 10 + 2; goto to_parse_real;
                case '3': value = value * 10 + 3; goto to_parse_real;
                case '4': value = value * 10 + 4; goto to_parse_real;
                case '5': value = value * 10 + 5; goto to_parse_real;
                case '6': value = value * 10 + 6; goto to_parse_real;
                case '7': value = value * 10 + 7; goto to_parse_real;
                case '8': value = value * 10 + 8; goto to_parse_real;
                case '9': value = value * 10 + 9; goto to_parse_real;
                case '.': goto to_parse_second;
                case 'E':
                case 'e': goto to_E_region;
                default: goto to_end_method;
            }
            #endregion
        to_parse_second:
            #region [.]
            mlt *= 0.1d;
            switch (*cur++)
            {
                case '0': goto to_parse_second;
                case '1': value = value + 1 * mlt; goto to_parse_second;
                case '2': value = value + 2 * mlt; goto to_parse_second;
                case '3': value = value + 3 * mlt; goto to_parse_second;
                case '4': value = value + 4 * mlt; goto to_parse_second;
                case '5': value = value + 5 * mlt; goto to_parse_second;
                case '6': value = value + 6 * mlt; goto to_parse_second;
                case '7': value = value + 7 * mlt; goto to_parse_second;
                case '8': value = value + 8 * mlt; goto to_parse_second;
                case '9': value = value + 9 * mlt; goto to_parse_second;
                case 'E':
                case 'e': goto to_E_region;
                default: goto to_end_method;
            }
            #endregion
        to_E_region:
            #region [ E ] [ e ]
            switch (*cur++)
            {
                case '-': degree_sign = false; break;
                case '+':
                default: break;
            }
            switch (*cur++)
            {
                case '0': break;
                case '1': degree = 1; break;
                case '2': degree = 2; break;
                case '3': degree = 3; break;
                case '4': degree = 4; break;
                case '5': degree = 5; break;
                case '6': degree = 6; break;
                case '7': degree = 7; break;
                case '8': degree = 8; break;
                case '9': degree = 9; break;
            }
        to_parse_degree:
            switch (*cur++)
            {
                case '0': degree = degree * 10; goto to_parse_degree;
                case '1': degree = degree * 10 + 1; goto to_parse_degree;
                case '2': degree = degree * 10 + 2; goto to_parse_degree;
                case '3': degree = degree * 10 + 3; goto to_parse_degree;
                case '4': degree = degree * 10 + 4; goto to_parse_degree;
                case '5': degree = degree * 10 + 5; goto to_parse_degree;
                case '6': degree = degree * 10 + 6; goto to_parse_degree;
                case '7': degree = degree * 10 + 7; goto to_parse_degree;
                case '8': degree = degree * 10 + 8; goto to_parse_degree;
                case '9': degree = degree * 10 + 9; goto to_parse_degree;
                default: goto to_end_method;
            }
            #endregion
        to_end_method:
            if (degree != 1)
            {
                if (degree_sign) value = value * Pow10Fast(degree);
                else value = value / Pow10Fast(degree);
            }
            lpwstr = cur - 1;
            return value;
        }
        /// <summary>
        /// parse constant value(if exist) or parameter onto evaluation stack 
        /// </summary>
        /// <param name="ikernel">kernel of calcscript evaluation</param>
        /// <param name="param_a">special variant parameter</param>
        /// <param name="lpopcodes">reference to pointer to top operand in stack</param>
        /// <param name="lpvalues">reference to pointer to top value in evaluation stack</param>
        /// <param name="pnameKey">buffer for name</param>
        /// <param name="pname">constant pointer to name begining</param>
        /// <param name="length">constant pointer to nameKey begining</param>
        // разбираем строку либо как константу(Pi,E) либо как параметр
        static void ParseConstantOrParameter(IKernel ikernel, object param_a, ref OpCode* lpopcodes, ref double* lpvalues, char* pnameKey, char* pname, int length)
        {
            double value;
            switch (length)
            {
                case 1:
                    if (*pnameKey == 'E' || *pnameKey == 'e')
                    {
                        value = Math.E;
                        goto to_push_constant;
                    }
                    else goto default;
                case 2:
                    if ((*pnameKey == 'P' || *pnameKey == 'p') && *++pnameKey == 'i')
                    {
                        value = Math.PI;
                        goto to_push_constant;
                    }
                    else goto default;
                case 3:
                    if ((*pnameKey == 'I' || *pnameKey == 'i') && *++pnameKey == 'n' && *++pnameKey == 'f')
                    {
                        value = double.PositiveInfinity;
                        goto to_push_constant;
                    }
                    else goto default;
                case 4:
                    if ((*pnameKey == 'T' || *pnameKey == 't') && *++pnameKey == 'r' && *++pnameKey == 'u' && *++pnameKey == 'e')
                    {
                        value = 1.0;
                        goto to_push_constant;
                    }
                    else goto default;
                case 5:
                    if ((*pnameKey == 'F' || *pnameKey == 'f') && *++pnameKey == 'a' && *++pnameKey == 'l' && *++pnameKey == 's' && *++pnameKey == 'e')
                    {
                        value = 0.0;
                        goto to_push_constant;
                    }
                    else goto default;
                default:
                    *(char**)++lpvalues = pname;
                    *++lpvalues = length;
                    *++lpopcodes = OpCode.Ldarg_r8;
                    return;
                to_push_constant:
                    ikernel.PushValue(ref lpvalues, value, param_a);
                    return;
            }
        }
        /// <summary>
        /// expression parsing
        /// </summary>
        /// <param name="ikernel">kernel of calcscript evaluation</param>
        /// <param name="buffer">buffer</param>
        /// <param name="expression">mathematical expression</param>
        /// <param name="pwcstr">constant pointer to expression begining</param>
        /// <param name="param_a">special variant parameter</param>
        /// <param name="param_b">special variant parameter</param>
        /// <returns>result</returns>
        // производим разбор выражения
        static double ParseExpression(IKernel ikernel, Buffer buffer, string expression, char* pwcstr, object param_a, object param_b)
        {
            int rbr_balance = 0;                            // balans of '(' and ')'            // баланс () скобок
            int sbr_balance = 0;                            // balans of '[' and ']'            // баланс [] скобок
            char* cur = pwcstr, bfcur;                      // moved char cursor for expression // курсор разбираемой строки
            OpCode opcode = OpCode._Empty;                  // operand                          // текущий операнд

            Dictionary<string, IntPtr> functions = CalcScript.Functions.functionList; // get functions list // получение списка прилинкованных функций

            string nameKey = buffer._nameKey;                // get buffer for key               // ссылка на буффер ключа
            fixed (char* pcnameKey = nameKey)               // get pinned pointer to buffer     // фиксирующий указатель на буфер ключа
            fixed (double* pcvalues = &buffer._values[0])                                        // фиксирующий указатель на буфер значений
            fixed (OpCode* pcopcodes = &buffer._opcodes[0])                                      // фиксирующий указатель на буфер операндов
            {
                string exception = string.Empty;    // buffer string for exception text // буфферная ссылка для хранения исключения

                double* pvalues = pcvalues; *pvalues = double.NaN;
                OpCode* popcodes = pcopcodes; *popcodes = OpCode._Empty;          // label of empty codes stack

                #region [ positioned cursor after open bracket or operator ] // позиционирование после открытия скобки, либо оператора
            to_after_bropen_or_operator:
                switch (*cur)
                {
                    case '-':
                        if (*popcodes != OpCode.Neg)
                        {
                            *(++popcodes) = OpCode.Neg;
                            goto case ' ';
                        }
                        else
                        {
                            exception = "Symbol was not recognized";
                            goto to_exception;
                        }
                    case '!':
                        *(++popcodes) = OpCode.Not;
                        goto case ' ';
                    case '(':
                        rbr_balance++;
                        *(++popcodes) = OpCode._Open;
                        goto case '\t';
                    case ')': goto to_after_value_or_brclose;
                    case ' ':
                    case '\t':
                        cur++;
                        goto to_after_bropen_or_operator;
                }
                #endregion
                #region [ positioned cursor after open bracket or operator on second phase ] // позиционирование после открытия скобки, либо оператора, фаза №2
            to_after_bropen_or_operator_second_phase:
                switch (*cur)
                {
                    #region [ Const ]
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '.':
                        ikernel.PushValue(ref pvalues, ParseValue(ref cur), param_a);
                        goto to_after_value_or_brclose;
                    #endregion
                    case ' ':
                    case '\t':
                        cur++;
                        goto to_after_bropen_or_operator_second_phase;
                    case '\0':
                        if (rbr_balance == 0) goto to_end_method;
                        else
                        {
                            exception = "Incorrect balance of brackets, closing bracket not found";
                            goto to_exception;
                        }
                    default:
                        #region [ parameter || constant || function ]
                        if (char.IsLetter(*cur)) // если на месте курсора находится символ - то это либо функция либо мат. константа, либо параметр
                        {
                            char* pnameKey = pcnameKey;
                            for (*pnameKey = *cur; char.IsLetterOrDigit(*++cur); *++pnameKey = *cur) ;
                            int length = (int)((++pnameKey) - pcnameKey);
                            if (*cur == '(') // вероятно функция
                            {
                                *(((int*)pcnameKey) - 1) = length + NumArgsMaxCount;
                                length = ArgsCount(cur + 1);
                                *pnameKey = (char)(length + '0');  // возможно только если NumArgsMaxCount == 1, в ином случае эту строку нужно будет видоизменить, как? - подумайте сами
                                *++pnameKey = '\0';
                                if (TryParseFunction(++popcodes, ref pvalues, nameKey, pcnameKey, length, functions))
                                {
                                    goto to_after_bropen_or_operator;
                                }
                                else
                                {
                                    exception = string.Concat("Function ", nameKey, "(", new string(',', length), ") not found");
                                    goto to_exception;
                                }
                            }
                            else // не функция
                            {
                                *pnameKey = '\0';
                                ParseConstantOrParameter(ikernel, param_a, ref popcodes, ref pvalues, pcnameKey, cur - length, length);
                                goto to_after_value_or_brclose;
                            }
                        }
                        else // непредусмотренный(а следовательно и неправильный) символ
                        {
                            exception = "Symbol was not recognized";
                            goto to_exception;
                        }
                        #endregion
                }
                #endregion
                #region [ positioned cursor after value or close bracket ]
            to_after_value_or_brclose:
                switch (*cur)
                {
                    case '+': opcode = OpCode.Add; cur++; goto to_push_opcode;
                    case '-': opcode = OpCode.Sub; cur++; goto to_push_opcode;
                    case '*': 
                        if (*(cur + 1) == '*') { opcode = OpCode.Pow; cur += 2; }
                        else { opcode = OpCode.Mul; cur++; }
                        goto to_push_opcode;
                    case '/': opcode = OpCode.Div; cur++; goto to_push_opcode;
                    case '%': opcode = OpCode.Rem; cur++; goto to_push_opcode;
                    case '^': opcode = OpCode.Pow; cur++; goto to_push_opcode;
                    case '<':
                        if (*(cur + 1) == '=') { opcode = OpCode.CltCeq; cur += 2; }
                        else { opcode = OpCode.Clt; cur++; }
                        goto to_push_opcode;
                    case '>':
                        if (*(cur + 1) == '=') { opcode = OpCode.CtgCeq; cur += 2; }
                        else { opcode = OpCode.Ctg; cur++; }
                        goto to_push_opcode;
                    case '=':
                        if (*(cur + 1) == '=') { opcode = OpCode.Ceq; cur += 2; goto to_push_opcode; }
                        else if (*popcodes == OpCode.Ldarg_r8) { *popcodes = OpCode.Starg_r8; cur++; goto to_after_bropen_or_operator; }
                        else if (*popcodes == OpCode.Lditem_r8) { *popcodes = OpCode.Stitem_r8; cur++; goto to_after_bropen_or_operator; }
                        else goto to_exception_operator;
                    case '!':
                        if (*(cur + 1) == '=') { opcode = OpCode.NotCeq; cur += 2; goto to_push_opcode; }
                        else goto to_exception_operator;
                    case '&':
                        if (*(cur + 1) == '&') { opcode = OpCode.And; cur += 2; goto to_push_opcode; }
                        else goto to_exception_operator;
                    case '|':
                        if (*(cur + 1) == '|') { opcode = OpCode.Or; cur += 2; goto to_push_opcode; }
                        else goto to_exception_operator;
                    case '[':
                        if (*popcodes == OpCode.Ldarg_r8)
                        {
                            sbr_balance++;
                            *popcodes = OpCode.Lditem_r8;
                            *(++popcodes) = OpCode._Open;
                            cur++;
                            goto to_after_bropen_or_operator;
                        }
                        else
                        {
                            exception = "Array not found in expression";
                            goto to_exception;
                        }
                    case ']':
                        if (sbr_balance != 0)
                        {
                            sbr_balance--;
                            goto to_br_balance;
                        }
                        else
                        {
                            exception = "Incorrect balance of brackets in indexator, opening bracket '[' not found";
                            goto to_exception;
                        }
                    case ')':
                        if (rbr_balance != 0)
                        {
                            rbr_balance--;
                            goto to_br_balance;
                        }
                        else
                        {
                            exception = "Incorrect balance of brackets, opening bracket '(' not found";
                            goto to_exception;
                        }
                    case ',':
                        while (*popcodes > OpCode._Open)
                            ikernel.CalcOpCodes(ref pvalues, *(popcodes--), nameKey, pcnameKey, param_a, param_b);
                        cur++;
                        goto to_after_bropen_or_operator;
                    case ' ':
                    case '\t': cur++; goto to_after_value_or_brclose;
                    case '\0':
                        if (rbr_balance == 0) goto to_end_method;
                        else
                        {
                            exception = "Incorrect balance of brackets, not all brackets was closed";
                            goto to_exception;
                        }
                    default:
                        exception = "Symbol was not recognized";
                        goto to_exception;
                    // pushing operand in calculator stack
                    to_push_opcode:
                        while (*popcodes >= opcode)
                            ikernel.CalcOpCodes(ref pvalues, *popcodes--, nameKey, pcnameKey, param_a, param_b);
                        *++popcodes = opcode;
                        goto to_after_bropen_or_operator;
                    // make operator exception
                    to_exception_operator:
                        exception = "Operator was not recognized";
                        goto to_exception;
                    // brackets balance check
                    to_br_balance:
                        bfcur = cur;
                    to_br_balance_continue:
                        switch (*--bfcur)
                        {
                            case ' ':
                            case '\t': goto to_br_balance_continue;
                            case '(':
                            case '[':
                                exception = "Bracket not contain expression";
                                goto to_exception;
                            default:
                                while (*popcodes > OpCode._Open)
                                    ikernel.CalcOpCodes(ref pvalues, *(popcodes--), nameKey, pcnameKey, param_a, param_b);
                                popcodes--;
                                cur++;
                                goto to_after_value_or_brclose;
                        }
                }
                #endregion
                #region [ end method ]
            to_end_method:  // end of parsing; push out all from stack; return value
                while (*popcodes != OpCode._Empty)                     // pop operands while not empty
                    ikernel.CalcOpCodes(ref pvalues, *(popcodes--), nameKey, pcnameKey, param_a, param_b);   // calculate operand 
                return *pvalues;                                        // return result
                #endregion
                #region [ to_exception ]
            to_exception:   // throw exception with information
                throw new FormatException(string.Format("{0}\n\rExpression: {1}\n\rStop:       {2}{3}\n\rPosition:   {4}", exception, expression, new string(' ', (int)(cur - pwcstr)), (*cur == '\0') ? "\\0" : (*cur).ToString(), cur - pwcstr));
                #endregion
            }
        }

        /// <summary>
        /// translate mathematical expression with parameters
        /// </summary>
        /// <param name="expression">mathematical expression</param>
        /// <param name="scalarParams">parameters</param>
        /// <param name="listParams">lists of parameters</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">expression is null</exception>
        /// <exception cref="ArgumentNullException">scalarParams is null</exception>
        /// <exception cref="FormatException">in the expression has a syntax error</exception>
        public static double Evaluate(string expression, IDictionary<string, double> scalarParams, IDictionary<string, IList<double>> listParams)
        {
            if (expression != null)
            {
                double value;
                Buffer buffer = CalcScript.buffer ?? (CalcScript.buffer = new Buffer());
                fixed (char* pwcstr = expression)   // get pointer to expression beginning
                {
                    value = ParseExpression(scriptKernel, buffer, expression, pwcstr, scalarParams, listParams); // parse expression
                }
                return value;
            }
            else throw new ArgumentNullException("expression");
        }

#if COMPILABLE
        /// <summary>
        /// compilate mathematical expression to delegate
        /// </summary>
        /// <param name="delegateType">typeof(TDelegate)</param>
        /// <param name="expression">mathematical expression</param>
        /// <returns>result</returns>
        /// <exception cref="ArgumentNullException">expression is null</exception>
        /// <exception cref="ArgumentNullException">delegateType is null</exception>
        /// <exception cref="ArgumentException">delegateType is not typeof(Delegate)</exception>
        /// <exception cref="ArgumentException">return type or one of parameters of delegate is not typeof(double)</exception>
        public static Delegate Compilate(Type delegateType, string expression)
        {
            string paramName = string.Empty;
            string message = string.Empty;
            if (expression != null)
            {
                if (delegateType != null)
                {
                    MethodInfo methodInfo = delegateType.GetMethod("Invoke");
                    if (methodInfo != null)
                    {
                        if (methodInfo.ReturnType == HelpTypes.DoubleType)
                        {
                            Buffer buffer = CalcScript.buffer ?? (CalcScript.buffer = new Buffer());
                            Dictionary<string, int> indexDictionary = buffer._indexDixtionary;
                            indexDictionary.Clear();

                            ParameterInfo[] parametersInfo = methodInfo.GetParameters();
                            Type[] types = (parametersInfo.Length == 0) ? Type.EmptyTypes : new Type[parametersInfo.Length];
                            for (int i = 0; i < parametersInfo.Length; i++)
                            {
                                ParameterInfo parameterInfo = parametersInfo[i];
                                if (parameterInfo.ParameterType == HelpTypes.DoubleType)
                                {
                                    indexDictionary.Add(parameterInfo.Name, parameterInfo.Position);
                                    types[i] = HelpTypes.DoubleType;
                                }
                                else if (parameterInfo.ParameterType == HelpTypes.DoubleTypeRef)
                                {
                                    indexDictionary.Add(parameterInfo.Name, -parameterInfo.Position - 1); // if position<0 then parameter is ref - important
                                    types[i] = HelpTypes.DoubleTypeRef;
                                }
                                else if (Reflection.Is(parameterInfo.ParameterType, HelpTypes.IListType))
                                {
                                    indexDictionary.Add(parameterInfo.Name, parameterInfo.Position);
                                    types[i] = parameterInfo.ParameterType;
                                }
                                else
                                {
                                    message = string.Format("type of parameter <{0}> must be in (Double,Double&,IList<double>), function [{1}]", parameterInfo.Position, methodInfo);
                                    goto to_ArgumentException;
                                }
                            }
                            DynamicMethod dynamicMethod = new DynamicMethod(delegateType.Name, Calc.Internal.HelpTypes.DoubleType, types, true);
                            ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
                            fixed (char* pwcstr = expression)   // get pointer to expression beginning
                            {
                                ParseExpression(compileKernel, buffer, expression, pwcstr, ilGenerator, indexDictionary);
                            }
                            ilGenerator.Emit(OpCodes.Ret);
                            return dynamicMethod.CreateDelegate(delegateType);
                        }
                        else
                        {
                            message = string.Format("return type of function [{0}] is not Double", methodInfo);
                            goto to_ArgumentException;
                        }
                    }
                    else
                    {
                        message = "delegate must be implemented Invoke method";
                        goto to_ArgumentException;
                    }
                to_ArgumentException:
                    throw new ArgumentException(message, "delegateType");
                }
                else
                {
                    paramName = "delegateType";
                    goto to_ArgumentNullException;
                }
            }
            else
            {
                paramName = "expression";
                goto to_ArgumentNullException;
            }
        to_ArgumentNullException:
            throw new ArgumentNullException(paramName, message);
        }
#endif
    }
}
