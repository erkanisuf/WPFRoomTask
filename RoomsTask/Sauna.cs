using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace RoomsTask
{
    class Sauna
    {

        public bool saunaStatus { get; set; }
        private double saunaTemp { get; set; }

        public void saunaOn()
        {
            saunaStatus = true;
        }
        public void saunaOff()
        {
            saunaStatus = false;
        }

        public double  getSaunaTemp()
        {
            return saunaTemp;
        }

        public void setSaunaTemp(int props)
        {
            saunaTemp = props;

        }

        public void incrementSaunaTemp()
        {
            saunaTemp += 0.5;
        }

        public void decreaseSaunaTemp() {
            saunaTemp -= 1;
        }
    }
}
