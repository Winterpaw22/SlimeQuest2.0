using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Item
    {

        public enum Items
        {
            Nothing,
            HealthPotion,
            ManaPotion,
            Stone,
            SlimeGel,
            Parcel
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public Humanoid.Location worldLoc { get; set; }
        public House.houseName houseLoc { get; set; }
        public Items ItemType { get; set; }

    }
}
