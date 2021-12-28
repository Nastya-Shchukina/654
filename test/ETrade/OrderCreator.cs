using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade
{
    public class OrderCreator
    {
        public Order Create(int id, string record)
        {
            // Реализовать метод так, чтобы из строки в формате
            // категория, название, цена, количество (в этом порядке), разделенные табуляцией

            var objects = record.Split('\t')
                    .Where(x => !string.IsNullOrEmpty(x))
                    //.Select(x => Tuple.Create(x[0], x[1]))
                    .ToArray();

            int idn = id;
            var com = new Comodity(objects[0].ToString(), objects[1].ToString(), int.Parse(objects[2].ToString()));
            int quantity = int.Parse(objects[3].ToString());
            Order ord = new Order(idn, com, quantity);

            return ord;
            //throw new NotImplementedException(idn, );
        }
    }
}
