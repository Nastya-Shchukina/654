using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryPharmacy;
using System.IO;

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
}
