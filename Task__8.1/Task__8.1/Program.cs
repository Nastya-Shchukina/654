using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task__8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            while (true)
            {
                Console.WriteLine("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }
                else
                {
                    int sum = CountSum(n);
                    Console.WriteLine($"Полученное число: " + sum);
                }
                break;

            }

            Console.WriteLine();
            Console.ReadKey();

        }

        static int CountSum(int n)
        {
            int sum = 0, i = 1;

            while (i <= n)
            {
                sum = sum + i * i;
                i++;
            }

            return sum;

        }
    }
}
