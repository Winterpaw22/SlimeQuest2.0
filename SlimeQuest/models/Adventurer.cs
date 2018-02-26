using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Adventurer : Player
    {
        #region Enums
        public enum Location
        {
            MainWorld,
            TutTown,
            DefaultNameTown,
            Cave
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



        private int _age;
        private int _health;
        private Location _location;
        private Weapon _weapon;
        private Windows[] windows;

        




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
        

        public Location MapLocation
        {
            get { return _location; }
            set { _location = value; }
        }

        public Weapon PlayerWeapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public Windows[] GameWindows
        {
            get { return windows; }
            set { windows = value; }
        }

    }
}
