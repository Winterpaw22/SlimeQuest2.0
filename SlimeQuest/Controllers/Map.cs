using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{ 
    class Map
    {
        public static void CheckPosition(Adventurer player)
        {
            int[] lastPosition = new int[2];

            lastPosition[0] = player.Xpos;
            lastPosition[1] = player.Ypos;
            
            
            
            

            if (player.Ypos == 26 && player.Xpos == 50)
            {
                Console.SetCursorPosition(110,24);
                Console.Write("Completed Quest");
            }

        }
        public static bool movement(Adventurer player)
        {
            ConsoleKeyInfo keyPress;
            keyPress = Console.ReadKey();
            bool playing = true;
            int[] lastPosition = new int[2];

            lastPosition[0] = player.Xpos;
            lastPosition[1] = player.Ypos;

            Console.SetCursorPosition(lastPosition[0], lastPosition[1]);
            Console.Write(" ");

            if (keyPress.Key == ConsoleKey.LeftArrow)
            {
                if (!(player.Xpos < 3))
                {
                    player.Xpos--;
                }
                Console.SetCursorPosition(player.Xpos, player.Ypos);
                Console.Write("☺");
                //player.Looking = Players.LookingDirection.LEFT;
            }
            else if (keyPress.Key == ConsoleKey.RightArrow)
            {
                if (!(player.Xpos > 105))
                {
                    player.Xpos++;
                }

                Console.SetCursorPosition(player.Xpos, player.Ypos);
                Console.Write("☺");
                //player.Looking = Players.LookingDirection.RIGHT;
            }
            else if (keyPress.Key == ConsoleKey.UpArrow)
            {
                if (!(player.Ypos < 7))
                {
                    player.Ypos--;
                }
                Console.SetCursorPosition(player.Xpos, player.Ypos);
                Console.Write("☺");
                //player.Looking = Players.LookingDirection.UP;
            }
            else if (keyPress.Key == ConsoleKey.DownArrow)
            {
                if (!(player.Ypos > 52))
                {
                    player.Ypos++;
                }
                Console.SetCursorPosition(player.Xpos, player.Ypos);
                Console.Write("☺");
                //player.Looking = Players.LookingDirection.DOWN;
            }
            else if (keyPress.Key == ConsoleKey.DownArrow)
            {
                if (!(player.Ypos > 52))
                {
                    player.Ypos++;
                }
                Console.SetCursorPosition(player.Xpos, player.Ypos);
                Console.Write("☺");
                //player.Looking = Players.LookingDirection.DOWN;
            }
            else if (keyPress.Key == ConsoleKey.NumPad1)
            {
                playing = false;

            }
            //if (keyPress.Key == ConsoleKey.Spacebar)
            //{
            //    switch (player.Looking)
            //    {
            //        case Players.LookingDirection.UP:
            //            Console.SetCursorPosition(player.Xpos, player.Ypos);
            //            Console.Write("☺");
            //            Console.CursorTop--;
            //            Console.Write("/");
            //            System.Threading.Thread.Sleep(300);
            //            Console.CursorLeft--;
            //            Console.Write(" ");
            //            Console.CursorLeft--;
            //            Console.CursorLeft--;
            //            Console.Write("|");
            //            System.Threading.Thread.Sleep(300);
            //            Console.CursorLeft--;
            //            Console.Write(" ");
            //            Console.CursorLeft--;
            //            Console.CursorLeft--;
            //            Console.Write("\\");
            //            System.Threading.Thread.Sleep(300);
            //            Console.CursorLeft--;
            //            Console.Write(" ");
            //            break;
            //        case Players.LookingDirection.DOWN:
            //            break;
            //        case Players.LookingDirection.LEFT:
            //            break;
            //        case Players.LookingDirection.RIGHT:
            //            break;
            //        default:
            //            break;
            //    }
            //}


            return playing;

        }
    }
}
