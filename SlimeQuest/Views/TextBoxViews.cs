using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class TextBoxViews
    {
        public static void ClearInput()
        {
            Console.SetCursorPosition(4, 56);
            for (int i = 0; i < 145; i++)
            {
                Console.Write(" ");
            }
        }

        public static void ClearInputBox()
        {
            Console.SetCursorPosition(4, 56);
            for (int i = 0; i < 145; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(4, 57);
            for (int i = 0; i < 145; i++)
            {
                Console.Write(" ");
            }
        }

        public static void ClearTextBox()
        {
            Console.SetCursorPosition(6, 46);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 47);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 48);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 49);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 50);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 51);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(6, 52);
            for (int i = 0; i < 95; i++)
            {
                Console.Write(" ");
            }

        }

        public static void ErrorTextBox(string errorMessage)
        {
            Console.SetCursorPosition(4,58);
            Console.Write(errorMessage);
            Console.SetCursorPosition(4, 57);
            Console.Write("                                                    ");
        }
        
        public static void RemoveBox(Adventurer adventurer, int windowNumber)
        {
            Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XStart, adventurer.GameWindows[windowNumber].YStart);
            for (int i = adventurer.GameWindows[windowNumber].XStart; i <= adventurer.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write(" ");//Forward pointing double arrow
            }

            Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XStart, adventurer.GameWindows[windowNumber].YEnd);
            for (int i = adventurer.GameWindows[windowNumber].XStart; i <= adventurer.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write(" ");//Backward pointing double arrow
            }

            Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XStart, adventurer.GameWindows[windowNumber].YStart);
            for (int i = adventurer.GameWindows[windowNumber].YStart; i <= adventurer.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XStart, i);
                Console.Write(" ");//Fan UP 0488 circle 2021 double dagger (like fence)

            }

            Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XEnd, adventurer.GameWindows[windowNumber].YStart);
            for (int i = adventurer.GameWindows[windowNumber].YStart; i <= adventurer.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(adventurer.GameWindows[windowNumber].XEnd, i);
                Console.Write(" ");//Fan DOWN 

            }
        }

        public static Adventurer DevPlayer(Windows[] windows)
        {
            Adventurer adventurer = new Adventurer();

            adventurer.Name = "Winter";
            adventurer.Age = 18;
            adventurer.PlayerRace = Adventurer.Race.Slime;
            adventurer.PlayerWeapon = Adventurer.Weapon.Bow;
            adventurer.Health = 100;
            adventurer.MapLocation = Adventurer.Location.TutTown;
            adventurer.Xpos = 55;
            adventurer.Ypos = 26;

            adventurer.GameWindows = new Windows[6];
            adventurer.GameWindows = windows;
            return adventurer;
        }


        public static Adventurer GetPlayerInfo( Windows[] windows)
        {
            Adventurer adventurer = new Adventurer();

            ClearInputBox();
            Console.SetCursorPosition(6,46);
            Console.Write("Please enter your name young one.");
            Console.SetCursorPosition(4, 56);
            adventurer.Name = Console.ReadLine();
            ClearTextBox();

            Console.SetCursorPosition(6, 46);
            Console.Write("Please enter your age " + adventurer.Name);
            adventurer.Age = Validators.ValidInt();
            ClearTextBox();

            Console.SetCursorPosition(6, 46);
            Console.Write("What race are you?");
            Console.SetCursorPosition(6, 47);
            Console.Write(Adventurer.Race.Human);
            Console.SetCursorPosition(6, 48);
            Console.Write(Adventurer.Race.Slime);
            Console.SetCursorPosition(6, 49);
            Console.Write(Adventurer.Race.Elve);
            Console.SetCursorPosition(6, 50);
            Console.Write(Adventurer.Race.Orc);

            adventurer.PlayerRace = Validators.RaceValidation();
            ClearTextBox();


            Console.SetCursorPosition(6, 46);
            Console.Write("What Weapon will you use?");
            Console.SetCursorPosition(6, 47);
            Console.Write(Adventurer.Weapon.Bow);
            Console.SetCursorPosition(6, 48);
            Console.Write(Adventurer.Weapon.Sword);
            Console.SetCursorPosition(6, 49);
            Console.Write(Adventurer.Weapon.Staff);
            Console.SetCursorPosition(6, 50);
            Console.Write(Adventurer.Weapon.BroadSword);
            Console.SetCursorPosition(6, 51);
            Console.Write(Adventurer.Weapon.Dagger);
            Console.SetCursorPosition(6, 52);
            Console.Write(Adventurer.Weapon.Mace);
            adventurer.PlayerWeapon = Validators.WeaponValidation();
            ClearTextBox();
            adventurer.Health = 100;
            adventurer.MapLocation = Adventurer.Location.TutTown;
            adventurer.Xpos = 55;
            adventurer.Ypos = 26;

            adventurer.GameWindows = new Windows[6];
            adventurer.GameWindows = windows;
            return adventurer;
        }

        public static void DisplayPlayerInfo(Adventurer adventurer)
        {
            Console.SetCursorPosition(110,10);
            Console.Write("Name: " + adventurer.Name);
            Console.SetCursorPosition(110, 12);
            Console.Write("Age:" + adventurer.Age);
            Console.SetCursorPosition(110, 14);
            Console.Write("Race: " + adventurer.PlayerRace);
            Console.SetCursorPosition(110, 16);
            Console.Write("Certified weapon: " + adventurer.PlayerWeapon);
            Console.SetCursorPosition(110, 18);
            

        }

        public static void DisplayHeader()
        {
            Console.SetCursorPosition(70,2);
            Console.Write("Slime Game Beta");
        }
        public static void DisplayMenu()
        {
            Console.SetCursorPosition(110, 30);
            Console.Write("Navigate Using the NUMPAD");

            Console.SetCursorPosition(112,32);
            Console.Write("1. Close Game");
        }


















    }
}
