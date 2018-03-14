using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Towns
    {
        private int _xPos;
        private int _yPos;
        private string _mapIcon;
        private bool _inTown;
        private string _townDescription;
        private Humanoid.Location _townLocName;

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
        public string MapIcon
        {
            get { return _mapIcon; }
            set { _mapIcon = value; }
        }
        public bool InTown
        {
            get { return _inTown; }
            set { _inTown = value; }
        }
        public string TownDesc
        {
            get { return _townDescription; }
            set { _townDescription = value; }
        }
        public Humanoid.Location TownLocName
        {
            get { return _townLocName; }
            set { _townLocName = value; }
        }

        
        

        

        

    }
}
