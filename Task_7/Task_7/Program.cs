using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x ");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine("Значение функции равно " + CalcFunctionResult(x));

            Console.ReadKey();
        }
        public static double CalcFunctionResult(double x)
        {
            if (x < -3)
                return 0;

            if (-3 <= x && x <= -1)
                return 1;

            else
                return 2;
        }
    }
}
