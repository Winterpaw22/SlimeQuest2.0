using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class NPC : Humanoid
    {
        public string charIcon { get; set; }
        public List<string> messages { get; set; }
        public int listCurrent { get; set; }
        public int listMax { get; set; }
        public bool trigger { get; set; }

        public bool present { get; set; }
        public string greeting { get; set; }
        public virtual string NPCTalkResponse(Adventurer adventurer)
        {
            return $"{greeting} , {adventurer.Name}";
        }

    }

}

