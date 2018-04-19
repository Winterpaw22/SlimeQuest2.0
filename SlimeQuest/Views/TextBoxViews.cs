﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SlimeQuest
{
    class TextBoxViews
    {

        #region TextBoxWindows
        /// <summary>
        /// Clears input
        /// </summary>
        public static void ClearInput()
        {
            Console.SetCursorPosition(4, 56);
            for (int i = 0; i < 145; i++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Clears the input box
        /// </summary>
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

        /// <summary>
        /// Blips the cursor in the bottom right of the textbox
        /// </summary>
        public static void TextboxCursorBlink()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(100,51);
            Console.ReadKey();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Removes the textbox
        /// </summary>
        public static void ClearTextBox()
        {
            for (int x = 46; x < 53; x++)
            {
                Console.SetCursorPosition(6, x);
                for (int i = 0; i < 95; i++)
                {
                    Console.Write(" ");
                }

            }

        }

        /// <summary>
        /// Clears the map screen of all map items including player
        /// </summary>
        public static void ClearMapBox()
        {
            for (int i = 6; i < 54; i++)
            {
                Console.SetCursorPosition(2,i);
                for (int x = 2; x <= 104; x++)
                {
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Sends an error message if you do something wrong when validating
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void ErrorTextBox(string errorMessage)
        {
            Console.SetCursorPosition(4,58);
            Console.Write(errorMessage);
            Console.SetCursorPosition(4, 57);
            Console.Write("                                                    ");
        }
        
        /// <summary>
        /// Clears the Error Message
        /// </summary>
        public static void ClearErrorTextBox()
        {
            Console.SetCursorPosition(1, 58);
            Console.Write("========================================================================================");
        }

        /// <summary>
        /// Removes a selected box
        /// </summary>
        /// <param name="universe"> holds the...Windows??? Note: Change to universe later</param>
        /// <param name="windowNumber">Numbers can be found in WindowBox.txt file</param>
        public static void RemoveBox(Universe universe, int windowNumber)
        {
            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].XStart; i <= universe.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write(" ");//Forward pointing double arrow
            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YEnd);
            for (int i = universe.GameWindows[windowNumber].XStart; i <= universe.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write(" ");//Backward pointing double arrow
            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].YStart; i <= universe.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, i);
                Console.Write(" ");//Fan UP 0488 circle 2021 double dagger (like fence)

            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XEnd, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].YStart; i <= universe.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(universe.GameWindows[windowNumber].XEnd, i);
                Console.Write(" ");//Fan DOWN 

            }
        }


        /// <summary>
        /// Removes a selected box
        /// </summary>
        /// <param name="universe"> holds the...Windows??? Note: Change to universe later</param>
        /// <param name="windowNumber">Numbers can be found in WindowBox.txt file</param>
        public static void RemoveContent(Universe universe, int windowNumber)
        {

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart + 1, universe.GameWindows[windowNumber].YStart + 1);
            for (int y = universe.GameWindows[windowNumber].YStart + 1; y <= universe.GameWindows[windowNumber].YEnd - 1; y++)
            {
                Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart + 1,y);
                for (int i = universe.GameWindows[windowNumber].XStart + 1; i <= universe.GameWindows[windowNumber].XEnd - 1; i++)
                {
                    Console.Write(" ");//Forward pointing double arrow
                }

            }
            
        }


        /// <summary>
        /// Redraws a selected box
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="windowNumber">Numbers can be found in WindowBox.txt file</param>
        public static void RedrawBox(Universe universe, int windowNumber)
        {
            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].XStart; i <= universe.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write("=");//Forward pointing double arrow
            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YEnd);
            for (int i = universe.GameWindows[windowNumber].XStart; i <= universe.GameWindows[windowNumber].XEnd; i++)
            {
                Console.Write("=");//Backward pointing double arrow
            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].YStart; i <= universe.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(universe.GameWindows[windowNumber].XStart, i);
                if (i == universe.GameWindows[windowNumber].YStart || i== universe.GameWindows[windowNumber].YEnd)
                {
                    Console.Write("+");//Fan UP 0488 circle 2021 double dagger (like fence)
                }
                else
                {
                    Console.Write("|");
                }

            }

            Console.SetCursorPosition(universe.GameWindows[windowNumber].XEnd, universe.GameWindows[windowNumber].YStart);
            for (int i = universe.GameWindows[windowNumber].YStart; i <= universe.GameWindows[windowNumber].YEnd; i++)
            {
                Console.SetCursorPosition(universe.GameWindows[windowNumber].XEnd, i);
                if (i == universe.GameWindows[windowNumber].YStart || i == universe.GameWindows[windowNumber].YEnd)
                {
                    Console.Write("+");//Fan DOWN 
                }
                else
                {
                    Console.Write("|");
                }
            }
        }
        #endregion

        #region Initializers
        public static Adventurer DevPlayer()
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
            adventurer.InaHouse = false;
            adventurer.InHouseName = House.houseName.None;
            adventurer.QuestCompletion = Adventurer.InstantiateQuests();
            adventurer.InventoryPageNumber = 0;
            adventurer.Coins = 9000000;
            adventurer.PlayerItemsDictionary = Adventurer.InstantiateInventory();

            adventurer.PreviousLocations = new List<Humanoid.Location> { Humanoid.Location.TutTown };
            adventurer.QuestDone = Adventurer.InstantiateQuestCompletionMessageCheck();

            return adventurer;
        }
        public static Adventurer GetPlayerInfo()
        {
            Adventurer adventurer = new Adventurer();

            ClearInputBox();
            Console.SetCursorPosition(6,46);
            Console.Write("Please enter your name young one.");
            Console.SetCursorPosition(4, 56);
            adventurer.Name = Console.ReadLine();
            ClearTextBox();
            ClearErrorTextBox();


            Console.SetCursorPosition(6, 46);
            Console.Write("Please enter your age " + adventurer.Name);
            adventurer.Age = Validators.ValidInt();
            ClearTextBox();
            ClearErrorTextBox();


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
            ClearErrorTextBox();

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
            ClearErrorTextBox();


            adventurer.Health = 100;
            adventurer.MapLocation = Adventurer.Location.TutTown;
            adventurer.Xpos = 55;
            adventurer.Ypos = 26;
            adventurer.InaHouse = false;
            adventurer.InHouseName = House.houseName.None;

            adventurer.QuestCompletion = Adventurer.InstantiateQuests();

            adventurer.PreviousLocations = new List<Humanoid.Location> { Humanoid.Location.TutTown };

            adventurer.InventoryPageNumber = 0;
            adventurer.Coins = 20;
            adventurer.PlayerItemsDictionary = Adventurer.InstantiateInventory();

            return adventurer;
        }
        #endregion



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
            Console.Write("Coins: " + adventurer.Coins + "          ");
        }

        /// <summary>
        /// Displays the Header
        /// </summary>
        public static void DisplayHeader()
        {
            Console.SetCursorPosition(70,2);
            Console.Write("Slime Game Beta");
        }

        /// <summary>
        /// Displays the Menu that is Controlled using the Numpad
        /// </summary>
        public static void DisplayMenu(Universe universe)
        {
            RemoveContent(universe, 3);
            Console.SetCursorPosition(110, 30);
            Console.Write("Navigate menu using the NUMPAD");

            Console.SetCursorPosition(112,32);
            Console.Write("1. Talk");
            Console.SetCursorPosition(112, 33);
            Console.Write("2. Look around");
            Console.SetCursorPosition(112, 34);
            Console.Write("3. Locations");
            Console.SetCursorPosition(112, 35);
            Console.Write("4.Inventory");

            Console.SetCursorPosition(112, 40);
            Console.Write("9. Close Game");
        }

        public static void MerchMenu(Universe universe)
        {
            RemoveContent(universe, 3);
            Console.SetCursorPosition(110, 30);
            Console.Write("Navigate using the NUMPAD");

            Console.SetCursorPosition(112, 32);
            Console.Write("1. Health Potioin = 20 Coins");
            Console.SetCursorPosition(112, 33);
            Console.Write("2. Mana Potion = 20 Coins");
            Console.SetCursorPosition(112, 34);
            Console.Write("3. Stone");

            Console.SetCursorPosition(112, 40);
            Console.Write("9. Stop Shopping");
        }

        /// <summary>
        /// Displays the Inventory that is Controlled using the Numpad
        /// </summary>
        public static void DisplayInventory(Dictionary<Item.Items,int> itemList)
        {
            Console.SetCursorPosition(110, 30);
            Console.Write("Navigate Inventory using the NUMPAD");

            int invYlvl = 32;
            int itmNo = 1;
            foreach (var item in itemList)
            {
                Console.SetCursorPosition(112, invYlvl);
                Console.Write(itmNo + ". " + item.Key + " : " + item.Value.ToString());
                invYlvl++;
                itmNo++;
            }
            

            Console.SetCursorPosition(112, 43);
            Console.Write("9. Close Inventory");
        }

        /// <summary>
        /// Possibly Remove Later
        /// </summary>
        /// <param name="itemList"></param>
        public static void DisplayMerchantWares(List<Item.Items> itemList)
        {
            Console.SetCursorPosition(110, 30);
            Console.Write("Navigate Inventory using the NUMPAD");

            int invYlvl = 32;
            int itmNo = 1;
            foreach (var item in itemList)
            {
                Console.SetCursorPosition(112, invYlvl);
                Console.Write(itmNo + ". " + item);
                invYlvl++;
                itmNo++;
            }
        }

        /// <summary>
        /// Displays the Splashscreen
        /// </summary>
        /// <param name="xStart">X position for start</param>
        /// <param name="yStart">Y position for start</param>
        public static void SplashScreen(int xStart, int yStart)
        {
            Console.SetCursorPosition(xStart,yStart);
            Console.Write(" __         _____   ___ ___    ____     ____            ____    __   ______");
            yStart++;
            Console.SetCursorPosition(xStart, yStart);
            Console.Write("/  \\  |       |    |   |   |  |        |    |  |    |  |       /  \\     |");
            yStart++;
            Console.SetCursorPosition(xStart, yStart);
            Console.Write("\\__   |       |    |   |   |  |__      |    |  |    |  | __    \\__      |");
            yStart++;
            Console.SetCursorPosition(xStart, yStart);
            Console.Write("   \\  |       |    |       |  |        |  \\ |  |    |  |          \\     |");
            yStart++;
            Console.SetCursorPosition(xStart, yStart);
            Console.Write("\\__/  |___  __|__  |       |  |____    |___\\|  |____|  |____   \\__/     |");
        }

        public static void DisplayPosition( Adventurer adventurer)
        {
            Console.SetCursorPosition(110, 20);
            Console.Write( "X: " + adventurer.Xpos);
            Console.SetCursorPosition(110, 21);
            Console.Write( "Y: " + adventurer.Ypos);
        }
        /// <summary>
        /// Displays your current quest
        /// </summary>
        /// <param name="quest"></param>
        public static void DisplayQuest(string quest)
        {
            Console.SetCursorPosition(110, 22);
            Console.Write("                            ");
            Console.SetCursorPosition(110, 22);
            Console.Write(quest);
        }
        public static void DisplayTownDesc(Universe universe)
        {

            List<string> message = MessageBoxWordWrap(universe.ReturnTownDescription(universe),87);
            RedrawBox(universe,5);
            int position = 46;
            foreach (string strins in message)
            {
                Console.SetCursorPosition(6, position);
                Console.Write(strins);
                position++;
            }


            TextboxCursorBlink();
            ClearTextBox();
            RemoveBox(universe,5);
        }

        /// <summary>
        /// Displays a merchant message and gets you to buy stuff
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
        public static void MerchantMessage(Universe universe, Adventurer adventurer)
        {
            RedrawBox(universe, 5);

            List<Item.Items> wares = new List<Item.Items>();

            Console.SetCursorPosition(6, 46);
            Console.Write("Welcome, what can I get you?");
            TextboxCursorBlink();
            
            Map.MerchantBuy(universe, adventurer);

            ReWriteToMessageBox(universe, " Thank you for shopping " + adventurer.Name);

            ClearTextBox();
            RemoveBox(universe, 5);
            DisplayMenu(universe);
        }

        /// <summary>
        /// Writes a message to the message box after redrawing it
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="messageToBox"></param>
        public static void WriteToMessageBox(Universe universe,string messageToBox)
        {

            List<string> message = MessageBoxWordWrap(messageToBox, 87);
            RedrawBox(universe, 5);
            int position = 46;
            foreach (string strins in message)
            {
                Console.SetCursorPosition(6, position);
                Console.Write(strins);
                position++;
            }


            TextboxCursorBlink();
            ClearTextBox();
            RemoveBox(universe, 5);
        }

        /// <summary>
        /// rewrites a new message to the Message Box
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="messageToBox"></param>
        public static void ReWriteToMessageBox(Universe universe, string messageToBox)
        {
            ClearTextBox();

            List<string> message = MessageBoxWordWrap(messageToBox, 87);
            RedrawBox(universe, 5);
            int position = 46;
            foreach (string strins in message)
            {
                Console.SetCursorPosition(6, position);
                Console.Write(strins);
                position++;
            }


            TextboxCursorBlink();

        }


        /// <summary>
        /// Writes a message to the message box after redrawing it
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="messageToBox"></param>
        public static void WriteToMessageBox(Universe universe, string messageToBox,bool noblink)
        {

            List<string> message = MessageBoxWordWrap(messageToBox, 87);
            RedrawBox(universe, 5);
            int position = 46;
            foreach (string strins in message)
            {
                Console.SetCursorPosition(6, position);
                Console.Write(strins);
                position++;
            }



            ClearTextBox();
            RemoveBox(universe, 5);
        }

        /// <summary>
        /// rewrites a new message to the Message Box but no cursor blink
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="messageToBox"></param>
        public static void ReWriteToMessageBox(Universe universe, string messageToBox, bool noBlink)
        {
            ClearTextBox();

            List<string> message = MessageBoxWordWrap(messageToBox, 87);
            RedrawBox(universe, 5);
            int position = 46;
            foreach (string strins in message)
            {
                Console.SetCursorPosition(6, position);
                Console.Write(strins);
                position++;
            }

        }


        //WARNING, THis does not set everything as a string(Regrettably) It seperates the text into however many number of spaces and extends the list each time it reaches (Whatever you set the character limit number to)
        /// <summary>
        /// wraps text using a list of strings
        /// Original code from Mike Ward's website
        /// http://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/
        /// Adapted to format for text boxes
        /// </summary>
        /// <param name="text">text to wrap</param>
        /// <param name="textAreaWidth">length of each line</param>
        /// <param name="leftMargin">left margin</param>
        /// <returns>list of lines as strings</returns>
        public static List<string> MessageBoxWordWrap(string text, int textAreaWidth)
        {
            var lines = new List<string>();

            string[] paragraphs = Regex.Split(text, "\n");

            foreach (string paragraph in paragraphs)
            {
                int start = 0, end;

                //
                // removes formatting characters
                //
                text = Regex.Replace(text, @"\s", " ").Trim();

                while ((end = start + textAreaWidth) < paragraph.Length)
                {
                    while (paragraph[end] != ' ' && end > start)
                        end -= 1;

                    if (end == start)
                        end = start + textAreaWidth;

                    string textLine = paragraph.Substring(start, end - start);

                    lines.Add(textLine);
                    start = end + 1;
                }

                if (start < paragraph.Length)
                    lines.Add(paragraph.Substring(start));
            }

            return lines;
        }


    }
}
