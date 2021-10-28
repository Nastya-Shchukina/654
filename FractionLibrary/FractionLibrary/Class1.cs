using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionLibrary

{
    public struct Fraction
    {
        public int Numerator;
        public int Denominator;
        public readonly int IntPart;

        public Fraction(int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                throw new Exception("Передаваемое значение должно быть положительным.");
            }
            Numerator = numerator;
            Denominator = denominator;
            IntPart = numerator / denominator;
        }

        public static Fraction Read()
        {
            int a, b;

            while (true)
            {
                Console.WriteLine("Введите числитель дроби: ");
                a = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите знаменатель дроби: ");
                b = int.Parse(Console.ReadLine());

                if (b <= 0)
                {
                    Console.WriteLine("Передаваемое значение должно быть положительным.");
                }
                else
                {
                    break;
                }
            }

            return new Fraction(a, b);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction b = (Fraction)obj;

                return Numerator * b.Denominator == b.Numerator * Denominator;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            //закрываем глаза на переполнение int
            unchecked
            {
                //получаем десятичную дробь и берем ее хэш
                var decimalFraction = Numerator / (double)Denominator;
                return decimalFraction.GetHashCode();
            }
        }

        public void Display()
        {
            Console.WriteLine($"Структура 'Fraction', {Numerator.ToString()}/{Denominator.ToString()}");
        }


        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            //приводим к общему знаменателю, равному перемножению исходных знаменателей дробей
            //затем складываем числители и сокращаем дробь
            var denominator = f1.Denominator * f2.Denominator;
            var firstTerm = new Fraction(f1.Numerator * f2.Denominator, denominator);
            var secondTerm = new Fraction(f2.Numerator * f1.Denominator, denominator);
            return Reduce(firstTerm.Numerator + secondTerm.Numerator, denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            //делаем вторую дробь отрицательной и используем реализованное сложение
            return f1 + new Fraction(-f2.Numerator, f2.Denominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            //перемножаем попарно числители и знаменатели, затем сокращаем дробь
            var numerator = f1.Numerator * f2.Numerator;
            var denominator = f1.Denominator * f2.Denominator;
            return Reduce(numerator, denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            //переворачиваем вторую дробь и используем реализованное умножение
            return f1 * new Fraction(f2.Denominator, f2.Numerator);
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            //используем реализованный метод Equals для сравнения
            return f1.Equals(f2);
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            //используем реализованный метод Equals для сравнения
            return !f1.Equals(f2);
        }

        private static Fraction Reduce(int numerator, int denominator)
        {
            //сокращаем дробь
            int gcd;
            do
            {
                //ищем НОД с помощью алгоритма Евклида
                gcd = GetGCD(numerator, denominator);
                if (gcd == 0)
                {
                    numerator = 0;
                    denominator = 0;
                    break;
                }
                numerator /= gcd;
                denominator /= gcd;
            } while (gcd != 1);
            return new Fraction()
            {
                Numerator = denominator < 0 ? -1 * numerator : numerator,
                Denominator = Math.Abs(denominator)
            };
        }

        //собственно сам алгоритм Евклида
        private static int GetGCD(int first, int second)
        {
            var gcd = first;
            var remainder = second;
            while (remainder != 0)
            {
                var temp = remainder;
                remainder = gcd % remainder;
                gcd = temp;
            }
            return gcd;
        }
    }
}