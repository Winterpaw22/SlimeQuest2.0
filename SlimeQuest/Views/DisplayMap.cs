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

        public static void DisplayTree(int xPos, int yPos)
        {
            Console.SetCursorPosition(xPos,yPos);
            Console.Write("|");
            Console.SetCursorPosition(xPos, yPos - 1);
            Console.Write("|");
            Console.SetCursorPosition(xPos, yPos - 2);
            Console.Write("@");
        }
        public static void DisplayPlantBasic(int xPos, int yPos,string icon)
        {
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(icon);
        }
        public static void DisplayPlantGrass(int xStart, int xEnd, int yStart,int yEnd, string icon)
        {
            for (int i = yStart; i <= yEnd; i++)
            {
                for (int x = xStart; x <= xEnd; x++)
                {
                    Console.SetCursorPosition(x, i);
                    Console.Write(icon);
                }
            }
            
        }

        /// <summary>
        /// Draws the walls for the inside of a house
        /// </summary>
        /// <param name="universe"></param>
        public static void DisplayHouseInside(Universe universe)
        {
            foreach (var house in universe.HouseLayouts)
            {

                bool p = false;

                //LEFT LINE
                for (int y = house.startYPos; y < house.endYPos; y++)
                {
                    Console.SetCursorPosition(house.startXPos, y);
                    if (!p)
                    {
                        Console.Write("+");
                        p = true;

                    }
                    else
                    {
                        Console.Write("|");
                    }

                }

                //TOP LINE
                p = false;
                for (int x = house.startXPos; x < house.endXPos; x++)
                {
                    Console.SetCursorPosition(x, house.startYPos);
                    if (!p)
                    {
                        Console.Write("+");
                        p = true;

                    }
                    else
                    {
                        Console.Write("-");
                    }

                }

                //BOTTOM LINE
                p = false;
                for (int x = house.startXPos; x < house.endXPos; x++)
                {
                    Console.SetCursorPosition(x, house.endYPos);
                    if (!p)
                    {
                        Console.Write("+");
                        p = true;

                    }
                    else
                    {
                        Console.Write("-");
                    }

                }

                //RIGHT LINE
                p = false;
                for (int y = house.startYPos; y < house.endYPos; y++)
                {
                    Console.SetCursorPosition(house.endXPos, y);
                    if (!p)
                    {
                        Console.Write("+");
                        p = true;

                    }
                    else
                    {
                        Console.Write("|");
                    }

                }
                Console.SetCursorPosition(house.endXPos, house.endYPos);
                Console.Write("+");

                Console.SetCursorPosition(55, 33);
                Console.Write("| |");


            }
        }
        /// <summary>
        /// Displays furniture into houses
        /// </summary>
        /// <param name="Xstart">Start of placement furthest Left</param>
        /// <param name="Ystart">Start of Placement Furthest Right</param>
        /// <param name="furnType">The type of furniture to draw</param>
        public static void DisplayHouseObjects( int Xstart, int Ystart, Furniture.FurnitureType furnType)
        {
            switch (furnType)
            {
                case Furniture.FurnitureType.Counter:
                    Console.SetCursorPosition(Xstart + 2,Ystart);
                    Console.Write("|");

                    Console.SetCursorPosition(Xstart + 2, Ystart + 1);
                    Console.Write("|");

                    Console.SetCursorPosition(Xstart + 2, Ystart + 2);
                    Console.Write("|");

                    Console.SetCursorPosition(Xstart + 2, Ystart + 3);
                    Console.Write("|");

                    Console.SetCursorPosition(Xstart + 1, Ystart + 3);
                    Console.Write("_");

                    Console.SetCursorPosition(Xstart, Ystart + 3);
                    Console.Write("_");

                    break;
                case Furniture.FurnitureType.Desk:
                    Console.SetCursorPosition(Xstart + 1, Ystart);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 2, Ystart);
                    Console.Write("-");

                    Console.SetCursorPosition(Xstart, Ystart);
                    Console.Write("+");
                    Console.SetCursorPosition(Xstart, Ystart + 1);
                    Console.Write("+");

                    Console.SetCursorPosition(Xstart + 1, Ystart + 1);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 2, Ystart + 1);
                    Console.Write("-");

                    Console.SetCursorPosition(Xstart + 3, Ystart);
                    Console.Write("+");
                    Console.SetCursorPosition(Xstart + 3, Ystart + 1);
                    Console.Write("+");
                    break;

                case Furniture.FurnitureType.Table:

                    Console.SetCursorPosition(Xstart + 1, Ystart);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 2, Ystart);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 3, Ystart);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 4, Ystart);
                    Console.Write("-");

                    Console.SetCursorPosition(Xstart, Ystart);
                    Console.Write("+");
                    Console.SetCursorPosition(Xstart, Ystart + 1);
                    Console.Write("|");
                    Console.SetCursorPosition(Xstart, Ystart + 2);
                    Console.Write("+");

                    Console.SetCursorPosition(Xstart + 1, Ystart + 2);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 2, Ystart + 2);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 3, Ystart + 2);
                    Console.Write("-");
                    Console.SetCursorPosition(Xstart + 4, Ystart + 2);
                    Console.Write("-");

                    Console.SetCursorPosition(Xstart + 5, Ystart);
                    Console.Write("+");
                    Console.SetCursorPosition(Xstart + 5, Ystart + 1);
                    Console.Write("|");
                    Console.SetCursorPosition(Xstart + 5, Ystart + 2);
                    Console.Write("+");
                    break;
                default:
                    break;
            }
        }
        public static void DisplayItemToPickup( int Xpos, int Ypos)
        {
            Console.SetCursorPosition(Xpos,Ypos);
            Console.Write("+");
        }
        public static void DisplayItemToPickup(int Xpos, int Ypos,bool removeFromField)
        {
            if (removeFromField)
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.Write(" ");
            }
            else
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.Write("+");
            }
            
        }
    }
}
