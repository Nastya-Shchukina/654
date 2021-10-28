using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundlesLibrary
{
    public struct Bundle
    {
        public int Banknote;
        public int Count;
        public readonly int Sum;

        public Bundle(int banknote, int count)
        {
            if (banknote != 1 || banknote != 2 || banknote != 5 || banknote != 10 || banknote != 50 || banknote != 100 || banknote != 200 || banknote != 500 || banknote != 1000 || banknote != 2000 || banknote != 5000)
            {
                throw new Exception("Значение номинала можеть быть только 1, 2, 5, 10, 50, 100, 200, 500, 1000, 2000, 5000!");
            }

            if (count < 0)
            {
                throw new Exception("Передаваемое значение должно быть больше нуля!");
            }

            Banknote = banknote;
            Count = count;
            Sum = banknote * count;
        }

        public static Bundle Read()
        {
            int n, c;

            while (true)
            {
                Console.WriteLine("Введите номинал купюр:");
                n = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите количество купюр в пачке:");
                c = int.Parse(Console.ReadLine());

                if (c < 0)
                {
                    Console.WriteLine("Передаваемое значение должно быть больше нуля!");
                }
                else
                {
                    if (n != 1 || n != 2 || n != 5 || n != 10 || n != 50 || n != 100 || n != 200 || n != 500 || n != 1000 || n != 2000 || n != 5000)
                    {
                        Console.WriteLine("Значение номинала можеть быть только 1, 2, 5, 10, 50, 100, 200, 500, 1000, 2000, 5000!");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return new Bundle(n, c);
        }

        public override string ToString()
        {
            return $"{Count.ToString()} x {Banknote.ToString()} р.";
        }

        public override bool Equals(object obj)
        {
            if (obj is Bundle)
            {
                Bundle b = (Bundle)obj;

                return Banknote == b.Banknote && Count == b.Count;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Count, Banknote).GetHashCode();
        }

        public void Display()
        {
            Console.WriteLine($"Структура 'Bundles', {Count.ToString()} x {Banknote.ToString()} р.");
        }

        public static Bundle operator +(Bundle b1, Bundle b2)
        {
            if (b1.Banknote == b2.Banknote)
            {
                return new Bundle(b1.Banknote, b1.Count + b2.Count);
            }
            else
            {
                throw new Exception("Сложение пачек невозможно, так как не совпадает номинал!");
            }
        }

        public static Bundle operator -(Bundle b1, Bundle b2)
        {
            if (b1.Banknote == b2.Banknote && b1.Count >= b2.Count)
            {
                return new Bundle(b1.Banknote, b1.Count - b2.Count);
            }
            else
            {
                throw new Exception("Вычитание пачек невозможно, так как не совпадает номинал или в первой пачке меньше банкнот!");
            }
        }
    }
}
