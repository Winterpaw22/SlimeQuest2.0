using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SlimeQuest
{
    class Universe
    {
        public Windows[] GameWindows { get; set; }
        public List<NPC> NPCList { get; set; }
        public List<Towns> TownList { get; set; }
        public List<Foiliage> FoiliageList { get; set; }
        public List<House> HouseList { get; set; }
        public HouseLayout[] HouseLayouts { get; set; }
        public List<Furniture> FurnitureList { get; set; }
        public List<Item> ItemList { get; set; }
        public List<BadGuy> TripleTrouble { get; set; }



        private HouseLayout[] InitializeHouseTypes()
        {
            HouseLayouts = new HouseLayout[]
            {
                new HouseLayout
                {
                    startXPos = 33,
                    startYPos = 17,
                    endXPos = 78,
                    endYPos = 33,
                    houseType = HouseLayout.Type.House1
                    
                },
                new HouseLayout
                {
                    startXPos = 33,
                    startYPos = 17,
                    endXPos = 78,
                    endYPos = 33,
                    houseType = HouseLayout.Type.Market

                }

            };
            return HouseLayouts;
        }

        private List<House> InitializeAllHouses()
        {
            HouseList = new List<House>
            {
                new House
                {
                    Xpos = 26,
                    Ypos = 23,
                    PlayerInside = false,
                    EnterPosition = new int[2]{29,26},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.TutTown,
                    HouseName = House.houseName.PlayerHome,
                    HouseColor = ConsoleColor.DarkCyan
                },
                new House
                {
                    Xpos = 75,
                    Ypos = 23,
                    PlayerInside = false,
                    EnterPosition = new int[2]{78,26},
                    Houselayout = HouseLayout.Type.Market,
                    //Flag a check for this location on map
                    HouseLoc = Humanoid.Location.TutTown,
                    HouseName = House.houseName.Market,
                    HouseColor = ConsoleColor.Blue
                },


                new House
                {
                    Xpos = 26,
                    Ypos = 23,
                    PlayerInside = false,
                    EnterPosition = new int[2]{29,26},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.CherryGrove,
                    HouseName = House.houseName.CerriHouse,
                    HouseColor = ConsoleColor.DarkMagenta
                },
                new House
                {
                    Xpos = 36,
                    Ypos = 33,
                    PlayerInside = false,
                    EnterPosition = new int[2]{39,36},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.CherryGrove,
                    HouseName = House.houseName.AristaHouse,
                    HouseColor = ConsoleColor.Red
                },
                new House
                {
                    Xpos = 70,
                    Ypos = 23,
                    PlayerInside = false,
                    EnterPosition = new int[2]{73,26},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.CherryGrove,
                    HouseName = House.houseName.Market,
                    HouseColor = ConsoleColor.Blue
                },
                new House
                {
                    Xpos = 65,
                    Ypos = 33,
                    PlayerInside = false,
                    EnterPosition = new int[2]{68,36},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.CherryGrove,
                    HouseName = House.houseName.AmastaHouse,
                    HouseColor = ConsoleColor.DarkRed
                },
            };
            return HouseList;
        }
        
        private List<Furniture> InitializeAllFurniture()
        {
            List<Furniture> furniture = new List<Furniture>
            {
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Counter,
                    House = House.houseName.Market,
                    Xpos = 34,
                    Ypos = 18
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Table,
                    House = House.houseName.Market,
                    Xpos = 39,
                    Ypos = 22
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Desk,
                    House = House.houseName.Market,
                    Xpos = 42,
                    Ypos = 29
                },

                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Desk,
                    House = House.houseName.Market,
                    Xpos = 59,
                    Ypos = 29
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Desk,
                    House = House.houseName.Market,
                    Xpos = 66,
                    Ypos = 29
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Table,
                    House = House.houseName.Market,
                    Xpos = 64,
                    Ypos = 22
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Table,
                    House = House.houseName.Market,
                    Xpos = 71,
                    Ypos = 19
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Bed,
                    House = House.houseName.PlayerHome,
                    Xpos = 74,
                    Ypos = 18
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Desk,
                    House = House.houseName.PlayerHome,
                    Xpos = 35,
                    Ypos = 20
                },
                new Furniture
                {
                    FurnituretOb = Furniture.FurnitureType.Table,
                    House = House.houseName.PlayerHome,
                    Xpos = 40,
                    Ypos = 20
                },
            };
            return furniture;
        }

        private List<Foiliage> InitializeAllPlants()
        {
            FoiliageList = new List<Foiliage>
            {
                new Foiliage
                {
                    XPos = 23,
                    YPos = 9,
                    CharIcon = "tree",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.DarkGreen,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 11,
                    YPos = 27,
                    CharIcon = "tree",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.DarkGreen,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 65,
                    YPos = 10,
                    CharIcon = "tree",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.DarkGreen,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 85,
                    YPos = 16,
                    CharIcon = "tree",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.DarkGreen,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 30,
                    YPos = 42,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Grass,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 47,
                    YPos = 30,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Grass,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.MainWorld
                },
                new Foiliage
                {
                    XPos = 3,
                    YPos = 50,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Grass,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },

                new Foiliage
                {
                    XPos = 31,
                    YPos = 12,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 23,
                    YPos = 18,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 90,
                    YPos = 18,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 94,
                    YPos = 28,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 87,
                    YPos = 38,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Tree,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
                new Foiliage
                {
                    XPos = 51,
                    YPos = 20,
                    CharIcon = "*",
                    Plant = Foiliage.plantType.Fountain,
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.CherryGrove
                },
            };
            return FoiliageList;
        }

        private List<NPC> InitializeAllNPC()
        {
            NPCList = new List<NPC>
            {
                new NPC
                {
                    Name = "OLD MAN",
                    charIcon = "O",
                    greeting = "Hello traveller, Are you fairing well?",
                    messages = new List<string>
                    {
                        "Hello, My name is OLD MAN",
                        "I am the great elder of this village",
                        "Items are represented as +",
                        "People are represented as a letter of the alphabet",
                        "Follow quests to complete the game",
                        "Other towns are represented by numbers",
                        "How may I assist you young one"
                    },
                    listCurrent = 0,
                    listMax = 7,
                    Gender = true,
                    MapLocation = Humanoid.Location.TutTown,
                    InHouseName = House.houseName.None,
                    Xpos = 75,
                    Ypos = 8,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "Jerry",
                    charIcon = "J",
                    greeting = "Hello traveller",
                    messages = new List<string>
                    {
                        $"Hello, My name is Jerry. ",
                        "Hey, Have you seen outside the town yet? I hear it looks like a wasteland out there.",
                        "I have been glued to the ground..."
                    },
                    listCurrent = 0,
                    listMax = 3,

                    Gender = true,
                    MapLocation = Humanoid.Location.TutTown,
                    InHouseName = House.houseName.None,
                    Xpos = 30,
                    Ypos = 8,
                    PlayerRace = Humanoid.Race.Human
                },
                new NPC
                {
                    Name = "Sarah",
                    charIcon = "S",
                    greeting = "Unusual?",
                    Gender = true,
                    MapLocation = Humanoid.Location.TutTown,
                    messages = new List<string>{
                        "HI! My name is Sarah... I dunno where I am at.."
                        },
                    InHouseName = House.houseName.None,
                    listCurrent = 0,
                    listMax = 1,
                    Xpos = 35,
                    Ypos = 40,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "Petchka",
                    charIcon = "P",
                    greeting = "Hello traveller, Are you fairing well?",
                    Gender = true,
                    MapLocation = Humanoid.Location.Cave,
                    InHouseName = House.houseName.None,
                    messages = new List<string>
                    {
                        "Please leave my cave..."
                    },
                    listCurrent = 0,
                    listMax = 1,
                    Xpos = 60,
                    Ypos = 30,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "Merchant",
                    charIcon = "M",
                    greeting = "Hello traveller, Are you fairing well?",
                    messages = new List<string>
                    {
                        " ",
                        " "
                    },
                    listCurrent = 0,
                    listMax = 2,
                    Gender = true,
                    MapLocation = Humanoid.Location.None,
                    InHouseName = House.houseName.Market,
                    Xpos = 35,
                    Ypos = 18,
                    PlayerRace = Humanoid.Race.Human
                },
                new NPC
                {
                    Name = "Cerri",
                    charIcon = "C",
                    greeting = "Hello traveller, Are you fairing well?",
                    messages = new List<string>
                    {
                        "Hi, I lost my parcel. Could you please find it for me? ",
                        "Have you found my parcel",
                        "Please find my parcel"
                    },
                    listCurrent = 0,
                    listMax = 3,
                    Gender = false,
                    MapLocation = Humanoid.Location.CherryGrove,
                    InHouseName = House.houseName.None,
                    Xpos = 35,
                    Ypos = 18,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "Amasta",
                    charIcon = "A",
                    greeting = "Hello traveller, Are you fairing well?",
                    messages = new List<string>
                    {
                        "Fight Slimes and Level up ",
                        "Brute strength wins every time",
                        "HOO RAAAAAHHHH"
                    },
                    listCurrent = 0,
                    listMax = 3,
                    Gender = true,
                    MapLocation = Humanoid.Location.None,
                    InHouseName = House.houseName.AmastaHouse,
                    Xpos = 38,
                    Ypos = 18,
                    PlayerRace = Humanoid.Race.Orc
                },
                new NPC
                {
                    Name = "Arista",
                    charIcon = "A",
                    greeting = "Hello traveller, Are you fairing well?",
                    messages = new List<string>
                    {
                        "Here, Let me heal those wounds of yours",
                        "How could a little slime hurt you so much?",
                        "Are you ok?",
                        "Remember to buy potions befroe entering big battles"
                    },
                    listCurrent = 0,
                    listMax = 3,
                    Gender = true,
                    MapLocation = Humanoid.Location.None,
                    InHouseName = House.houseName.AristaHouse,
                    Xpos = 40,
                    Ypos = 25,
                    PlayerRace = Humanoid.Race.Slime
                },
            };
            return NPCList;
        }

        public static List<BadGuy> InitializeAllEvil()
        {
            List<BadGuy> TripleTrouble = new List<BadGuy>
            {
                new BadGuy
                {
                    Defeated = false,
                    Gender = true,
                    InHouseName = House.houseName.None,
                    LastDirection = Humanoid.Direction.DOWN,
                    LookDirection = Humanoid.Direction.DOWN,
                    MapLocation = Humanoid.Location.Cave,
                    Name = "TrioMember 1",
                    PlayerRace = Humanoid.Race.Slime,
                    charIcon = "a",
                    present = false,
                    Xpos = 53,
                    Ypos = 22

                },
                new BadGuy
                {
                    Defeated = false,
                    Gender = false,
                    InHouseName = House.houseName.None,
                    LastDirection = Humanoid.Direction.DOWN,
                    LookDirection = Humanoid.Direction.DOWN,
                    MapLocation = Humanoid.Location.Cave,
                    Name = "TrioMember 2",
                    PlayerRace = Humanoid.Race.Slime,
                    charIcon = "a",
                    present = false,
                    Xpos = 47,
                    Ypos = 22

                },
                new BadGuy
                {
                    Defeated = false,
                    Gender = true,
                    InHouseName = House.houseName.None,
                    LastDirection = Humanoid.Direction.DOWN,
                    LookDirection = Humanoid.Direction.DOWN,
                    MapLocation = Humanoid.Location.Cave,
                    Name = "TrioMember 3",
                    PlayerRace = Humanoid.Race.Slime,
                    charIcon = "a",
                    present = false,
                    Xpos = 50,
                    Ypos = 20

                },
            };
            return TripleTrouble;
        }

        private List<Item> InitializeAllItems()
        {
            ItemList = new List<Item>
            {
                new Item
                {
                    XPos = 49,
                    YPos = 8,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.TutTown,
                    ItemType = Item.Items.SlimeGel,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 11,
                    YPos = 18,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.TutTown,
                    ItemType = Item.Items.ManaPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 96,
                    YPos = 33,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.TutTown,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 31,
                    YPos = 46,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.TutTown,
                    ItemType = Item.Items.Stone,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 85,
                    YPos = 27,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.MainWorld,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 85,
                    YPos = 10,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.MainWorld,
                    ItemType = Item.Items.ManaPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 31,
                    YPos = 13,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.MainWorld,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 24,
                    YPos = 42,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.MainWorld,
                    ItemType = Item.Items.SlimeGel,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 86,
                    YPos = 37,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.MainWorld,
                    ItemType = Item.Items.SlimeGel,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 57,
                    YPos = 21,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.CherryGrove,
                    ItemType = Item.Items.Parcel,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 14,
                    YPos = 24,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.CherryGrove,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 32,
                    YPos = 16,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.CherryGrove,
                    ItemType = Item.Items.ManaPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 12,
                    YPos = 16,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.CherryGrove,
                    ItemType = Item.Items.Stone,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 39,
                    YPos = 18,
                    houseLoc = House.houseName.PlayerHome,
                    worldLoc = Humanoid.Location.None,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 40,
                    YPos = 18,
                    houseLoc = House.houseName.PlayerHome,
                    worldLoc = Humanoid.Location.None,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                },
                new Item
                {
                    XPos = 41,
                    YPos = 18,
                    houseLoc = House.houseName.None,
                    worldLoc = Humanoid.Location.CherryGrove,
                    ItemType = Item.Items.HealthPotion,
                    itemTaken = false
                }
            }; 
            return ItemList;
        }

        private List<Towns> InitializeAllTowns()
        {
            List<Towns> towns = new List<Towns>
            {
                new Towns
                {
                    TownLocName = Humanoid.Location.TutTown,
                    InTown = true,
                    MapIcon = "1",
                    TownDesc = "A small town with a few houses, trees, bushes, and some people standing around",
                    Xpos = 20,
                    Ypos = 20
                },
                new Towns
                {
                    TownLocName = Humanoid.Location.CherryGrove,
                    InTown = false,
                    MapIcon = "2",
                    TownDesc = "A small town with a few houses, trees, bushes, a fountain in the middle of the town and some people standing around",
                    Xpos = 70,
                    Ypos = 40
                },
                new Towns
                {
                    TownLocName = Humanoid.Location.MainWorld,
                    InTown = false,
                    MapIcon = "",
                    TownDesc = "A field of trees, bushes, and rocks",
                    Xpos = 0,
                    Ypos = 0
                },
                new Towns
                {
                    TownLocName = Humanoid.Location.Cave,
                    InTown = false,
                    MapIcon = "C",
                    TownDesc = "A dark cave... Air feels moist... ",
                    Xpos = 50,
                    Ypos = 15
                }
            };
            return towns;
        }

        public Universe InitializeUniverse(Windows[] windows)
        {

            Universe universe = new Universe
            {
                NPCList = InitializeAllNPC(),
                TownList = InitializeAllTowns(),
                HouseList = InitializeAllHouses(),
                FoiliageList = InitializeAllPlants(),
                HouseLayouts = InitializeHouseTypes(),
                FurnitureList = InitializeAllFurniture(),
                ItemList = InitializeAllItems(),
                TripleTrouble = InitializeAllEvil(),
                GameWindows = windows
            };
            
            
            return universe;
        }
        public string ReturnTownDescription(Universe universe)
        {
            string townDesc = "You cannot seem to see anything";
            foreach (Towns town in universe.TownList)
            {
                if (town.InTown)
                {
                    townDesc = town.TownDesc;
                }

            }
            return townDesc;

        }
        

    }
}
