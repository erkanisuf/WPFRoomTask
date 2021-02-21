using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RoomsTask
{
    public class Logs
    {
        public static List<Log> GetLogs()
        {
            string filePath = @"C:\Users\Erko\source\repos\RoomProject\RoomProject\logs.txt";
            var lines = File.ReadAllLines(filePath);
            var newlist = new List<Log>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(',');
                var log = new Log()
                {
                    date = line[0],
                    houseTemperature = line[1],
                    kitchenLight = line[2],
                    livingroomLight = line[3],
                    saunaLight = line[4],
                    saunaStatus = line[5],
                    saunaTemperature = line[6]
                };
                newlist.Add(log);
            }
            return newlist;
        }
    }
}
