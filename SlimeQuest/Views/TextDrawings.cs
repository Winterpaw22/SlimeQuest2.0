using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class TextDrawings
    {
        static public void DisplaySlime()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
    }
}
