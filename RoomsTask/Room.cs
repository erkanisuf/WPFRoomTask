using System;
using System.Collections.Generic;
using System.Text;

namespace RoomsTask
{
    class Room
    {
        public bool light { get;set; }
        public double lightPower { get; set; }

        public void lightOn() {
            light = true;
        }
        public void lightOff()
        {
            light = false;
        }
    }
}
