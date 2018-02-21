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
            windows[1] = windowTopStatus;

            Windows windowStatus = new Windows() { XStart = 106, YStart = 5, XEnd = 149, YEnd = 25 };
            windowCreator.CreateWindow(windowStatus);
            windows[2] = windowMoveBox;

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
            Windows[] windows = new Windows[6];

            Console.SetWindowSize(150, 60);
            WindowConfig.NumbersOnScreen();
            WindowConfig.SplashScreen();

            Console.ReadLine();

            windows = InitializeWindowScreens();
            Console.ReadLine();
            Console.Clear();
        }
    }
}
