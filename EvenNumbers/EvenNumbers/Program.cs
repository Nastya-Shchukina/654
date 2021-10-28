using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenNumbers
{
    class Program
    {
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            char[] symbs = new char[] { 'A', 'B', 'C', 'D' };
            Console.WriteLine("Целочисленный массив: ");
            for(int k = 0; k<nums.Length; k++)
            {
                Console.Write(nums[k] + "");
            }

            Console.WriteLine("\nСимвольный массив: ");
            for(int k=0; k<symbs.Length; k++)
            {
                Console.Write(symbs[k] + "");
            }

            Console.WriteLine();

            int[,] myArr = new int[4, 5];
            Random ran = new Random();
            // Инициализируем данный массив
            Console.WriteLine("Многомерный массив целых чисел:"); 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = ran.Next(1, 15);
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            
        }
    }
}
