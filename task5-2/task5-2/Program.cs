using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = "кинематограф";

            string word2 = word1.Substring(8, 4) + word1[7] + word1.Substring(4, 2) + word1[2];

            Console.WriteLine("Первое полученное слово:" + word2);

            string word3 = word1.Substring(4, 1) + word1[3] + word1[6] + word1[9] + word1[7];
            Console.WriteLine("Второе полученное слово:" + word3);

            Console.ReadKey();
        }
    }
}
