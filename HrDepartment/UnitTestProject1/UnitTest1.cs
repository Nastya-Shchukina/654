using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryPharmacy;
using System.IO;
using static ClassLibraryPharmacy.Medicine;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var paracetomol = CreateTestMedicine();

            Assert.AreEqual("X372L", paracetomol.Articul);
            Assert.AreEqual("Paracetomol", paracetomol.Name);
            Assert.AreEqual(MedicineRecept.No, paracetomol.Recept);
            Assert.AreEqual("Renewal", paracetomol.Maker);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var paracetomol = CreateTestMedicine();
            Assert.AreEqual("X372L Paracetomol", paracetomol.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var paracetomol = CreateTestMedicine();
            var omega = new Medicine("D993P", "Omega", MedicineRecept.Yes, "Solgar");

            var consoleOut = new[]
            {

            "X372L Paracetomol",
            $"Производитель: Renewal. Цена: 31. Количество на складе: 238.",
            "D993P Omega",
            $"Производитель: Solgar. Цена: 1200. Количество на складе: 24."

            };

            paracetomol.Price = 31;
            paracetomol.Availibility = 238;
            omega.Price = 1200;
            omega.Availibility = 24;

            TextWriter oldOut = Console.Out;
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            paracetomol.PrintInfo();
            omega.PrintInfo();

            Console.SetOut(oldOut);

            var outputArray = output.ToString().Split(new[] { "\r\n" },
            StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(4, outputArray.Length);
            for (var i = 0; i < consoleOut.Length; i++)
                Assert.AreEqual(consoleOut[i], outputArray[i]);
        }

        private Medicine CreateTestMedicine()
        {
            return new Medicine("X372L", "Paracetomol", MedicineRecept.No, "Renewal");
        }

    }

    [TestClass]
    public class PillsUnitTest
    {
        [TestMethod]
        public void ConstructorPTestMethod1()
        {
            var paracetomol = GetTestPills();

            Assert.AreEqual(30, paracetomol.Piece);
        }


        [TestMethod]
        public void PrintInfoPTestMethod()
        {
            var paracetomol = GetTestPills();
            var lines = new[]
            {
            "X372L Paracetomol",
            "Производитель: Renewal. Цена: 31. Количество на складе: 238.",
            "Таблетки 30 шт. в упаковке"

            };
            paracetomol.Price = 31;
            paracetomol.Availibility = 238;

            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    paracetomol.PrintInfo();
                }
            }

            Console.SetOut(oldOut);

            using (FileStream file = new FileStream("test.txt", FileMode.Open))
            {
                using (TextReader reader = new StreamReader(file))
                {
                    var i = 0;

                    while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());

                    Assert.AreEqual(lines.Length, i);
                }
            }

            File.Delete("test.txt");
        }

        private Pills GetTestPills()
        {
            var pill = new Pills("X372L", "Paracetomol", MedicineRecept.No, "Renewal", 30);
            return pill;
        }
    }

    [TestClass]
    public class MixtureUnitTest
    {
        [TestMethod]
        public void ConstructorMTestMethod1()
        {
            var pavlovi = GetTestMixture();

            Assert.AreEqual(20, pavlovi.Piece);
        }


        [TestMethod]
        public void PrintInfoMTestMethod()
        {
            var pavlovi = GetTestMixture();
            var lines = new[]
            {

            "K893OL Павлова",
            "Производитель: TerraPharm. Цена: 149. Количество на складе: 53.",
            "Микстура 20 мл в бутылке"

            };

            pavlovi.Price = 149;
            pavlovi.Availibility = 53;

            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    pavlovi.PrintInfo();
                }
            }

            Console.SetOut(oldOut);

            using (FileStream file = new FileStream("test.txt", FileMode.Open))
            {
                using (TextReader reader = new StreamReader(file))
                {
                    var i = 0;

                    while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());

                    Assert.AreEqual(lines.Length, i);
                }
            }

            File.Delete("test.txt");
        }

        private Mixture GetTestMixture()
        {
            var mixture = new Mixture("K893OL", "Павлова", MedicineRecept.Yes, "TerraPharm", 20);
            return mixture;
        }
    }

    [TestClass]
    public class OintmentUnitTest
    {
        [TestMethod]
        public void ConstructorOTestMethod1()
        {
            var fucidin = GetTestOintment();

            Assert.AreEqual(5, fucidin.Piece);
        }


        [TestMethod]
        public void PrintInfoMTestMethod()
        {
            var fucidin= GetTestOintment();
            var lines = new[]
            {

            "23P33 Fucidin",
            "Производитель: PharmProduc. Цена: 410. Количество на складе: 15.",
            "Мазь 5 мг в тубе"

            };

            fucidin.Price = 410;
            fucidin.Availibility = 15;

            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    fucidin.PrintInfo();
                }
            }

            Console.SetOut(oldOut);

            using (FileStream file = new FileStream("test.txt", FileMode.Open))
            {
                using (TextReader reader = new StreamReader(file))
                {
                    var i = 0;

                    while (!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());

                    Assert.AreEqual(lines.Length, i);
                }
            }

            File.Delete("test.txt");
        }

        private Ointment GetTestOintment()
        {
            var ointment = new Ointment("23P33", "Fucidin", MedicineRecept.Yes, "PharmProduc", 5);
            return ointment;
        }
    }
}
