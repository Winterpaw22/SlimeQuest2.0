using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Furniture
    {
        public enum FurnitureType
        {
            Counter,
            Desk,
            Table,
            Bed

        }


        private int _yPos;
        private int _xPos;
        private House.houseName _house;
        private FurnitureType _furniture;


        public int Ypos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }
        public int Xpos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        public House.houseName House
        {
            get { return _house; }
            set { _house = value; }
        }
        public FurnitureType FurnituretOb
        {
            get { return _furniture; }
            set { _furniture = value; }
        }

    }
}
