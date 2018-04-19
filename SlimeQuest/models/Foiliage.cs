using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Foiliage
    {
        public enum plantType
        {
            Tree,
            Grass,
            Flower,
            Field
        }

        


        private int _xPos;

        private int _yPos;

        private int _xEnd;

        private int _yEnd;


        private string  _charIcon;

        private ConsoleColor _color;

        private Humanoid.Location _location;

        private plantType _plant;

        


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

        public int XEnd
        {
            get { return _xEnd; }
            set { _xEnd = value; }
        }

        public int YEnd
        {
            get { return _yEnd; }
            set { _yEnd = value; }
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

        public plantType Plant
        {
            get { return _plant; }
            set { _plant = value; }
        }
    }
}
