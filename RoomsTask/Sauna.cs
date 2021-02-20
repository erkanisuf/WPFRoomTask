using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace RoomsTask
{
    class Sauna
    {

        DispatcherTimer timerTempUp = new DispatcherTimer();
        DispatcherTimer timerTempDown = new DispatcherTimer();
        public bool saunaStatus { get; set; }
        private double saunaTemp { get; set; }


        public void saunaOn()
        {
            saunaStatus = true;
            if (saunaTemp < 80)
            {
                saunaTemp += 0.5;
            }
               
        }
        public void saunaOff(double props)
        {
            saunaStatus = false;

            if (saunaTemp > props)
            {
                saunaTemp--;
            }
            else
            {
                saunaTemp = props;
            }



        }

        public double  getSaunaTemp()
        {
            return saunaTemp;
        }

        public void setSaunaTemp(double props)
        {
            saunaTemp = props;

        }

        
    }
}
