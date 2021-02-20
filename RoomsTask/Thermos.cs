using System;
using System.Collections.Generic;
using System.Text;

namespace RoomsTask
{
    public class Thermos
    {
        private int _currentTemperature { get; set; }
        private int maxTemp = 50;


        public void setTemperature(int value) {

            _currentTemperature = value;
        }

        public int getTemperature()
        {

            return _currentTemperature;
        }

    }
}
