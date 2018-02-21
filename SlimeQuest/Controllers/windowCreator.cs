using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class windowCreator
    {
        public static void CreateWindow(Windows window)
        {
            Console.SetCursorPosition(window.XStart, window.YStart);
            for (int i = window.XStart; i <= window.XEnd; i++)
            {
                Console.Write("=");//Forward pointing double arrow
            }

            Console.SetCursorPosition(window.XStart, window.YEnd);
            for (int i = window.XStart; i <= window.XEnd; i++)
            {
                Console.Write("=");//Backward pointing double arrow
            }

            Console.SetCursorPosition(window.XStart, window.YStart);
            for (int i = window.YStart; i <= window.YEnd; i++)
            {
                Console.SetCursorPosition(window.XStart, i);
                Console.Write("|");//Fan UP 0488 circle 2021 double dagger (like fence)
                
            }

            Console.SetCursorPosition(window.XEnd, window.YStart);
            for (int i = window.YStart; i <= window.YEnd; i++)
            {
                Console.SetCursorPosition(window.XEnd, i);
                Console.Write("|");//Fan DOWN 
                
            }
        }
    }
}
