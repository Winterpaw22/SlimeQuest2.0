using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class DisplayMap
    {
        public static void DisplayNPC(Universe universe)
        {
            foreach (NPC person in universe.NPCList)
            {
                if (person.present)
                {
                    Console.SetCursorPosition(person.Xpos, person.Ypos);
                    
                    Console.Write(person.charIcon);
                }
            }
        }
        public static void DisplayTowns(Universe universe, Adventurer adventurer)
        {

            if (adventurer.MapLocation == Humanoid.Location.MainWorld)
            {
                foreach (Towns town in universe.TownList)
                {
                    Console.SetCursorPosition(town.Xpos, town.Ypos);
                    Console.Write(town.MapIcon);
                }
            }
        }
        public static void DisplayHouses(Universe universe, Adventurer adventurer)
        {

            if (adventurer.MapLocation != Humanoid.Location.MainWorld)
            {
                foreach (House house in universe.HouseList)
                {
                    switch (adventurer.MapLocation)
                    {
                        case Humanoid.Location.TutTown:
                            DisplayHouse(house.Xpos, house.Ypos,house.HouseColor);
                            break;
                        case Humanoid.Location.DefaultNameTown:
                            DisplayHouse(house.Xpos, house.Ypos,house.HouseColor);
                            break;
                        default:
                            break;
                    }
                    
                }
            }
        }
        public static void DisplayHouse(int startx,int starty,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(startx + 1,starty);
            Console.Write("_____");
            Console.SetCursorPosition(startx, starty + 1);
            Console.Write("/");
            Console.SetCursorPosition(startx, starty + 2);
            Console.Write("|");
            Console.SetCursorPosition(startx, starty + 3);
            Console.Write("|_|");

            Console.SetCursorPosition(startx + 3, starty + 2);
            Console.Write("_");

            Console.SetCursorPosition(startx + 4, starty + 3);
            Console.Write("|_|");
            
            Console.SetCursorPosition(startx + 6, starty + 1);
            Console.Write("\\");
            Console.SetCursorPosition(startx + 6, starty + 2);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
