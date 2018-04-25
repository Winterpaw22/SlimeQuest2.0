using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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


        /// <summary>
        /// Checks for plants
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
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
                        case Foiliage.plantType.Fountain:
                            TextDrawings.DisplayFountain(plant.XPos, plant.YPos);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        /// <summary>
        /// Checks for Furniture then displays it in the room you are in.
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
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
        /// Checks the player's position Handles BOTH mainworld and House Locations
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


                                TextBoxViews.RedrawBox(universe,6);
                                TextBoxViews.WriteToEvent(adventurer.MapLocation.ToString());


                                TextBoxViews.ClearMapBox();
                                adventurer.MapLocation = town.TownLocName;
                                adventurer.PreviousLocations.Add(adventurer.MapLocation);
                                adventurer.Xpos = 40;
                                adventurer.Ypos = 48;
                            }
                        }
                        TextBoxViews.RedrawBox(universe, 6);
                        TextBoxViews.WriteToEvent(adventurer.MapLocation.ToString());
                        break;
                    case Humanoid.Location.TutTown:
                        if (adventurer.Ypos >= 50)
                        {
                            

                            TextBoxViews.ClearMapBox();
                            adventurer.MapLocation = Humanoid.Location.MainWorld;
                            adventurer.Xpos = universe.TownList[0].Xpos;
                            adventurer.Ypos = universe.TownList[0].Ypos;
                            adventurer.PreviousLocations.Add(adventurer.MapLocation);
                            Map.QuestTrigger(adventurer,universe,Adventurer.Quest.LeaveHome);
                            TextBoxViews.RedrawBox(universe, 6);
                            TextBoxViews.WriteToEvent(adventurer.MapLocation.ToString());
                        }
                        foreach (var house in universe.HouseList)
                        {
                            if ((adventurer.Xpos == house.EnterPosition[0]) && (adventurer.Ypos == house.EnterPosition[1]) && (house.HouseLoc == Humanoid.Location.TutTown))
                            {
                                adventurer.InaHouse = true;
                                house.PlayerInside = true;
                                adventurer.Xpos = 56;
                                adventurer.Ypos = 32;
                                adventurer.InHouseName = house.HouseName;
                                TextBoxViews.RedrawBox(universe, 6);
                                TextBoxViews.WriteToEvent(adventurer.InHouseName.ToString());

                                TextBoxViews.ClearMapBox();
                            }
                        }
                        TextBoxViews.RedrawBox(universe, 6);
                        TextBoxViews.WriteToEvent(adventurer.MapLocation.ToString());

                        break;
                    case Humanoid.Location.CherryGrove:
                        Map.QuestTrigger(adventurer,universe,Adventurer.Quest.TheNewGuyInTown);
                        if (adventurer.Ypos >= 50)
                        {
                            TextBoxViews.ClearMapBox();
                            adventurer.MapLocation = Humanoid.Location.MainWorld;

                            adventurer.Xpos = universe.TownList[1].Xpos;
                            adventurer.Ypos = universe.TownList[1].Ypos;
                            adventurer.PreviousLocations.Add(adventurer.MapLocation);
                            
                        }
                        foreach (var house in universe.HouseList)
                        {
                            if ((adventurer.Xpos == house.EnterPosition[0]) && (adventurer.Ypos == house.EnterPosition[1]) && (house.HouseLoc == Humanoid.Location.CherryGrove))
                            {
                                adventurer.InaHouse = true;
                                house.PlayerInside = true;
                                adventurer.Xpos = 56;
                                adventurer.Ypos = 32;
                                adventurer.InHouseName = house.HouseName;

                                TextBoxViews.RedrawBox(universe, 6);
                                TextBoxViews.WriteToEvent(adventurer.InHouseName.ToString());

                                TextBoxViews.ClearMapBox();
                            }
                        }
                        TextBoxViews.RedrawBox(universe, 6);
                        TextBoxViews.WriteToEvent(adventurer.MapLocation.ToString());
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

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.HealHouse:
                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
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

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.CerriHouse:
                        
                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.AmastaHouse:
                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
                        break;
                    case House.houseName.AristaHouse:
                        if (adventurer.Xpos == 56 && adventurer.Ypos == 33)
                        {
                            adventurer.InaHouse = false;

                            foreach (var house in universe.HouseList)
                            {
                                if (adventurer.InHouseName == house.HouseName)
                                {
                                    house.PlayerInside = false;
                                    adventurer.InHouseName = House.houseName.None;

                                    adventurer.Xpos = house.EnterPosition[0];
                                    adventurer.Ypos = house.EnterPosition[1] + 1;
                                }
                            }
                            TextBoxViews.ClearMapBox();
                        }
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

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.GoHome;
                                adventurer.QuestDone[0] = true;
                            }
                            break;

                        case Adventurer.Quest.GoHome:
                            TextBoxViews.DisplayQuest("Go back to your house");
                            if (quest.Value && !adventurer.QuestDone[1])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.GoShopping;

                                adventurer.QuestDone[1] = true;
                            }
                            break;

                        case Adventurer.Quest.GoShopping:
                            TextBoxViews.DisplayQuest("Go buy some supplies");
                            if (quest.Value && !adventurer.QuestDone[2])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");


                                adventurer.CurrentQuest = Adventurer.Quest.LeaveHome;
                                adventurer.QuestDone[2] = true;
                            }
                            break;

                        case Adventurer.Quest.LeaveHome:
                            TextBoxViews.DisplayQuest("Leave town");
                            if (quest.Value && !adventurer.QuestDone[3])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.TheNewGuyInTown;
                                adventurer.QuestDone[3] = true;
                            }
                            break;
                        
                        
                        case Adventurer.Quest.TheNewGuyInTown:
                            TextBoxViews.DisplayQuest("Go to town 2");
                            if (quest.Value && !adventurer.QuestDone[4])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.DeliverTheParcel;
                                adventurer.QuestDone[4] = true;
                            }
                            break;
                        case Adventurer.Quest.DeliverTheParcel:
                            TextBoxViews.DisplayQuest("Find the parcel in Town");
                            if (quest.Value && !adventurer.QuestDone[5])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.FightTheCaveTrio;
                                adventurer.QuestDone[5] = true;
                            }
                            break;
                        case Adventurer.Quest.FightTheCaveTrio:
                            TextBoxViews.DisplayQuest("Go fight the trio!");
                            if (quest.Value && !adventurer.QuestDone[6])
                            {
                                Console.SetCursorPosition(110, 24);
                                Console.Write("Completed Quest");

                                Thread.Sleep(1000);

                                Console.SetCursorPosition(110, 24);
                                Console.Write("               ");

                                adventurer.CurrentQuest = Adventurer.Quest.None;
                                
                                adventurer.QuestDone[6] = true;
                                adventurer.playerWin = true;
                                
                            }
                            break;
                        default:
                            break;
                    }
                }

            }

        }

        /// <summary>
        /// displays evil trio
        /// </summary>
        /// <param name="universe"></param>
        public static void CheckandDisplayCaveEnemies(Universe universe)
        {
            foreach(var person in universe.TripleTrouble)
            {
                if (person.MapLocation == Humanoid.Location.Cave)
                {
                    if (!person.Defeated)
                    {
                        person.present = true;
                    }
                    else if (person.Defeated)
                    {
                        person.present = false;
                    }
                }
                else
                {
                    person.present = false;
                }

                if (person.present)
                {
                    Console.SetCursorPosition(person.Xpos, person.Ypos);

                    Console.Write(person.charIcon);
                }
                else
                {
                    Console.SetCursorPosition(person.Xpos, person.Ypos);

                    Console.Write(" ");
                }
            }
        }



        /// <summary>
        /// Checks for it3ems then displays them onto the current map you are on
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
        public static void CheckAndDisplayItemMap(Universe universe, Adventurer adventurer)
        {
            bool noMapItems = false;
            foreach (var item in universe.ItemList)
            {
                if ((item.houseLoc != House.houseName.None) && (item.houseLoc == adventurer.InHouseName))
                {
                    if (!item.itemTaken)
                    {
                        DisplayMap.DisplayItemToPickup(item.XPos,item.YPos);
                        noMapItems = true;
                    }
                }
                else if (item.worldLoc == adventurer.MapLocation && !noMapItems)
                {
                    if (!item.itemTaken)
                    {
                        DisplayMap.DisplayItemToPickup(item.XPos, item.YPos);
                    }
                }
            }
        }

        public static void CheckAndPickupItem(Universe universe, Adventurer adventurer)
        {
            int checkx = adventurer.Xpos;
            int checky = adventurer.Ypos;
            switch (adventurer.LookDirection)
            {
                case Humanoid.Direction.LEFT:
                    checkx--;
                    break;
                case Humanoid.Direction.RIGHT:
                    checkx++;
                    break;
                case Humanoid.Direction.UP:
                    checky--;
                    break;
                case Humanoid.Direction.DOWN:
                    checky++;
                    break;
                default:
                    break;
            }

            foreach (var item in universe.ItemList)
            {
                if ((item.houseLoc != House.houseName.None) && (item.houseLoc == adventurer.InHouseName))
                {
                    if (!item.itemTaken)
                    {
                        
                        if ((item.XPos == checkx) && (item.YPos == checky))
                        {
                            item.itemTaken = true;
                            adventurer.ItemsDictionary[item.ItemType] += 1;
                            DisplayMap.DisplayItemToPickup(item.XPos, item.YPos, item.itemTaken);
                            TextBoxViews.WriteToMessageBox(universe, "You picked up a " + item.ItemType.ToString());
                        }
                        
                    }

                }
                else if (item.worldLoc == adventurer.MapLocation)
                {
                    if (!item.itemTaken)
                    {
                        
                        //matches locations
                        if ((item.XPos == checkx) && (item.YPos == checky))
                        {
                            item.itemTaken = true;
                            adventurer.ItemsDictionary[item.ItemType] += 1;
                            DisplayMap.DisplayItemToPickup(item.XPos, item.YPos, item.itemTaken);
                            TextBoxViews.WriteToMessageBox(universe, "You picked up a " + item.ItemType.ToString());
                        }
                    }
                }
            }
        }//End of last Method





    }
}
