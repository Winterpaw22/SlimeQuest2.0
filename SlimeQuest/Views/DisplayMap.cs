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
                    DisplayHouse(house.Xpos, house.Ypos);
                }
            }
        }
        public static void DisplayHouse(int startx,int starty)
        {
            Console.SetCursorPosition(startx + 1,starty);
            Console.Write("__");
            Console.SetCursorPosition(startx, starty + 1);
            Console.Write("/");
            Console.SetCursorPosition(startx, starty + 2);
            Console.Write("|");
            Console.SetCursorPosition(startx, starty + 3);
            Console.Write("_|");
            Console.SetCursorPosition(startx + 2, starty + 3);
            Console.Write("|_");
            
            Console.SetCursorPosition(startx + 5, starty + 1);
            Console.Write("\\");
            Console.SetCursorPosition(startx + 5, starty + 2);
            Console.Write("|");
        }
    }
}
