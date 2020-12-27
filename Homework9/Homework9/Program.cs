using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.Write("Введите число b: ");
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine();
                int[] arr = GetArray(15, b);
                Console.WriteLine("Исходный массив");
                PrintArray(arr);

                Console.WriteLine();
                ChangeMinusOddInd(arr);
                Console.WriteLine("Массив после замены знака у элементов с нечетным индексом");
                PrintArray(arr);

                Console.WriteLine();
                double avr = CountAverage(arr);
                Console.WriteLine("Среднее арифметическое элементов массива: {0:f3}", avr);

                Console.WriteLine();
                Console.WriteLine("Введите число k: ");
                int k = int.Parse(Console.ReadLine());

                Console.WriteLine();
                int[] arr2 = GetArrayModulo(arr, k);
                Console.WriteLine("Полученный массив остатков от деления на k");
                PrintArray(arr2);
            }

            static int[] GetArray(int n, int b)
            {
                int[] arr = new int[n];
                int pow = 1;
                for (int i = 0; i < n; i++)
                {
                    arr[i] = pow - b;
                    pow <<= 1;
                }
                return arr;
            }


            static void PrintArray(int[] arr)
            {
                if (arr.Length > 0)
                {
                    Console.Write(arr[0]);
                }
                for (int i = 1; i < arr.Length; i++)
                {
                    Console.Write(";" + arr[i]);
                }
                Console.WriteLine();
            }


            static void ChangeMinusOddInd(int[] arr)
            {
                for (int i = 1; i < arr.Length; i = i + 2)
                {
                    arr[i] = -arr[i];
                }
            }


            static double CountAverage(int[] arr)
            {
                double avr = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    avr = avr + arr[i];
                }
                return avr / arr.Length;
            }


            static int[] GetArrayModulo(int[] arr, int k)
            {
                int[] arrMod = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arrMod[i] = arr[i] % k;
                }
                return arrMod;
            }
        }
    }