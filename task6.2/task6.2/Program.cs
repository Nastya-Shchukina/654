using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координату x");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите координату y");
            var y = double.Parse(Console.ReadLine());

            Console.WriteLine("Принадлежит ли точка области? " + IsPointInArea(x, y));

            Console.ReadKey();
        }

        static bool IsPointInArea(double x, double y)
        {
            return x <= -3 && -2 <= y ||
                -1 <= x && -2 <= y;
        }
    }
}
