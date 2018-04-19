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
            None,
            PlayerHome,
            HealHouse,
            Market,
            CerryHouse,
            AmastaHouse,
            AristaHouse

        }

        public bool PlayerInside { get; set; }
        public houseName HouseName { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int[] EnterPosition { get; set; }
        public HouseLayout.Type Houselayout { get; set; }
        public Humanoid.Location HouseLoc { get; set; }
        public ConsoleColor HouseColor { get; set; }
    
    }
}
