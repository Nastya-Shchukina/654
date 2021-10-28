using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = GetValue();
            Console.WriteLine("x = " + x);
            Console.ReadKey();
        }
        
        static double GetValue()
        {
            return F(1, 2, 3) + F(5, 3, 8) + F(1, 5, 6);
        }
        
        static double F(double a, double b, double c)
        {
            return Math.Sqrt((a + Math.Pow(Math.Tan(b), 2)) / c);
        }
    }
}
