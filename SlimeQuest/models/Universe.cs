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


        private void InitializeHouseTypes()
        {
            HouseLayouts = new HouseLayout[]
            {
                new HouseLayout
                {
                    startXPos = 25,
                    startYPos = 28,
                    endXPos = 60,
                    endYPos = 48,
                    houseType = HouseLayout.Type.House1
                }

            };
        }

        private List<House> InitializeAllHouses()
        {
            HouseList = new List<House>
            {
                new House
                {
                    Xpos = 26,
                    Ypos = 23,
                    EnterPosition = new int[2]{29,24},
                    Houselayout = HouseLayout.Type.House1,
                    HouseLoc = Humanoid.Location.TutTown,
                    HouseName = House.houseName.PlayerHome
                },
                new House
                {
                    Xpos = 75,
                    Ypos = 23,
                    EnterPosition = new int[2]{72,24},
                    Houselayout = HouseLayout.Type.MedCenter,
                    HouseLoc = Humanoid.Location.TutTown,
                    HouseName = House.houseName.HealHouse
                }
            };
            return HouseList;
        }
        

        private List<Foiliage> InitializeAllPlants()
        {
            FoiliageList = new List<Foiliage>
            {
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
                    Color = ConsoleColor.Green,
                    Location = Humanoid.Location.TutTown
                },
                new Foiliage
                {
                    XPos = 0,
                    YPos = 0,
                    CharIcon = "*",
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
                    Xpos = 75,
                    Ypos = 8,
                    PlayerRace = Humanoid.Race.Elve
                },
                new NPC
                {
                    Name = "TestName2",
                    charIcon = "H",
                    greeting = "Hello traveller",
                    messages = new List<string>
                    {
                        "Hello, My name is TestName2",
                        "Hello, This is a test to see what is possible withthe current textwrap setup. Talking to NPC Testname2 Game still early in development with not many bugs to destroy. Game Functionality going well and there appear to be no problems that need to be discussed",
                        "Fix"
                    },
                    listCurrent = 0,
                    listMax = 3,

                    Gender = true,
                    MapLocation = Humanoid.Location.TutTown,
                    Xpos = 30,
                    Ypos = 8,
                    PlayerRace = Humanoid.Race.Human
                },
                new NPC
                {
                    Name = "TestName2",
                    charIcon = "S",
                    greeting = "Hello traveller, Are you fairing well?",
                    Gender = true,
                    MapLocation = Humanoid.Location.MainWorld,
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
                    listCurrent = 0,
                    listMax = 1,
                    Xpos = 60,
                    Ypos = 30,
                    PlayerRace = Humanoid.Race.Elve
                }
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
                GameWindows = windows
                
                
            };
            InitializeHouseTypes();

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
