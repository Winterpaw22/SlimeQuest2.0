using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{ 
    class Map
    {
        public static void CheckPosition(Adventurer adventurer, Universe universe)
        {
            //int[] lastPosition = new int[2];

            //lastPosition[0] = adventurer.Xpos;
            //lastPosition[1] = adventurer.Ypos;

            //checks for current quest and if you complete the quest or not
            Check.CheckPlayerQuest(universe, adventurer);
            //Checks what map you are on and then Draws the correct entities to the screen
            Check.CheckPlayerPosition(universe, adventurer);

            //checks whether to draw house stuff or not
            if (!adventurer.InaHouse)
            {
                DisplayMapObjects(adventurer, universe);
            }
            else if (adventurer.InaHouse)
            {
                foreach (var house in universe.HouseList)
                {
                    if (house.PlayerInside)
                    {
                        DisplayMap.DisplayHouseInside(universe);
                        Check.CheckNPCMap(universe, adventurer.InHouseName);
                        DisplayMap.DisplayNPC(universe);
                        //Handles all objects in the "rooms"
                        //NEW IDEA, Hows bout thats annoying and no
                        Check.CheckandDisplayRoomObjects(universe,adventurer);
                    }
                }
            }

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
                    Check.CheckNPCMap(universe, Humanoid.Location.MainWorld);
                    DisplayMap.DisplayTowns(universe, adventurer);
                    Check.CheckForFoiliage(universe, adventurer);
                    break;
                case Humanoid.Location.TutTown:
                    Check.CheckNPCMap(universe, Humanoid.Location.TutTown);
                    DisplayMap.DisplayNPC(universe);
                    DisplayMap.DisplayHouses(universe, adventurer);
                    Check.CheckForFoiliage(universe, adventurer);

                    break;
                case Humanoid.Location.DefaultNameTown:
                    Check.CheckNPCMap(universe, Humanoid.Location.DefaultNameTown);
                    DisplayMap.DisplayNPC(universe);
                    DisplayMap.DisplayHouses(universe, adventurer);
                    Check.CheckForFoiliage(universe, adventurer);
                    break;
                case Humanoid.Location.Cave:
                    Check.CheckNPCMap(universe, Humanoid.Location.Cave);
                    DisplayMap.DisplayNPC(universe);
                    break;
                default:
                    break;
            }
        }
        
       
        /// <summary>
        /// Prints where you have been in order
        /// </summary>
        /// <param name="adventurer"></param>
        /// <param name="universe"></param>
        public static void PlayerLocationss(Adventurer adventurer,Universe universe)
        {
            string message = "Where you have been. In order :";
            foreach (var location in adventurer.PreviousLocations)
            {
                message += location.ToString();
                message += ", ";
            }
            TextBoxViews.WriteToMessageBox(universe, message);
        }

        /// <summary>
        /// lets you talk to NPC's
        /// Cycles through set text each npc has
        /// </summary>
        /// <param name="adventurer"></param>
        /// <param name="universe"></param>
        public static void NPCTalk(Adventurer adventurer, Universe universe)
        {
            int xPos = adventurer.Xpos;
            int yPos = adventurer.Ypos;


            if (adventurer.InaHouse && adventurer.InHouseName == House.houseName.Market)
            {
                switch (adventurer.LookDirection)
                {
                    case Humanoid.Direction.LEFT:
                        xPos-= 2;
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
            }
            else{
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
            }

            bool trig = true;

            string text = "There is no-one to talk with in front of you, Are you going insane?";
            foreach (NPC npc in universe.NPCList)
            {
                if (npc.Xpos == xPos && npc.Ypos == yPos)
                {

                    text = npc.messages[npc.listCurrent];
                    npc.listCurrent++;
                    if (npc.Name == "Merchant")
                    {
                        TextBoxViews.MerchantMessage(universe, adventurer);
                        trig = false;
                        QuestTrigger(adventurer, universe, Adventurer.Quest.GoShopping);
                    }
                    else if (npc.Name == "OLD MAN")
                    {
                        QuestTrigger(adventurer, universe, Adventurer.Quest.MeetTheOldMan);
                        trig = false;
                    }
                    else if (npc.listCurrent >= npc.listMax)
                    {
                        npc.listCurrent = 0;
                    }
                    
                    
                }
            }
            if (trig)
            {
                TextBoxViews.WriteToMessageBox(universe, text);
            }
            
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
                    adventurer.LookDirection = Humanoid.Direction.LEFT;

                    if (adventurer.LastDirection == adventurer.LookDirection)
                    {
                        MovementRestriction(adventurer, universe,adventurer.LookDirection);
                    }

                    adventurer.LastDirection = adventurer.LookDirection;

                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.UpArrow:
                    adventurer.LookDirection = Humanoid.Direction.UP;

                    if (adventurer.LastDirection == adventurer.LookDirection)
                    {
                        MovementRestriction(adventurer, universe, adventurer.LookDirection);
                    }

                    adventurer.LastDirection = adventurer.LookDirection;
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.RightArrow:
                    
                    adventurer.LookDirection = Humanoid.Direction.RIGHT;

                    if (adventurer.LastDirection == adventurer.LookDirection)
                    {
                        MovementRestriction(adventurer, universe, adventurer.LookDirection);
                    }

                    adventurer.LastDirection = adventurer.LookDirection;
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;
                case ConsoleKey.DownArrow:
                    adventurer.LookDirection = Humanoid.Direction.DOWN;

                    if (adventurer.LastDirection == adventurer.LookDirection)
                    {
                        MovementRestriction(adventurer, universe, adventurer.LookDirection);
                    }

                    adventurer.LastDirection = adventurer.LookDirection;
                    Console.SetCursorPosition(adventurer.Xpos, adventurer.Ypos);
                    Console.Write("☺");
                    break;

                case ConsoleKey.NumPad0:
                    break;
                case ConsoleKey.NumPad1:
                    NPCTalk(adventurer, universe);
                    break;
                case ConsoleKey.NumPad2:
                    TextBoxViews.DisplayTownDesc(universe);
                    break;
                case ConsoleKey.NumPad3:
                    PlayerLocationss(adventurer, universe);
                    break;
                case ConsoleKey.NumPad4:
                    InventoryManagment(adventurer, universe);
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
                    playing = false;
                    break;


                case ConsoleKey.D1:
                    NPCTalk(adventurer, universe);
                    break;
                case ConsoleKey.D2:
                    TextBoxViews.DisplayTownDesc(universe);
                    break;
                case ConsoleKey.D3:
                    PlayerLocationss(adventurer, universe);
                    break;
                case ConsoleKey.D4:
                    InventoryManagment(adventurer, universe);
                    break;

                case ConsoleKey.D9:
                    playing = false;
                    break;

                default:
                    break;
            }


            return playing;

        }

        /// <summary>
        /// Sets up an inventory to display in the Menu
        /// </summary>
        /// <param name="adventurer"></param>
        public static void InventoryManagment(Adventurer adventurer, Universe universe)
        {
            bool usingInventory = true;
            ConsoleKeyInfo key;
            Dictionary<Item.Items,int> itemList = new Dictionary<Item.Items, int>();
            Item.Items[] itemarray = new Item.Items[10];
            int i = 0;
            foreach (var item in adventurer.PlayerItemsDictionary)
            {

                if (item.Value > 0)
                {
                    itemList.Add(item.Key,item.Value);
                    itemarray[i] = item.Key;
                }
                i++;
            }

            Item.Items itemToUse = Item.Items.Nothing;

            while (usingInventory)
            {
                TextBoxViews.RemoveContent(universe, 3);
                TextBoxViews.DisplayInventory(itemList);
                bool error = false;
                key = Console.ReadKey();
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            itemList[itemarray[0]] -= 1;
                            itemToUse = itemarray[0];
                            break;
                        case ConsoleKey.D2:
                            itemList[itemarray[1]] -= 1;
                            itemToUse = itemarray[1];
                            break;
                        case ConsoleKey.D3:
                            itemList[itemarray[2]] -= 1;
                            itemToUse = itemarray[2];
                            break;
                        case ConsoleKey.D4:
                            itemList[itemarray[3]] -= 1;
                            itemToUse = itemarray[3];
                            break;
                        case ConsoleKey.D5:
                            itemList[itemarray[4]] -= 1;
                            itemToUse = itemarray[4];
                            break;
                        case ConsoleKey.D6:
                            itemList[itemarray[5]] -= 1;
                            itemToUse = itemarray[5];
                            break;
                        case ConsoleKey.D7:
                            itemList[itemarray[6]] -= 1;
                            itemToUse = itemarray[6];
                            break;
                        case ConsoleKey.D8:
                            itemList[itemarray[7]] -= 1;
                            itemToUse = itemarray[7];
                            break;
                        case ConsoleKey.D9:
                            usingInventory = false;
                            break;

                        case ConsoleKey.NumPad1:
                            itemList[itemarray[0]] -= 1;
                            itemToUse = itemarray[0];
                            break;
                        case ConsoleKey.NumPad2:
                            itemList[itemarray[1]] -= 1;
                            itemToUse = itemarray[1];
                            break;
                        case ConsoleKey.NumPad3:
                            itemList[itemarray[2]] -= 1;
                            itemToUse = itemarray[2];
                            break;
                        case ConsoleKey.NumPad4:
                            itemList[itemarray[3]] -= 1;
                            itemToUse = itemarray[3];
                            break;
                        case ConsoleKey.NumPad5:
                            itemList[itemarray[4]] -= 1;
                            itemToUse = itemarray[4];
                            break;
                        case ConsoleKey.NumPad6:
                            itemList[itemarray[5]] -= 1;
                            itemToUse = itemarray[5];
                            break;
                        case ConsoleKey.NumPad7:
                            itemList[itemarray[6]] -= 1;
                            itemToUse = itemarray[6];
                            break;
                        case ConsoleKey.NumPad8:
                            itemList[itemarray[7]] -= 1;
                            itemToUse = itemarray[7];
                            break;
                        case ConsoleKey.NumPad9:
                            usingInventory = false;
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception )
                {
                    error = true;
                    //No throwing in here
                }
                finally
                {
                    if (!error && !(key.Key == ConsoleKey.D9 || key.Key == ConsoleKey.NumPad9))
                    {


                        switch (itemToUse)
                        {
                            case Item.Items.HealthPotion:
                                TextBoxViews.WriteToMessageBox(universe, " You regained 20 health");
                                Adventurer.PlayerPotionHeal(adventurer, universe);
                                adventurer.PlayerItemsDictionary[itemToUse] = itemList[itemToUse];
                                break;
                            case Item.Items.ManaPotion:
                                TextBoxViews.WriteToMessageBox(universe, "You feel all tingly inside");
                                adventurer.PlayerItemsDictionary[itemToUse] = itemList[itemToUse];
                                break;
                            case Item.Items.Stone:
                                TextBoxViews.WriteToMessageBox(universe, "You throw the stone and it vanishes into the distance...");
                                adventurer.PlayerItemsDictionary[itemToUse] = itemList[itemToUse];
                                break;
                            case Item.Items.SlimeGel:
                                TextBoxViews.WriteToMessageBox(universe, "You cannot use slime...");
                                break;
                            case Item.Items.Parcel:
                                TextBoxViews.WriteToMessageBox(universe, "You cannot use the parcel you are delivering!");

                                break;
                            case Item.Items.Nothing:
                                TextBoxViews.WriteToMessageBox(universe, "There is nothing there");

                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if ((key.Key != ConsoleKey.D9 || key.Key != ConsoleKey.NumPad9))
                        {
                            TextBoxViews.WriteToMessageBox(universe, "You dont have that item");
                        }
                        
                    }
                }
                
            }


            TextBoxViews.DisplayMenu(universe);
        }

        /// <summary>
        /// Lets you purchase from a merchant
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="adventurer"></param>
        public static void MerchantBuy(Universe universe, Adventurer adventurer)
        {
            ConsoleKeyInfo consoleKey;
            bool keepShopping = true;
            Dictionary<Item.Items, int> itemToPurchase = new Dictionary<Item.Items, int>();

            TextBoxViews.MerchMenu(universe);

            Item.Items item = Item.Items.SlimeGel;
            while (keepShopping)
            {
                bool purchase = false;
                bool chooseSomething = true;
                

                int cost = 0;

                while (chooseSomething)
                {
                    consoleKey = Console.ReadKey();

                    switch (consoleKey.Key)
                    {

                        case ConsoleKey.NumPad1:

                            item = Item.Items.HealthPotion;

                            itemToPurchase[item] = HowMany(universe, Item.Items.HealthPotion);

                            cost = 20 * itemToPurchase[item];

                            chooseSomething = false;
                            break;
                        case ConsoleKey.D1:
                            item = Item.Items.HealthPotion;

                            itemToPurchase[item] = HowMany(universe, Item.Items.HealthPotion);

                            cost = 20 * itemToPurchase[item];

                            chooseSomething = false;

                            break;

                        case ConsoleKey.NumPad2:
                            item = Item.Items.ManaPotion;

                            itemToPurchase[item] = HowMany(universe, Item.Items.ManaPotion);

                            cost = 20 * itemToPurchase[item];

                            chooseSomething = false;
                            break;

                        case ConsoleKey.D2:
                            item = Item.Items.ManaPotion;

                            itemToPurchase[item] = HowMany(universe, Item.Items.ManaPotion);

                            cost = 20 * itemToPurchase[item];

                            chooseSomething = false;
                            break;


                        case ConsoleKey.NumPad3:
                            item = Item.Items.Stone;

                            itemToPurchase[item] = HowMany(universe, Item.Items.Stone);

                            cost = 2 * itemToPurchase[item];

                            

                            chooseSomething = false;
                            break;

                        case ConsoleKey.D3:
                            item = Item.Items.Stone;

                            itemToPurchase[item] = HowMany(universe, Item.Items.Stone);

                            cost = 2 * itemToPurchase[item];



                            chooseSomething = false;
                            break;


                        case ConsoleKey.NumPad9:
                            keepShopping = false;
                            chooseSomething = false;
                            break;

                        case ConsoleKey.D9:
                            keepShopping = false;
                            chooseSomething = false;
                            break;

                        default:
                            TextBoxViews.ReWriteToMessageBox(universe, "Please choose something I have and not the air please.",true);
                            break;
                    }
                }

                //Prints question
                TextBoxViews.ReWriteToMessageBox(universe,"So you want to buy " + itemToPurchase[item] + " " + item + "(s) for " + cost + " gold? Yes/No", true);

                //Gets user input
                purchase = Validators.ValidYesNo();

                //checks if the player has enough coins
                if (purchase && (adventurer.Coins >= cost))
                {
                    adventurer.PlayerItemsDictionary[item] = itemToPurchase[item];
                    adventurer.Coins -= cost;

                    TextBoxViews.ReWriteToMessageBox(universe, "Thanks for buyin", true);


                }

                else if (purchase && !(adventurer.Coins >= cost))
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "Hey! You dont have enough to buy that!!!", true);
                }

                else if (!purchase)
                {
                    TextBoxViews.ReWriteToMessageBox(universe, "Keep Shopping?", true);

                    keepShopping = Validators.ValidYesNo();
                }
                TextBoxViews.DisplayPlayerInfo(adventurer);
            }

        }

        /// <summary>
        /// Asks the user how many of the item they wish to buy
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int HowMany(Universe universe, Item.Items item)
        {
            TextBoxViews.ReWriteToMessageBox(universe,"How many " + item + "s would you like?", true);


            return Validators.ValidInt();
        }


        public static void MovementRestriction(Adventurer adventurer, Universe universe,Humanoid.Direction direction)
        {
            if (adventurer.InaHouse)
            {
                if (!(adventurer.Xpos < universe.HouseLayouts[0].startXPos + 2) && (direction == Humanoid.Direction.LEFT))
                {
                    adventurer.Xpos--;
                }
                if (!(adventurer.Ypos < universe.HouseLayouts[0].startYPos + 2) && (direction == Humanoid.Direction.UP))
                {
                    adventurer.Ypos--;
                }
                if (!(adventurer.Xpos > universe.HouseLayouts[0].endXPos - 2) && (direction == Humanoid.Direction.RIGHT))
                {
                    adventurer.Xpos++;
                }
                if (!(adventurer.Ypos > universe.HouseLayouts[0].endYPos - 2) && (direction == Humanoid.Direction.DOWN))
                {
                    adventurer.Ypos++;
                }
                else if (adventurer.Xpos == 56 && adventurer.Ypos == 32 && (direction == Humanoid.Direction.DOWN))
                {
                    adventurer.Ypos++;
                }
            }
            else
            {
                if (!(adventurer.Xpos < 3) && (direction == Humanoid.Direction.LEFT))
                {
                    adventurer.Xpos--;
                }
                if (!(adventurer.Ypos < 7) && (direction == Humanoid.Direction.UP))
                {
                    adventurer.Ypos--;
                }
                if (!(adventurer.Xpos > 102) && (direction == Humanoid.Direction.RIGHT))
                {
                    adventurer.Xpos++;
                }
                if (!(adventurer.Ypos > 52) && (direction == Humanoid.Direction.DOWN))
                {
                    adventurer.Ypos++;
                }
            }
            

        }

        /// <summary>
        /// USE THIS FOR TRIGGERING QUEST EVENTS
        /// </summary>
        /// <param name="adventurer"></param>
        /// <param name="universe"></param>
        /// <param name="quest"></param>
        public static void QuestTrigger(Adventurer adventurer, Universe universe, Adventurer.Quest quest)
        {
            //If this triggers true then   ---Should have any extra checks?
            if (adventurer.CurrentQuest == quest)
            {
                if (!adventurer.QuestCompletion[adventurer.CurrentQuest])
                {
                    adventurer.QuestCompletion[adventurer.CurrentQuest] = true;
                }
                
            }
            
        }
    }
}
