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

        public virtual void PrintInfo()
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

        public class Pills : Medicine
        {
            public int Piece;
            public Pills(string articul, string name, MedicineRecept recept, string maker, int piece) : 
                base(articul,name, recept, maker)
            {
                Piece = piece;
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Таблетки {Piece} шт. в упаковке");
            }
        }

        public class Mixture : Medicine
        {
            public int Piece;
            public Mixture(string articul, string name, MedicineRecept recept, string maker, int piece) : 
                base(articul, name, recept, maker)
            {
                Piece = piece;
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Микстура {Piece} мл в бутылке");
            }
        }

        public class Ointment : Medicine
        {
            public int Piece;
            public Ointment(string articul, string name, MedicineRecept recept, string maker, int piece) :
                base(articul, name, recept, maker)
            {
                Piece = piece;
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Мазь {Piece} мг в тубе");
            }
        }
    }
}
