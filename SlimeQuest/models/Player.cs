using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Player
    {
        public enum Race
        {
            Human,
            Slime,
            Elve,
            Orc
        }



        private string _name;
        private int _xPosition;
        private int _yPosition;
        private Race _race;

        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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




    }
}
