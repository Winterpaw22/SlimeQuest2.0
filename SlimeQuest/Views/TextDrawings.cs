using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class TextDrawings
    {
        static public void DisplaySlime(Slime slime)
        {
            Console.ForegroundColor = slime.Color;
            Console.SetCursorPosition(35, 16);
            Console.Write("                      =======                             ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                  ====       ====                         ");
            Console.SetCursorPosition(35, 18);
            Console.Write("               ===              ===                       ");
            Console.SetCursorPosition(35, 19);
            Console.Write("             ==     v       v     ==                      ");
            Console.SetCursorPosition(35, 20);
            Console.Write("           ===     (6)     (9)     ===                    ");
            Console.SetCursorPosition(35, 21);
            Console.Write("          ===       ^       ^       ===                   ");
            Console.SetCursorPosition(35, 22);
            Console.Write("         ====                       ====                  ");
            Console.SetCursorPosition(35, 23);
            Console.Write("          ===                       ===                   ");
            Console.SetCursorPosition(35, 24);
            Console.Write("            ====-               -====                     ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                 ==============                           ");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        static public void DisplayFountain(int xStart, int yStart)
        {
            //Building the base box for the fountain Start

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = xStart + 5; i < xStart + 10; i++)
            {
                Console.SetCursorPosition(i,yStart + 1);
                Console.Write("_");
            }
            
            for (int i = xStart + 5; i < xStart + 10; i++)
            {
                Console.SetCursorPosition(i, yStart + 6);
                Console.Write("_");
            }

            Console.SetCursorPosition(xStart + 2, yStart + 4);
            Console.Write("|");
            Console.SetCursorPosition(xStart + 12, yStart + 4);
            Console.Write("|");

            //Base Box End




            Console.SetCursorPosition(xStart + 3, yStart + 2);
            Console.Write("_");
            Console.SetCursorPosition(xStart + 11, yStart + 2);
            Console.Write("_");
            Console.SetCursorPosition(xStart + 3, yStart + 5);
            Console.Write("_");
            Console.SetCursorPosition(xStart + 11, yStart + 5);
            Console.Write("_");

            Console.SetCursorPosition(xStart + 4, yStart + 2);
            Console.Write("/");
            Console.SetCursorPosition(xStart + 2, yStart + 3);
            Console.Write("/");
            Console.SetCursorPosition(xStart + 10, yStart + 6);
            Console.Write("/");
            Console.SetCursorPosition(xStart + 12, yStart + 5);
            Console.Write("/");

            Console.SetCursorPosition(xStart + 10, yStart + 2);
            Console.Write("\\");
            Console.SetCursorPosition(xStart + 12, yStart + 3);
            Console.Write("\\");
            Console.SetCursorPosition(xStart + 2, yStart + 5);
            Console.Write("\\");
            Console.SetCursorPosition(xStart + 4, yStart + 6);
            Console.Write("\\");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(xStart + 7, yStart + 3);
            Console.Write("o");
            Console.SetCursorPosition(xStart + 5, yStart + 4);
            Console.Write("o");
            Console.SetCursorPosition(xStart + 7, yStart + 5);
            Console.Write("o");
            Console.SetCursorPosition(xStart + 9, yStart + 4);
            Console.Write("o");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(xStart + 7, yStart + 4);
            Console.Write("@");

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
