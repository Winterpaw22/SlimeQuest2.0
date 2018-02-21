using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Windows
    {
        private int _xposStart;

        private int _yposStart;

        private int _xposEnd;

        private int _yposEnd;



        public int YStart
        {
            get { return _yposStart; }
            set { _yposStart = value; }
        }
        public int XStart
        {
            get { return _xposStart; }
            set { _xposStart = value; }
        }

        public int YEnd
        {
            get { return _yposEnd; }
            set { _yposEnd = value; }
        }

        public int XEnd
        {
            get { return _xposEnd; }
            set { _xposEnd = value; }
        }

    }
}
