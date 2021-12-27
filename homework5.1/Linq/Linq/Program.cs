using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public static class Second
    {
        public struct Record
        {
            public int ClientID;
            public int Year;
            public int Month;
            public int Duration;
        }

        public static void Main()
        {
            var dataBae = FillDataBase();
            var clientsMostYear = dataBae
                .GroupBy(x => x.ClientID)
                .Select(x => x
                    .GroupBy(y => y.Year)
                    .Select(y => (y, y
                        .Select(z => z.Duration)
                        .Sum()))
                    .OrderByDescending(y => y.Item2)
                    .First())
                .OrderBy(x => x.y.First().ClientID)
                .Select(x => $"ClientId {x.y.First().ClientID} Year {x.y.Key} Duration {x.Item2}")
                .ToArray();
            var result = string.Join("\n", clientsMostYear);
            Console.WriteLine(result);
        }

        public static List<Record> FillDataBase()
        {
            Console.WriteLine("Введите кол-во клиентов");
            var count = int.Parse(Console.ReadLine());
            return Enumerable
                .Range(0, count)
                .Select(_ =>
                {
                    Console.WriteLine("Введите данные о пользователе в формате {ClientId Year Month Duration}");
                    var line = Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray();
                    return new Record
                    {
                        ClientID = line[0],
                        Year = line[1],
                        Month = line[2],
                        Duration = line[3]
                    };
                })
                .ToList();
        }
    }
}
