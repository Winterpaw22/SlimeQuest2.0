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
            LeaveHome,
            TheNewGuyInTown

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
        private int _age;
        private int _health;
        private Weapon _weapon;
        private List<Humanoid.Location> _prevLoc;


       
        public Quest CurrentQuest
        {
            get { return _currentQuest; }
            set { _currentQuest = value; }
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
    }
}
