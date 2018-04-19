using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Check
    {
        /// <summary>
        /// Checks the Map for NPC's to Display
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="location"></param>
        public static void CheckNPCMap(Universe universe, Humanoid.Location location)
        {
            foreach (NPC person in universe.NPCList)
            {
                if (person.MapLocation == location)
                {
                    person.present = true;
                }
                else
                {
                    person.present = false;
                }
            }
        }

        /// <summary>
        /// Checks a house for NPC's to Display
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="location"></param>
        public static void CheckNPCMap(Universe universe, House.houseName location)
        {
            foreach (NPC person in universe.NPCList)
            {
                if (person.InHouseName == location)
                {
                    person.present = true;
                }
                else
                {
                    person.present = false;
                }
            }
        }
        public static void CheckTownMap(Universe universe, Humanoid.Location location)
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

        public static void CheckForFoiliage(Universe universe, Adventurer adventurer)
        {
            foreach (Foiliage plant in universe.FoiliageList)
            {
                if (plant.Location == adventurer.MapLocation)
                {
                    switch (plant.Plant)
                    {
                        case Foiliage.plantType.Tree:
                            DisplayMap.DisplayTree(plant.XPos, plant.YPos);
                            break;
                        case Foiliage.plantType.Grass:
                            DisplayMap.DisplayPlantBasic(plant.XPos, plant.YPos, plant.CharIcon);
                            break;
                        case Foiliage.plantType.Flower:
                            break;
                        case Foiliage.plantType.Field:
                            DisplayMap.DisplayPlantGrass(plant.XPos, plant.XEnd, plant.YPos, plant.YEnd, plant.CharIcon);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        public static void CheckandDisplayRoomObjects(Universe universe, Adventurer adventurer)
        {
            foreach (var furniture in universe.FurnitureList)
            {
                if (furniture.House == adventurer.InHouseName)
                {
                    DisplayMap.DisplayHouseObjects(furniture.Xpos, furniture.Ypos, furniture.FurnituretOb);
                }

            }
        }

        /// <summary>
        /// Checks the player's position
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
        public static void CheckPlayerPosition(Universe universe, Adventurer adventurer)
        {
            if (!adventurer.InaHouse)
            {
                switch (adventurer.MapLocation)
                {
                    case Humanoid.Location.MainWorld:
                        foreach (Towns town in universe.TownList)
                        {
                            if (adventurer.Ypos == town.Ypos && adventurer.Xpos == town.Xpos)
                            {
                                TextBoxViews.ClearMapBox();
                                adventurer.MapLocation = town.TownLocName;
                                adventurer.PreviousLocations.Add(adventurer.MapLocation);
                                adventurer.Xpos = 40;
                                adventurer.Ypos = 48;
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
                            adventurer.PreviousLocations.Add(adventurer.MapLocation);
                        }
                        foreach (var house in universe.HouseList)
                        {
                            if ((adventurer.Xpos == house.EnterPosition[0]) && (adventurer.Ypos == house.EnterPosition[1]))
                            {
                                adventurer.InaHouse = true;
                                house.PlayerInside = true;
                                adventurer.Xpos = 56;
                                adventurer.Ypos = 32;
                                adventurer.InHouseName = house.HouseName;
                                TextBoxViews.ClearMapBox();
                            }
                        }

                        break;
                    case Humanoid.Location.DefaultNameTown:
                        if (adventurer.Ypos >= 50)
                        {
                            TextBoxViews.ClearMapBox();
                            adventurer.MapLocation = Humanoid.Location.MainWorld;

                            adventurer.Xpos = universe.TownList[1].Xpos;
                            adventurer.Ypos = universe.TownList[1].Ypos;
                            adventurer.PreviousLocations.Add(adventurer.MapLocation);
                        }
                        break;
                    case Humanoid.Location.Cave:
                        if (adventurer.Ypos >= 50)
                        {
                            TextBoxViews.ClearMapBox();
                            adventurer.MapLocation = Humanoid.Location.MainWorld;

                            adventurer.Xpos = universe.TownList[3].Xpos;
                            adventurer.Ypos = universe.TownList[3].Ypos;
                            adventurer.PreviousLocations.Add(adventurer.MapLocation);
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (adventurer.InaHouse)
            {
                switch (adventurer.InHouseName)
                {
                    case House.houseName.None:
                        break;
                    case House.houseName.PlayerHome:

                        Map.QuestTrigger(adventurer, universe, Adventurer.Quest.GoHome);

                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.HealHouse:
                        break;
                    case House.houseName.Market:
                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.CerryHouse:
                        break;
                    case House.houseName.AmastaHouse:
                        break;
                    case House.houseName.AristaHouse:
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Checks what quest the player is on.
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
        public static void CheckPlayerQuest(Universe universe, Adventurer adventurer)
        {
            foreach (var quest in adventurer.QuestCompletion)
            {
                if (quest.Key == adventurer.CurrentQuest)
                {


                    switch (adventurer.CurrentQuest)
                    {
                        case Adventurer.Quest.MeetTheOldMan:
                            TextBoxViews.DisplayQuest("Go talk to the old man");
                            if (quest.Value && !adventurer.QuestDone[0])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");
                                System.Threading.Thread.Sleep(2000);
                                adventurer.CurrentQuest = Adventurer.Quest.GoHome;
                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");
                                adventurer.QuestDone[0] = true;
                            }
                            break;

                        case Adventurer.Quest.GoHome:
                            TextBoxViews.DisplayQuest("Go back to your house");
                            if (quest.Value && !adventurer.QuestDone[1])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");
                                System.Threading.Thread.Sleep(2000);
                                adventurer.CurrentQuest = Adventurer.Quest.LeaveHome;
                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");
                                adventurer.QuestDone[1] = true;
                            }
                            break;
                        case Adventurer.Quest.LeaveHome:
                            TextBoxViews.DisplayQuest("Leave town");
                            if (quest.Value && !adventurer.QuestDone[2])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");
                                System.Threading.Thread.Sleep(2000);
                                adventurer.CurrentQuest = Adventurer.Quest.LeaveHome;
                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");
                                adventurer.QuestDone[2] = true;
                            }
                            break;
                        case Adventurer.Quest.TheNewGuyInTown:
                            break;
                        default:
                            break;
                    }
                }

            }

        }

    }
}
