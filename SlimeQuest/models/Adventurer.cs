using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Adventurer : Humanoid
    {
        #region Enums
        
        public enum Quest
        {
            MeetTheOldMan,
            GoHome,
            GoShopping,
            LeaveHome,
            TheNewGuyInTown,
            DeliverTheParcel,
            FightTheCaveTrio

        }
        public enum Weapon
        {
            Sword,
            BroadSword,
            Bow,
            Dagger,
            Staff,
            Mace

        }
        #endregion  

        private Quest _currentQuest;
        private Dictionary<Quest,bool> _quest;
        private bool[] _questDone;

        

        private int _age;
        private int _health;
        private Weapon _weapon;
        private List<Humanoid.Location> _prevLoc;

        private bool _inaHouse;



        private Dictionary<Item.Items, int> _playerItems;
        private int _invPageNum;

        private int _coins;

        





        public Quest CurrentQuest
        {
            get { return _currentQuest; }
            set { _currentQuest = value; }
        }
        public Dictionary<Quest, bool> QuestCompletion
        {
            get { return _quest; }
            set { _quest = value; }
        }
        public bool[] QuestDone
        {
            get { return _questDone; }
            set { _questDone = value; }
        } 

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Weapon PlayerWeapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }
        public List<Humanoid.Location> PreviousLocations
        {
            get { return _prevLoc; }
            set { _prevLoc = value; }
        }

        public bool InaHouse
        {
            get { return _inaHouse; }
            set { _inaHouse = value; }
        }


        public Dictionary<Item.Items, int> ItemsDictionary
        {
            get { return _playerItems; }
            set { _playerItems = value; }
        }
        public int InventoryPageNumber
        {
            get { return _invPageNum; }
            set { _invPageNum = value; }
        }

        public int Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }





        #region Initializers
        public static Dictionary<Quest,bool> InstantiateQuests()
        {
            Dictionary<Quest, bool> questTriggerList = new Dictionary<Quest, bool>();
            questTriggerList.Add(Quest.MeetTheOldMan,false);
            questTriggerList.Add(Quest.GoHome,false);
            questTriggerList.Add(Quest.GoShopping, false);
            questTriggerList.Add(Quest.LeaveHome,false);
            questTriggerList.Add(Quest.TheNewGuyInTown,false);
            questTriggerList.Add(Quest.DeliverTheParcel, false);
            questTriggerList.Add(Quest.FightTheCaveTrio, false);


            return questTriggerList;
        }
        public static Dictionary<Item.Items,int> InstantiateInventory()
        {
            Dictionary<Item.Items, int> PlayerItemsDictionay = new Dictionary<Item.Items, int>();
            PlayerItemsDictionay.Add(Item.Items.HealthPotion, 0);
            PlayerItemsDictionay.Add(Item.Items.ManaPotion, 0);
            PlayerItemsDictionay.Add(Item.Items.Stone, 0);
            PlayerItemsDictionay.Add(Item.Items.SlimeGel, 0);
            PlayerItemsDictionay.Add(Item.Items.Parcel, 0);

            return PlayerItemsDictionay;
        }
        public static bool[] InstantiateQuestCompletionMessageCheck()
        {
            bool[] questtrigger = new bool[7]
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };
            return questtrigger;
        }

        #endregion


        #region Methods

        public static void PlayerPotionHeal(Adventurer adventurer, Universe universe)
        {
            TextBoxViews.WriteToMessageBox(universe,"You drank the health potion and healed for 20 health");
            adventurer.Health += 20;

            if(adventurer.Health > 100)
            {
                adventurer.Health = 100;
            }
        }


        #endregion
    }
}
