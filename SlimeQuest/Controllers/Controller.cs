using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SlimeQuest
{
    class Controller
    {
        public static Windows[] InitializeWindowScreens()
        {
            Windows[] windows = new Windows[6];
            Windows windowTopStatus = new Windows() { XStart = 1, YStart = 1, XEnd = 149, YEnd = 4 };
            windowCreator.CreateWindow(windowTopStatus);
            windows[0] = windowTopStatus;

            Windows windowMoveBox = new Windows() { XStart = 1, YStart = 5, XEnd = 105, YEnd = 54 };
            windowCreator.CreateWindow(windowMoveBox);
            windows[1] = windowMoveBox;

            Windows windowStatus = new Windows() { XStart = 106, YStart = 5, XEnd = 149, YEnd = 25 };
            windowCreator.CreateWindow(windowStatus);
            windows[2] = windowStatus;

            Windows windowMenuInventory = new Windows() { XStart = 106, YStart = 26, XEnd = 149, YEnd = 54 };
            windowCreator.CreateWindow(windowMenuInventory);
            windows[3] = windowMenuInventory;

            Windows InputWindow = new Windows() { XStart = 1, YStart =55, XEnd = 149, YEnd = 58 };
            windowCreator.CreateWindow(InputWindow);
            windows[4] = InputWindow;

            Windows windowTextBox = new Windows() { XStart = 3, YStart = 43, XEnd = 103, YEnd = 53 };
            windowCreator.CreateWindow(windowTextBox);
            windows[5] = windowTextBox;


            return windows;
        }
        public static void StartGame()
        {
            Console.CursorVisible = false;
            Windows[] windows = new Windows[6];

            Console.SetWindowSize(150, 60);
            //WindowConfig.NumbersOnScreen();
            WindowConfig.SplashScreen();

            Console.ReadLine();
            Console.Clear();
            windows = InitializeWindowScreens();
            Console.SetCursorPosition(6,46);
            Console.Write("Some slimes have gotten out of control and it");
            Console.SetCursorPosition(6, 47);
            Console.Write("is your job to take care of them");

            Console.ReadLine();
            TextBoxViews.ClearTextBox();

            Adventurer adventurer = new Adventurer();
            adventurer= TextBoxViews.GetPlayerInfo(windows);
            TextBoxViews.DisplayMenu();
            GameLoop(adventurer);
            Console.SetCursorPosition(6, 46);
            Console.Write("You failed your race.");
        }
        //make a loop to hold player movement and other values
        public static void GameLoop(Adventurer adventurer)
        {
            bool playing = true;
            bool returning = true;
            TextBoxViews.DisplayPlayerInfo(adventurer);

            while (playing)
            {
                if (returning)
                {
                    Console.CursorVisible = false;
                    TextBoxViews.DisplayPlayerInfo(adventurer);
                    TextBoxViews.RemoveBox(adventurer, 5);
                    returning = false;
                }

                playing = Map.movement(adventurer);
                Map.CheckPosition(adventurer);
            }
        }
    }
}
