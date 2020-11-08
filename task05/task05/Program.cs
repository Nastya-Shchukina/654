using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string lineRus = Console.ReadLine();

            string lineEng = Transliteration(lineRus);
            Console.WriteLine(lineEng);

            Console.ReadKey();
        }

        static string Transliteration(string str)
        {
            str = str.Replace("А", "A");
            str = str.Replace("Б", "B");
            str = str.Replace("В", "V");
            str = str.Replace("Г", "G");
            str = str.Replace("Д", "D");
            str = str.Replace("Е", "E");
            str = str.Replace("Ё", "E");
            str = str.Replace("Ж", "ZH");
            str = str.Replace("З", "Z");
            str = str.Replace("И", "I");
            str = str.Replace("Й", "I");
            str = str.Replace("К", "K");
            str = str.Replace("Л", "L");
            str = str.Replace("М", "M");
            str = str.Replace("Н", "N");
            str = str.Replace("О", "O");
            str = str.Replace("П", "P");
            str = str.Replace("Р", "R");
            str = str.Replace("С", "S");
            str = str.Replace("Т", "T");
            str = str.Replace("У", "U");
            str = str.Replace("Ф", "F");
            str = str.Replace("Х", "KH");
            str = str.Replace("Ц", "TS");
            str = str.Replace("Ч", "CH");
            str = str.Replace("Ш", "SH");
            str = str.Replace("Щ", "SHCH");
            str = str.Replace("Ъ", "IE");
            str = str.Replace("Ы", "Y");
            str = str.Replace("Ь", "");
            str = str.Replace("Э", "E");
            str = str.Replace("Ю", "IU");
            str = str.Replace("Я", "IA");
            str = str.Replace("а", "A");
            str = str.Replace("б", "B");
            str = str.Replace("в", "V");
            str = str.Replace("г", "G");
            str = str.Replace("д", "D");
            str = str.Replace("е", "E");
            str = str.Replace("ё", "E");
            str = str.Replace("ж", "ZH");
            str = str.Replace("з", "Z");
            str = str.Replace("и", "I");
            str = str.Replace("й", "I");
            str = str.Replace("к", "K");
            str = str.Replace("л", "L");
            str = str.Replace("м", "M");
            str = str.Replace("н", "N");
            str = str.Replace("о", "O");
            str = str.Replace("п", "P");
            str = str.Replace("р", "R");
            str = str.Replace("с", "S");
            str = str.Replace("т", "T");
            str = str.Replace("у", "U");
            str = str.Replace("ф", "F");
            str = str.Replace("х", "KH");
            str = str.Replace("ц", "TS");
            str = str.Replace("ч", "CH");
            str = str.Replace("ш", "SH");
            str = str.Replace("щ", "SHCH");
            str = str.Replace("ъ", "IE");
            str = str.Replace("ы", "Y");
            str = str.Replace("ь", "");
            str = str.Replace("э", "E");
            str = str.Replace("ю", "IU");
            str = str.Replace("я", "IA");

            return str;
        }
    }
}
