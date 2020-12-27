using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0, n = 0;

            var tryAgain = true;

            while (tryAgain)
            {
                Console.WriteLine("Введите число строк (m)");
                var input = Console.ReadLine();

                if (int.TryParse(input, out m) && m >= 5 && m <= 20)
                {
                    while (true)
                    {
                        Console.WriteLine("Введите число столбцов (n)");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out n) && n >= 5 && n <= 20)
                        {
                            tryAgain = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода\n");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }
            }

            var rnd = new Random();

            var table = new int[m, n];

            for (var i = 0; i < table.GetLength(0); i++)
                for (var j = 0; j < table.GetLength(1); j++)
                    table[i, j] = rnd.Next(0, 100);

            Console.WriteLine("Введите число:");
            var x = int.Parse(Console.ReadLine());

            Console.WriteLine();

            PrintTable(table);
            Console.WriteLine();

            GetBiggerElement(table, x);
            Console.WriteLine();

            var averages = GetAverageByRow(table);

            for (var i = 0; i < averages.Length; i++)
                Console.WriteLine($"Столбец: {i,2} Среднее арифметическое: {averages[i]:F3}");

            Console.ReadKey();
        }


        static void PrintTable(int[,] t)
        {
            for (var i = 0; i < t.GetLength(0); i++)
            {
                for (var j = 0; j < t.GetLength(1); j++)
                    Console.Write($"{t[i, j],2} ");

                Console.WriteLine();
            }
        }


        static void GetBiggerElement(int[,] t, int x)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (t[i, j] > x)
                    {
                        Console.WriteLine(i.ToString() + "," + j.ToString());
                        return;
                    }
                }
                Console.WriteLine();
            }
        }


        static double[] GetAverageByRow(int[,] t)
        {
            var result = new double[t.GetLength(0)];

            for (var j = 0; j < t.GetLength(1); j++)
            {
                var s = 0.0;

                for (var i = 0; i < t.GetLength(0); i++)
                    s += t[i, j];

                result[j] = s / t.GetLength(0);
            }

            return result;
        }
    }
}