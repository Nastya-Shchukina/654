using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6___3
{
    class Program
    {
            static void Main()
        {
            Console.WriteLine("Введите позицию белой ладьи: ");
            string whiteRookPosition = Console.ReadLine();

            Console.WriteLine("Введите позицию черного слона: ");
            string blackBishopPosition = Console.ReadLine();

            if (CheckPosition(whiteRookPosition, blackBishopPosition))
            {
                Console.WriteLine("Введите ход белой ладьи: ");
                string whiteRookMove = Console.ReadLine();
                if (CanRookMakeSafeMove(whiteRookPosition, whiteRookMove, blackBishopPosition))
                    Console.WriteLine("Ладья может ходить");
                else
                    Console.WriteLine("Ладья не может ходить");
            }
            else
                Console.WriteLine("Позиции введены некорректно");

            Console.ReadKey();
         }

        static void GetCoordinates(string position, out int x, out int y)
        {
            x = (int)position[0] - 0x60;
            y = int.Parse("" + position[1].ToString());
        }

        static bool CanRookMakeMove(string start, string end)
        {
            if (start == end)
                return false;

            int startX, startY, endX, endY;
            GetCoordinates(start, out startX, out startY);
            GetCoordinates(end, out endX, out endY);

            return (startX == endX || startY == endY) && start != end;
        }

        static bool CanBishopMakeMove(string start, string end)
        {
            if (start == end)
                return false;

            int startX, startY, endX, endY;
            GetCoordinates(start, out startX, out startY);
            GetCoordinates(end, out endX, out endY);

            return Math.Abs(endX - startX) == Math.Abs(endY - startY);
        }

        static bool CheckPosition(string whitePos, string blackPos)
        {
            return whitePos != blackPos && !CanRookMakeMove(whitePos, blackPos) && !CanBishopMakeMove(blackPos, whitePos);
        }

        static bool CanRookMakeSafeMove(string rookStartPos, string rookEndPos, string bishopPos)
        {
            return CanRookMakeMove(rookStartPos, rookEndPos) && !CanBishopMakeMove(bishopPos, rookEndPos);
        }
    }

}

