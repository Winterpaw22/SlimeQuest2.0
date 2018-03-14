using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Foiliage
    {
        private int _xPos;

        private int _yPos;

        private string  _charIcon;

        private ConsoleColor _color;

        private Humanoid.Location _location;

     
        public int XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        public int YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        public string CharIcon
        {
            get { return _charIcon; }
            set { _charIcon = value; }
        }
        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Humanoid.Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

    }
}
