using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i = 1, sum = 0;

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
                    int result = CountSum(n);
                    Console.WriteLine($"Полученное число:" + result);
                }
                break;
               
            }

        }

        static int CountSum(int n)
        {
            int i = 1, sum = 0, result = 0;
            do
            {
                sum += i * i;
                result = result + sum;
                i++;

            } while (sum > n);

            return result;
        }
    }
}
