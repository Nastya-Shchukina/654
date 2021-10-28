using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите слово,которое нужно зашифровать:");
            string s = Console.ReadLine().ToUpper();

            Console.WriteLine("Введите ключ:");
            int key = int.Parse(Console.ReadLine());

            GetEncrypt(s, key);

            Console.WriteLine();

            Console.WriteLine("Введите слово,которое нужно расшифровать:");
            s = Console.ReadLine().ToUpper();

            Console.WriteLine("Введите ключ:");
            key = int.Parse(Console.ReadLine());

            GetDecrypt(s, key);

            Console.ReadKey();
        }


        static void GetEncrypt(string s, int key)
        {
            string s1 = "";
            string alfphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int m = alfphabet.Length;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (s[i] == alfphabet[j])
                    {
                        int temp = j + key;

                        while (temp >= m)
                            temp -= m;

                        s1 = s1 + alfphabet[temp];
                    }
                }
            }
            Console.WriteLine("Зашифрованное слово:" + s1);
        }


        static void GetDecrypt(string s, int key)
        {
            string s1 = "";
            string alfphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int m = alfphabet.Length;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < alfphabet.Length; j++)
                {
                    if (s[i] == alfphabet[j])
                    {
                        int temp = j - key;
                        while (temp <= -1)
                            temp += m;

                        s1 = s1 + alfphabet[temp];
                    }
                }
            }
            Console.WriteLine("Расшифрованное слово:" + s1);
        }
    }
}
