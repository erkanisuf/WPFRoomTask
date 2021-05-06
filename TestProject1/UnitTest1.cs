using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomsTask;
using System;
using System.Windows.Threading;

namespace TestProject1
{
    [TestClass]
    public class RoomClassTests
    {
        [TestMethod]
        // Tests Lights on 
        public void TurnOn_Room_Lights()
        {
            // Arrange
            Room testroom = new Room();
            // Act
            testroom.lightOn();
            // Assert
            var result = testroom.light;
            Assert.IsTrue(result);
        }
        [TestMethod]
        // Tests Lights FF 
        public void TurnOff_Room_Lights()
        {
            // Arrange
            Room testroom = new Room();
            // Act
            testroom.lightOff();
            // Assert
            var result = testroom.light;
            Assert.IsTrue(!result);
        }
        [TestMethod]
        // Tests Power value of lights (e.g % visibility)
        public void Room_Light_Power()
        {
            // Arrange
            Room testroom = new Room();
            // Act
            testroom.lightPower = 100;
            // Assert
            var result = testroom.lightPower;
            Assert.AreEqual(100,result,"Error light power value");
        }
    }
    [TestClass]
    public class SaunaClassTest
    {
        [TestMethod]
        // Tests if Sauna is turned oN
        public void Sauna_On()
        {
            //Arange 
            Sauna testsauna = new Sauna();
            //Act
            testsauna.saunaOn();
            // Assert
            var result =testsauna.saunaStatus;
            Assert.IsTrue(result);
        }
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Sauna_Off()
        {
            //Arange 
            Sauna testsauna = new Sauna();
            //Act
            testsauna.saunaOff(1); // this one requires parameter (double)
            // Assert
            var result = testsauna.saunaStatus;
            Assert.IsTrue(!result);
        }
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Sauna_SetTemp()
        {
            //Arange 
            Sauna testsauna = new Sauna();
            //Act
            testsauna.setSaunaTemp(15);
            // Assert
            var result = testsauna.getSaunaTemp(); // method that returns temp of sauna
            Assert.AreEqual(15, result, "Sauna temperature error");
        }
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Sauna_TimerUP()
        {
            Sauna testsauna = new Sauna();
            testsauna.setSaunaTemp(15);
            for (int i = 0; i < 10; i++)
            {
                testsauna.saunaOn();
            }
              // Loop simulates Datetimer (f.ex in 10 seconds temp will increase with +5C , saunaOn method increases by 0.5)
            
            var result = testsauna.getSaunaTemp(); // method that returns temp of sauna
            Assert.AreEqual(20, result, "Sauna timer temp INCREMENT");
        }
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Sauna_TimerDOWN()
        {
            Sauna testsauna = new Sauna();
            testsauna.setSaunaTemp(30);
            int roomTemp = 25; // Simulates room`s temp;
            for (int i = 0; i < 10; i++)
            {
                testsauna.saunaOff(roomTemp);
            }
            // Loop simulates Datetimer , saunaOff decrements by -1 , if its equal to room temp it doesnt drecrement more )

            var result = testsauna.getSaunaTemp(); // method that returns temp of sauna
            Assert.AreEqual(25, result, "Sauna timer temp DECREMENT");
        }
    }
    [TestClass]
    public class ThermosClassTest {
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Thermos_SetTemp()
        {
            //Arange 
            Thermos testthermos = new Thermos();
            //Act
            testthermos.setTemperature(25);
            // Assert
            var result = testthermos.getTemperature(); // method that returns temp of Thermos
            Assert.AreEqual(25, result, "Thermostemperature error");
        }
    }
    [TestClass]
    public class CelsiusClass
    {
        [TestMethod]
        // Tests if Sauna is turned oFF
        public void Celsius_Converter()
        {
            Main temp = new Main();
            temp.temp = 293.15; // Kelvin temp
           var result =  temp.toCelsius();
            Assert.AreEqual(20, result, "Celsius converter");
        }
    }
}
