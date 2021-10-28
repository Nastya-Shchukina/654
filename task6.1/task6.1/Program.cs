using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = GetNumber("m");
            var n = GetNumber("n");

            Console.WriteLine("Верно ли, что каждое из чисел m и n больше 10? "
                + EvaluateLogicalExpression(m, n));

            Console.ReadKey();
        }

        static bool EvaluateLogicalExpression(int m, int n)
        {
            return m > 10 && n > 10;
        }

        static int GetNumber(string numberName)
        {
            Console.WriteLine("Введите число " + numberName);
            return int.Parse(Console.ReadLine());
        }
    }
}
