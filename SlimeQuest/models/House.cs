using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class House
    {
        //Can be a string or an Enum
        public enum houseName
        {
            PlayerHome,
            HealHouse,
            Market,
            CerryHouse,
            AmastaHouse,
            AristaHouse

        }
        private string _name;
        private houseName _house;
        private int _xPos;
        private int _yPos;
        private int[] _enterPos;
        private HouseLayout.Type _houseLayout;
        private Humanoid.Location _houseLocation;










        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public houseName HouseName
        {
            get { return _house; }
            set { _house = value; }
        }
        public int Xpos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        public int Ypos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }
        public int[] EnterPosition
        {
            get { return _enterPos; }
            set { _enterPos = value; }
        }
        public HouseLayout.Type Houselayout
        {
            get { return _houseLayout; }
            set { _houseLayout = value; }
        }
        public Humanoid.Location HouseLoc
        {
            get { return _houseLocation; }
            set { _houseLocation = value; }
        }

    }
}
