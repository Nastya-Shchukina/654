using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPharmacy
{
    public class Medicine
    {
        public readonly string Articul;
        public string Name;
        public MedicineRecept Recept;
        public string Maker;
        public double Price;
        public int Availibility;

        public Medicine(string articul, string name, MedicineRecept recept, string maker)
        {
            Articul = articul;
            Name = name;
            Recept = recept;
            Maker = maker;
        }

        public override string ToString()
        {
            return $"{Articul} {Name}";
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);

            var recept = "";
            switch (Recept)
            {
                case MedicineRecept.Yes:
                    recept = "Отпуск по рецепту";
                    break;
                case MedicineRecept.No:
                    recept = "Отпуск без рецепта";
                    break;
            }

            Console.WriteLine($"Производитель: {Maker}. Цена: {Price}. Количество на складе: {Availibility}.");
        }
    }
}
