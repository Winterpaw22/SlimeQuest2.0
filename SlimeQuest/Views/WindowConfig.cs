using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{ 
    class WindowConfig
    {
        public static void NumbersOnScreen()
        {
            int xCounter = 0;
            //Console.WindowLeft = 150;
            //60
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                xCounter++;
                if (xCounter >= 10)
                {
                    Console.Write("|");
                    xCounter = 0;
                }
                else
                {
                    Console.Write(xCounter);

                }
            }
            xCounter = 0;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                
                if (xCounter >= 10)
                {
                    Console.Write("|");
                    xCounter = 0;
                }
                else
                {
                    Console.Write(xCounter);

                }
                xCounter++;
                Console.CursorTop = i;
                Console.CursorLeft = 0;
            }
        }


    }
}
