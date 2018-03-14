using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{ 
    class Map
    {
        public static void CheckPosition(Adventurer adventurer, Universe universe)
        {
            int[] lastPosition = new int[2];

            lastPosition[0] = adventurer.Xpos;
            lastPosition[1] = adventurer.Ypos;

            //checks for current quest and if you complete the quest or not
            switch (adventurer.CurrentQuest)
            {
                case Adventurer.Quest.MeetTheOldMan:
                    TextBoxViews.DisplayQuest("Go talk to the old man");
                    if (adventurer.Ypos == 8 && adventurer.Xpos == 75)
                    {
                        Console.SetCursorPosition(110, 24);
                        Console.Write("Completed Quest");
                        adventurer.CurrentQuest = Adventurer.Quest.GoHome;

                    }
                    break;
                case Adventurer.Quest.GoHome:
                    TextBoxViews.DisplayQuest("Go back to your house");
                    if (adventurer.Ypos == 26 && adventurer.Xpos == 50)
                    {
                        Console.SetCursorPosition(110, 24);
                        Console.Write("Completed Quest");
                       
                    }
                    break;
                case Adventurer.Quest.LeaveHome:
                    break;
                case Adventurer.Quest.TheNewGuyInTown:
                    break;
                default:
                    break;
            }
            //Checks what map you are on and then Draws the correct entities to the screen
            switch (adventurer.MapLocation)
            {
                case Humanoid.Location.MainWorld:
                    foreach (Towns town in universe.TownList)
                    {
                        if (adventurer.Ypos == town.Ypos && adventurer.Xpos == town.Xpos)
                        {
                            TextBoxViews.ClearMapBox();
                            adventurer.MapLocation = town.TownLocName;
                        }
                    }
                    break;
                case Humanoid.Location.TutTown:
                    if (adventurer.Ypos >= 50)
                    {
                        TextBoxViews.ClearMapBox();
                        adventurer.MapLocation = Humanoid.Location.MainWorld;
                        adventurer.Xpos = universe.TownList[0].Xpos;
                        adventurer.Ypos = universe.TownList[0].Ypos;

                    }
                    break;
                case Humanoid.Location.DefaultNameTown:
                    if (adventurer.Ypos >= 50)
                    {
                        TextBoxViews.ClearMapBox();
                        adventurer.MapLocation = Humanoid.Location.MainWorld;

                        adventurer.Xpos = universe.TownList[1].Xpos;
                        adventurer.Ypos = universe.TownList[1].Ypos;
                    }
                    break;
                case Humanoid.Location.Cave:
                    if (adventurer.Ypos >= 50)
                    {
                        TextBoxViews.ClearMapBox();
                        adventurer.MapLocation = Humanoid.Location.MainWorld;

                        adventurer.Xpos = universe.TownList[3].Xpos;
                        adventurer.Ypos = universe.TownList[3].Ypos;
                    }
                    break;
                default:
                    break;
            }
            DisplayMapObjects(adventurer,universe);

        }
        public static void QuestGiver(Adventurer adventurer)
        {
            Console.SetCursorPosition(110, 20);
            Console.Write("QUEST: " +  adventurer.CurrentQuest);
            Console.SetCursorPosition(110, 22);
            Console.Write("                        ");
        }

        public static void DisplayMapObjects(Adventurer adventurer, Universe universe)
        {
            switch (adventurer.MapLocation)
            {
                case Humanoid.Location.MainWorld:
                    CheckNPCMap(universe, Humanoid.Location.MainWorld);
                    CheckNPCMap(universe, Humanoid.Location.MainWorld);
                    DisplayMap.DisplayTowns(universe, adventurer);
                    break;
                case Humanoid.Location.TutTown:
                    CheckNPCMap(universe, Humanoid.Location.TutTown);
                    DisplayMap.DisplayNPC(universe);
                    break;
                case Humanoid.Location.DefaultNameTown:
                    CheckNPCMap(universe, Humanoid.Location.DefaultNameTown);
                    DisplayMap.DisplayNPC(universe);
                    break;
                case Humanoid.Location.Cave:
                    CheckNPCMap(universe, Humanoid.Location.Cave);
                    DisplayMap.DisplayNPC(universe);
                    break;
                default:
                    break;
            }
        }

        private static void CheckNPCMap(Universe universe, Humanoid.Location location)
        {
            foreach (NPC person in universe.NPCList)
            {
                if (person.MapLocation == location )
                {
                    person.present = true;
                }
                else
                {
                    person.present = false;
                }
            }
        }
        private static void CheckTownMap(Universe universe, Humanoid.Location location)
        {
            foreach (Towns town in universe.TownList)
            {
                if (town.TownLocName == location)
                {
                    town.InTown = true;

                }
                else
                {
                    town.InTown = false;
                }
            }
        }

        public static void NPCTalk(Adventurer adventurer, Universe universe)
        {
            int xPos = adventurer.Xpos;
            int yPos = adventurer.Ypos;
            
            switch (adventurer.LookDirection)
            {
                case Humanoid.Direction.LEFT:
                    xPos--;
                    break;
                case Humanoid.Direction.RIGHT:
                    xPos++;
                    break;
                case Humanoid.Direction.UP:
                    yPos--;
                    break;
                case Humanoid.Direction.DOWN:
                    yPos++;
                    break;
                default:

                    break;
            }
            
            string text = "There is no-one to talk with in front of you, Are you going insane?";
            foreach (NPC npc in universe.NPCList)
            {
                if (npc.Xpos == xPos && npc.Ypos == yPos)
                {

                    text = npc.messages[npc.listCurrent];
                    npc.listCurrent++;
                    if (npc.listCurrent >= npc.listMax)
                    {
                        npc.listCurrent = 0;
                    }

                }
            }
            TextBoxViews.WriteToMessageBox(universe,text);
        }

        public static bool movement(Adventurer adventurer, Universe universe)
        {
            ConsoleKeyInfo keyPress;
            keyPress = Console.ReadKey();
            bool playing = true;
            int[] lastPosition = new int[2];

            lastPosition[0] = adventurer.Xpos;
            lastPosition[1] = adventurer.Ypos;

            Console.SetCursorPosition(lastPosition[0], lastPosition[1]);
            Console.Write(" ");
            switch (keyPress.Key)
            {

                case ConsoleKey.LeftArrow:
                    if (!(adventurer.Xpos < 3))
                    {
                        adventurer.Xpos--;
                        adventurer.LookDirection = Humanoid.Direction.LEFT;
                    }
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.UpArrow:
                    if (!(adventurer.Ypos < 7))
                    {
                        adventurer.Ypos--;
                        adventurer.LookDirection = Humanoid.Direction.UP;
                    }
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.RightArrow:
                    if (!(adventurer.Xpos > 102))
                    {
                        adventurer.Xpos++;
                        adventurer.LookDirection = Humanoid.Direction.RIGHT;
                    }

                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.DownArrow:
                    if (!(adventurer.Ypos > 52))
                    {
                        adventurer.Ypos++;
                        adventurer.LookDirection = Humanoid.Direction.DOWN;
                    }
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;

                case ConsoleKey.NumPad0:
                    break;
                case ConsoleKey.NumPad1:
                    playing = false;
                    break;
                case ConsoleKey.NumPad2:
                    TextBoxViews.DisplayTownDesc(universe);
                    break;
                case ConsoleKey.NumPad3:
                    NPCTalk(adventurer,universe);
                    break;
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.NumPad6:
                    break;
                case ConsoleKey.NumPad7:
                    break;
                case ConsoleKey.NumPad8:
                    break;
                case ConsoleKey.NumPad9:
                    break;

                default:
                    break;
            }

            //if (keyPress.Key == ConsoleKey.Spacebar)
            //{



            //    Console.SetCursorPosition(player.Xpos, player.Ypos);
            //    Console.Write("☺");
            //    Console.CursorTop--;
            //    Console.Write("/");
            //    System.Threading.Thread.Sleep(300);
            //    Console.CursorLeft--;
            //    Console.Write(" ");
            //    Console.CursorLeft--;
            //    Console.CursorLeft--;
            //    Console.Write("|");
            //    System.Threading.Thread.Sleep(300);
            //    Console.CursorLeft--;
            //    Console.Write(" ");
            //    Console.CursorLeft--;
            //    Console.CursorLeft--;
            //    Console.Write("\\");
            //    System.Threading.Thread.Sleep(300);
            //    Console.CursorLeft--;
            //    Console.Write(" ");


            //}


            return playing;

        }


    }
}
