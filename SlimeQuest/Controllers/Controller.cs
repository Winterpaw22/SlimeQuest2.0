using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;


namespace SlimeQuest
{
    class Controller
    {
        public static Windows[] InitializeWindowScreens()
        {
            Windows[] windows = new Windows[8];
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

            Windows eventBox = new Windows() { XStart = 1, YStart = 5, XEnd = 21, YEnd = 7 };
            windows[6] = eventBox;

            Windows nameBox = new Windows() { XStart = 6, YStart = 40, XEnd = 23, YEnd = 42 };
            windows[7] = nameBox;



            return windows;
        }
        public static void StartGame()
        {
            
            bool didjaWin;
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
            Universe universe = new Universe();
            universe = universe.InitializeUniverse(windows);

            TextBoxViews.WriteToMessageBox(universe, "After defeating the slime king peace was returned to the land. But not all peace lasts forever, and a group of bandits have set up camp in a nearby cave and it is your job to take them out...");

            Adventurer adventurer = new Adventurer();
            adventurer = TextBoxViews.GetPlayerInfo(universe);
            
            

            TextBoxViews.DisplayMenu(universe);
            didjaWin = GameLoop(adventurer,universe);
            

            TextBoxViews.RedrawBox(universe,5);
            if (adventurer.playerWin)
            {
                TextBoxViews.WriteToMessageBox(universe,"YOU WIN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else if (adventurer.diedOnFinal)
            {
                TextBoxViews.WriteToMessageBox(universe,"So close...");
            }
            TextBoxViews.WriteToMessageBox(universe,"Game Over");

        }
        //make a loop to hold player movement and other values
        public static bool GameLoop(Adventurer adventurer,Universe universe)
        {
            Random random = new Random();
            int encounter = 0;
            bool playing = true;
            bool win = false;
            TextBoxViews.DisplayPlayerInfo(adventurer);
            TextBoxViews.DisplayHeader();
            Console.CursorVisible = false;
            while (playing)
            {
                
                TextBoxViews.DisplayPosition(adventurer);
                playing = Map.movement(adventurer,universe);
                Map.CheckPosition(adventurer, universe);
                encounter = random.Next(1, 30);
                if (encounter < 2 && adventurer.MapLocation == Humanoid.Location.MainWorld)
                {
                    Slime slime = new Slime();
                    Slime.InitializeNewSlime(slime);
                    playing = Battle.BattleLoop(adventurer, universe, slime);
                }
                if (universe.TripleTrouble[0].Defeated && universe.TripleTrouble[1].Defeated && universe.TripleTrouble[2].Defeated)
                {
                    adventurer.playerWin = true;
                    playing = false;
                }
                if (adventurer.diedOnFinal)
                {
                    playing = false;
                }
            }
            return win;
        }
    }
}
