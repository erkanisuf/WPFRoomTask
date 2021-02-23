using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomsTask
{
    class Weather
    {
        public string name{ get; set; }
        [JsonProperty("main")]
        public Main main{ get; set; }

        

    }
    class Main
    {
        public double temp { get; set; }
        
        public double toCelsius()
        {
            double numis = temp - 273.15;
            return numis;
           
        }

    }
}
