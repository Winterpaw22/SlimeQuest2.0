using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class BadGuy : Humanoid
    {
        public bool Defeated { get; set; }

        public bool present { get; set; }

        public string charIcon { get; set; }
    }
}
