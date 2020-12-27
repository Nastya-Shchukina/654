using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;

            while (true)
            {
                Console.WriteLine("Введите количество студентов в группе: ");

                if (!int.TryParse(Console.ReadLine(), out k))
                {
                    Console.WriteLine("Ошибка ввода\n");
                    continue;
                }
                else
                {
                    double averageage = Count(k);
                    Console.WriteLine($"Полученное число: " + averageage);
                }
                break;
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        static double Count(double k)

        {
            double age, allages = 0;
            int i = 0;

                for (i = 1; i <= k; i++)
                {
                    Console.WriteLine("Введите возраст студентов: ");
                    age = Convert.ToDouble(Console.ReadLine());

                    allages = allages + age;
                        if (i == 2)
                            break;

                }
                
                var averageage = allages / k;
                return averageage;
 
        }
    }
}
