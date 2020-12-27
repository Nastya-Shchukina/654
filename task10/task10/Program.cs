using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
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
                }
            }

            var rnd = new Random();

            var table = new int[m, n];

            for (var i = 0; i < table.GetLength(0); i++)
                for (var j = 0; j < table.GetLength(1); j++)
                    table[i, j] = rnd.Next(0, 100);

            PrintTable(table);

            var averages = GetAverageByColumn(table);

            for (var j = 0; j < averages.Length; j++)
                Console.WriteLine($"Столбец: {j,2} Среднее: {averages[j]:F3}");

            // var index = GetIndexOfMoreNumber(table);

            // if (index < 0)
            //    Console.WriteLine("Число не найдено");

            //  else
            //    Console.WriteLine($"Индекс элемента, который больше заданного числа: {index}.");

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

        static double[] GetAverageByColumn(int[,] t)
        {
            var average = new double[t.GetLength(0)];

            for (var j = 0; j < t.GetLength(1); j++)
            {
                var s = 0.0;

                for (var i = 0; i < t.GetLength(0); i++)
                    s += t[i, j];

                average[j] = s / t.GetLength(0);
                
            }

           
            
        }

    }
}

            