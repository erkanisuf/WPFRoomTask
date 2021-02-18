using System;
using System.Collections.Generic;
using System.Text;

namespace RoomsTask
{
    class Thermos
    {
        private int _currentTemperature { get; set; }



        public void setTemperature(int value) {

            _currentTemperature = value;
        }

        public int getTemperature()
        {

            return _currentTemperature;
        }

    }
}
