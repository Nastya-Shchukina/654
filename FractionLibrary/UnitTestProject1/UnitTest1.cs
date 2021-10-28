using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionLibrary;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fraction = CreateTestFraction();
            Assert.AreEqual(2, fraction.Numerator);
            Assert.AreEqual(5, fraction.Denominator);
            Assert.AreEqual(2 / 5, fraction.IntPart);

        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var fraction = CreateTestFraction();
            Assert.AreEqual("2/5", fraction.ToString());
        }

        [TestMethod]
        public void DisplayTestMethod()
        {
            var fraction = CreateTestFraction();
            var fraction1 = new Fraction(3, 8);

            var consoleOut = new[]
            {
                "Структура 'Fraction', 2/5",
                "Структура 'Fraction', 3/8"
            };

            TextWriter oldOut = Console.Out;

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            fraction.Display();
            fraction1.Display();

            Console.SetOut(oldOut);

            var outputArray = output.ToString().Split(new[] { "\r\n" },
            StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(2, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);

        }

        [TestMethod]
        public void EqualsTestMethod()
        {
            Fraction f1 = new Fraction(2, 5);
            Fraction f2 = new Fraction(2, 5);

            Assert.AreEqual(true, f1.Equals(f2));
        }

        [TestMethod]
        public void PlusTestMethod()
        {
            Fraction f1 = new Fraction(2, 5);
            Fraction f2 = new Fraction(1, 7);

            var f3 = f1 + f2;

            Assert.AreEqual("19/35", f3.ToString());
        }

        [TestMethod]
        public void MinusTestMethod()
        {
            Fraction f1 = new Fraction(6, 12);
            Fraction f2 = new Fraction(2, 5);

            var f3 = f1 - f2;

            Assert.AreEqual("1/10", f3.ToString());
        }

        [TestMethod]
        public void MultiplyTestMethod()
        {
            Fraction f1 = new Fraction(2, 5);
            Fraction f2 = new Fraction(5, 7);

            var f3 = f1 * f2;

            Assert.AreEqual("2/7", f3.ToString());
        }

        [TestMethod]
        public void DivisionTestMethod()
        {
            Fraction f1 = new Fraction(3, 4);
            Fraction f2 = new Fraction(9, 8);

            var f3 = f1 / f2;

            Assert.AreEqual("2/3", f3.ToString());
        }

        [TestMethod]
        public void CompareTestMethod()
        {
            Fraction f1 = new Fraction(10, 4);
            Fraction f2 = new Fraction(5, 2);

            var f3 = f1 == f2;

            Assert.AreEqual("True", f3.ToString());

            Fraction f4 = new Fraction(5, 2);
            Fraction f5 = new Fraction(8, 9);

            var f6 = f4 != f5;

            Assert.AreEqual("True", f6.ToString());
        }


        private Fraction CreateTestFraction()
        {
            return new Fraction(2, 5);
        }

    }
}