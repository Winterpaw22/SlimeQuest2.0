using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Humanoid
    {
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
        public enum Race
        {
            Human,
            Slime,
            Elve,
            Orc
        }
        public enum Location
        {
            None,
            MainWorld,
            TutTown,
            CherryGrove,
            Cave
        }

        

        private string _name;
        private bool _gender;
        private int _xPosition;
        private int _yPosition;
        private Race _race;
        private Location _location;

        private Direction _direction;
        private Direction _lastDirection;

        
        private House.houseName _inHouseName;





        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public int Xpos
        {
            get { return _xPosition; }
            set { _xPosition = value; }
        }
        public int Ypos
        {
            get { return _yPosition; }
            set { _yPosition = value; }
        }
        public Race PlayerRace
        {
            get { return _race; }
            set { _race = value; }
        }
        public Location MapLocation
        {
            get { return _location; }
            set { _location = value; }
        }
        public Direction LookDirection
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public Direction LastDirection
        {
            get { return _lastDirection; }
            set { _lastDirection = value; }
        }
        public House.houseName InHouseName
        {
            get { return _inHouseName; }
            set { _inHouseName = value; }
        }

    }
}
