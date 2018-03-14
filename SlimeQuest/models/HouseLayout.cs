using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class HouseLayout
    {
        public enum Type
        {
            House1,
            House2,
            MedCenter,
            Market

        }
        public Type houseType { get; set; }
        public int startXPos { get; set; }
        public int startYPos { get; set; }
        public int endXPos { get; set; }
        public int endYPos { get; set; }

    }
}

