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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(150, 60);
            //WindowConfig.NumbersOnScreen();
            TextBoxViews.SplashScreen(40, 25);

            Console.ReadLine();
            Console.Clear();
            windows = InitializeWindowScreens();
            Console.SetCursorPosition(6,46);
            Console.Write("Some slimes have gotten out of control and it");
            Console.SetCursorPosition(6, 47);
            Console.Write("is your job to take care of them");

            Console.ReadKey();
            TextBoxViews.ClearTextBox();

            Adventurer adventurer = new Adventurer();
            adventurer = TextBoxViews.DevPlayer();

            Universe universe = new Universe();
            universe = universe.InitializeUniverse(windows);

            TextBoxViews.DisplayMenu();
            GameLoop(adventurer,universe);
            
            TextBoxViews.RedrawBox(universe,5);
            Console.SetCursorPosition(6, 46);
            Console.Write("You failed your race.");
            Console.ReadKey();
        }
        //make a loop to hold player movement and other values
        public static void GameLoop(Adventurer adventurer,Universe universe)
        {
            bool playing = true;
            bool returning = true;
            TextBoxViews.DisplayPlayerInfo(adventurer);
            TextBoxViews.DisplayHeader();
            while (playing)
            {
                if (returning)
                {
                    Console.CursorVisible = false;
                    TextBoxViews.DisplayPlayerInfo(adventurer);
                    TextBoxViews.RemoveBox(universe, 5);
                    returning = false;
                }
                TextBoxViews.DisplayPosition(adventurer);
                playing = Map.movement(adventurer,universe);
                Map.CheckPosition(adventurer, universe);
            }
        }
    }
}
