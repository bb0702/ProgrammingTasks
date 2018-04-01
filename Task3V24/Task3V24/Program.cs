using System;

namespace Task3V24
{
   public class StepFunction
    {
        public double A;
        public int B;
        public int X;

        public void SetValues(double a, int b, int x)
        {
            A = a;
            B = b;
            X = x;
        }

        public double FuncRes()
        {
            return A * Math.Pow(X, B);
        }

        public string GetNlook(int n)
        {
            var a = A;
            var b = B;
            for (var i = 0; i < n; i++)
            {
                a *= b;
                b--;
            }

            return $"{a}*x^({b})";
        }

        public double GetNresult(int n)
        {
            var a = A;
            var b = B;
            for (var i = 0; i < n; i++)
            {
                a *= b;
                b--;
            }

            return a * Math.Pow(X, b);
        }

        public StepFunction()
        {
            A = 0;
            B = 0;
            X = 0;
        }

        public StepFunction(double a, int b, int x)
        {
            A = a;
            B = b;
            X = x;
        }
    }


    internal static class MainClass
    {
        public static void Main(string[] args)
        {
            var func = new StepFunction(4, 3, 3);
            StepFunction[] array =
            {
                new StepFunction(10, 0, 2),
                new StepFunction(4, 1, 2),
                new StepFunction(3, 2, 2)
            };
            const int n = 4;
            const int m = 2;
            Console.WriteLine("Function result is:" + func.FuncRes());
            Console.WriteLine("Function n-derivative looks like :" + func.GetNlook(n));
            Console.WriteLine("Function n-derivative result is :" + func.GetNresult(n));
            var look = " ";
            double result = 0;
            double derivativeRes = 0;
            foreach (var el in array)
            {
                result += el.FuncRes();
                look += el.GetNlook(m);
                look += "+ ";
                derivativeRes += el.GetNresult(m);
            }

            look = look.Substring(0, look.Length - 2);
            Console.WriteLine("Function result is:" + result);
            Console.WriteLine("Function m-derivative looks like :" + look);
            Console.WriteLine("Function m-derivative result is :" + derivativeRes);
        }
    }
}