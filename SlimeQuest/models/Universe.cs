using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Universe
    {
        private Windows[] windows;
        private List<NPC> _npc;
        private List<Towns> _townList;
        private List<Foiliage> _foiliageList;
        private List<House> _houseList;
        private HouseLayout[] _houseLayouts;
        private List<Furniture> _furnitureList;



        #region GETS and SETS
        public Windows[] GameWindows
        {
            get { return windows; }
            set { windows = value; }
        }

        public List<Towns> TownList
        {
            get { return _townList; }
            set { _townList = value; }
        }

        public List<NPC> NPCList
        {
            get { return _npc; }
            set { _npc = value; }
        }

        public List<Foiliage> FoiliageList
        {
            get { return _foiliageList; }
            set { _foiliageList = value; }
        }

        public List<House> HouseList
        {
            get { return _houseList; }
            set { _houseList = value; }
        }

        public HouseLayout[] HouseLayouts
        {
            get { return _houseLayouts; }
            set { _houseLayouts = value; }
        }
        public List<Furniture> FurnitureList
        {
            get { return _furnitureList; }
            set { _furnitureList = value; }
        }
        #endregion


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
                }
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
                    Location = Humanoid.Location.DefaultNameTown
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
                }
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
                        "How may I assist you young one"
                    },
                    listCurrent = 0,
                    listMax = 3,
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
                        "I dont know why I cannot move..."
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
                    MapLocation = Humanoid.Location.MainWorld,
                    messages = new List<string>{
                        "HI! My name is Sarah... I dunno where I am at.."
                        },
                    InHouseName = House.houseName.None,
                    listCurrent = 0,
                    listMax = 1,
                    Xpos = 30,
                    Ypos = 20,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "TestName",
                    charIcon = "O",
                    greeting = "Hello traveller, Are you fairing well?",
                    Gender = true,
                    MapLocation = Humanoid.Location.Cave,
                    InHouseName = House.houseName.None,
                    messages = new List<string>
                    {
                        "Please leave my cave.."
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
            };
            return NPCList;
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
                    TownLocName = Humanoid.Location.DefaultNameTown,
                    InTown = false,
                    MapIcon = "2",
                    TownDesc = "A small town with a few houses, trees, bushes, and some people standing around",
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
                    TownDesc = "A dark cave, Air feels moist... ",
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
