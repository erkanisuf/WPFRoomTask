using FluentValidation;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace RoomsTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room kitchen = new Room();
        Room livingroom = new Room();
        Room saunaroom = new Room();
        Thermos house = new Thermos();
        Sauna sauna = new Sauna();
        DispatcherTimer timerTempUp = new DispatcherTimer();
        DispatcherTimer timerTempDown = new DispatcherTimer();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        DispatcherTimer clock = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            /* var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
             putka.Kind = PackIconKind.SmileyHappy;*/
            house.setTemperature(25);
            tempBar.Text = house.getTemperature().ToString() + "°C";
            sauna.setSaunaTemp(Convert.ToDouble(house.getTemperature()));
            saunaPowerTemp.Text = sauna.getSaunaTemp().ToString() + "°C";
            clock.Tick += new EventHandler(Timer_Click);

            clock.Interval = new TimeSpan(0, 0, 1);

            clock.Start();
            WeatherApp();






        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;

            myClock.Text = d.Hour + " : " + d.Minute ;
            myClockSeconds.Text = " : " + d.Second;
            DateTime localDate = DateTime.Now;
            
            myDate.Text = localDate.ToString("dd/MM/yyyy");
            myDateName.Text = localDate.ToString("dddd");
        }

        //Kitchenlights
        private void lightOnKitchen(object sender, RoutedEventArgs e)
        {
            kitchen.lightOn();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (kitchen.light == true)
            {
                powerKitchen.Opacity = 100 / 100;
                kitchenSlider.Value = 100;
                lightKitchen.Kind = PackIconKind.Lightbulbs;
                lightKitchen.Foreground = System.Windows.Media.Brushes.Green;
                

            }
            else
            {
                powerKitchen.Opacity = 0 / 100;
                kitchenSlider.Value = 0;
                lightKitchen.Kind = PackIconKind.LightbulbsOff;
                lightKitchen.Foreground = System.Windows.Media.Brushes.Red;
                
            }

            saveToLogs();

        }

        private void kitchenLightOff(object sender, RoutedEventArgs e)
        {
            kitchen.lightOff();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (kitchen.light == true)
            {
                powerKitchen.Opacity = 100 / 100;
                kitchenSlider.Value = 100;
                lightKitchen.Kind = PackIconKind.Lightbulbs;
                lightKitchen.Foreground = System.Windows.Media.Brushes.Green;


            }
            else
            {
                powerKitchen.Opacity = 0/ 100;
                kitchenSlider.Value = 0;
                lightKitchen.Kind = PackIconKind.LightbulbsOff;
                lightKitchen.Foreground = System.Windows.Media.Brushes.Red;

            }

            saveToLogs();
        }


        private void Kitchen_Light_Value(object sender,
              RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;

            double value = slider.Value;
            kitchen.lightPower = value;
            if (value > 1)
            {
                kitchen.lightOn();
                toggleKitchen.IsChecked = true;
            }
            else if (value < 1)
            {
                kitchen.lightOff();
                toggleKitchen.IsChecked = false;
            }
            powerKitchen.Opacity = value / 100;
            KitchenTextLight.Text = $"Light power: {kitchen.lightPower.ToString()}/ {slider.Maximum} %";
            saveToLogs();
        }



        //Living room lights
        private void livingRoom(object sender, RoutedEventArgs e)
        {
            livingroom.lightOn();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (livingroom.light == true)
            {
                powerlivingRoom.Opacity = 100 / 100;
                livingRoomSlider.Value = 100;
                livingRoomStatus.Kind = PackIconKind.Lightbulbs;
                livingRoomStatus.Foreground = System.Windows.Media.Brushes.Green;

            }
            else
            {
                powerlivingRoom.Opacity = 0/ 100;
                livingRoomSlider.Value = 0;
                livingRoomStatus.Kind = PackIconKind.LightbulbsOff;
                livingRoomStatus.Foreground = System.Windows.Media.Brushes.Red;

            }

            saveToLogs();

        }

        private void livingRoomOff(object sender, RoutedEventArgs e)
        {
            livingroom.lightOff();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (livingroom.light == true)
            {
                powerlivingRoom.Opacity = 100 / 100;
                livingRoomSlider.Value = 100;
                livingRoomStatus.Kind = PackIconKind.Lightbulbs;
                livingRoomStatus.Foreground = System.Windows.Media.Brushes.Green;


            }
            else
            {
                powerlivingRoom.Opacity = 0 / 100;
                livingRoomSlider.Value = 0;
                livingRoomStatus.Kind = PackIconKind.LightbulbsOff;
                livingRoomStatus.Foreground = System.Windows.Media.Brushes.Red;

            }
            saveToLogs();

        }

        private void LivingRoom_Light_Value(object sender,
              RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;

            double value = slider.Value;
            livingroom.lightPower = value;
            if (value > 1)
            {
                livingroom.lightOn();
                toggleLivingRoom.IsChecked = true;
            }
            else if (value < 1)
            {
                livingroom.lightOff();
                toggleLivingRoom.IsChecked = false;
            }
            powerlivingRoom.Opacity = value / 100;

            livingRoomTextLight.Text = $"Light power: { livingroom.lightPower.ToString()}/ {slider.Maximum} %";
            saveToLogs();
        }






        //Sauna lights

        private void saunaRoomOn(object sender, RoutedEventArgs e)
        {
            saunaroom.lightOn();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (saunaroom.light == true)
            {
                powerLightSauna.Opacity = 100 / 100;
                saunaSlider.Value = 100;
                saunaRoomStatus.Kind = PackIconKind.Lightbulbs;
                saunaRoomStatus.Foreground = System.Windows.Media.Brushes.Green;

            }
            else
            {
                powerLightSauna.Opacity = 0 / 100;
                saunaSlider.Value = 0;
                saunaRoomStatus.Kind = PackIconKind.LightbulbsOff;
                saunaRoomStatus.Foreground = System.Windows.Media.Brushes.Red;

            }

            saveToLogs();

        }

        public void saunaRoomOff(object sender, RoutedEventArgs e)
        {
            saunaroom .lightOff();
            var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            if (saunaroom.light == true)
            {
                powerLightSauna.Opacity = 100 / 100;
                saunaSlider.Value = 100;
                saunaRoomStatus.Kind = PackIconKind.Lightbulbs;
                saunaRoomStatus.Foreground = System.Windows.Media.Brushes.Green;


            }
            else
            {
                powerLightSauna.Opacity = 0 / 100;
                saunaSlider.Value = 0;
                saunaRoomStatus.Kind = PackIconKind.LightbulbsOff;
                saunaRoomStatus.Foreground = System.Windows.Media.Brushes.Red;

            }
            saveToLogs();

        }

        private void Sauna_Light_Value(object sender,
           RoutedPropertyChangedEventArgs<double> e)
        {
           
            var slider = sender as Slider;
  
            double value = slider.Value;

            saunaroom.lightPower = value;
            if (value > 1)
            {
                saunaroom.lightOn();
                saunaRoom.IsChecked = true;
            }
            else if (value < 1) {
                saunaroom.lightOff();
                saunaRoom.IsChecked = false;
            }
            powerLightSauna.Opacity = value / 100;
            // ... Set Window Title.
            saunaTextLight.Text =$"Light power: {saunaroom.lightPower.ToString()}/ {slider.Maximum} %";
            saveToLogs();
        }




        // Left Interface
        private void inputClear(object sender, RoutedEventArgs e) {
            inputTemp.Text = string.Empty;
        }

        private void House_temperature(object sender,
             RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;

            house.setTemperature((int)Math.Round(slider.Value)); // double to int
            tempBar.Text = house.getTemperature().ToString() + "°C";
            if (sauna.getSaunaTemp() < house.getTemperature() && sauna.saunaStatus == false) {
                sauna.setSaunaTemp(house.getTemperature());
                saunaPowerTemp.Text = sauna.getSaunaTemp().ToString() + "°C";
                timerTempDown.Interval = TimeSpan.FromSeconds(1);
                timerTempDown.Tick += new System.EventHandler(decreaseTemperature);
                timerTempUp.Stop();
                timerTempDown.Start();
                
            }
            saveToLogs();

        }
        // Temp input validator
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //STYLE THIS SECTION
        private void updateHouseTemperature(object sender, RoutedEventArgs e) {




            if (Int32.Parse(inputTemp.Text) >= 35  ) {
                ErrorMsg.Text = "Max temperature is 35 °C";
               
                ErrorMsg.Foreground = System.Windows.Media.Brushes.White;
                ErrorMsg.Background = System.Windows.Media.Brushes.Red;
            } else {
                house.setTemperature(Int32.Parse(inputTemp.Text));
                sliderTemperatureHouse.Value = house.getTemperature();
                ErrorMsg.Text = "Temperature Changed!";
                ErrorMsg.Foreground = System.Windows.Media.Brushes.White;
                ErrorMsg.Background = System.Windows.Media.Brushes.Green;
            }
             
            
                

           
           
           
            
            tempBar.Text = house.getTemperature().ToString() + "°C";
            inputTemp.Text = "";
            saveToLogs();

        }

        //turn on sauna temp
        private void turnOnSauna(object sender, RoutedEventArgs e)
        {

            timerTempUp.Interval = TimeSpan.FromSeconds(1);
            timerTempUp.Tick -= new System.EventHandler(increaseTemperature);
           
            timerTempUp.Start();
            timerTempUp.Stop();


            saunaPowerIcon.Kind = PackIconKind.PowerPlugOutline;
            saunaPowerIcon.Foreground = System.Windows.Media.Brushes.Green;
            saunaPowerTemp.Foreground = System.Windows.Media.Brushes.Green;
            saunaOnOff.Text = "ON";
           

            


            timerTempUp.Interval = TimeSpan.FromSeconds(1);
            timerTempUp.Tick += new System.EventHandler(increaseTemperature);
            timerTempDown.Stop();
            timerTempUp.Start();
            saveToLogs();

        }

        private void turnOffSauna(object sender, RoutedEventArgs e)
        {
            timerTempDown.Interval = TimeSpan.FromSeconds(1);
            timerTempDown.Tick -= new System.EventHandler(decreaseTemperature);
            timerTempDown.Stop();
            timerTempDown.Start();

            saunaPowerIcon.Kind = PackIconKind.PowerPlugOffOutline;
            saunaPowerIcon.Foreground = System.Windows.Media.Brushes.Red;
            saunaPowerTemp.Foreground = new BrushConverter().ConvertFromString("#FFA7ACA6") as SolidColorBrush;
            saunaOnOff.Text = "OFF";
            
           
            

            
                timerTempDown.Interval = TimeSpan.FromSeconds(1);
                timerTempDown.Tick += new System.EventHandler(decreaseTemperature);
            timerTempUp.Stop();
            timerTempDown.Start();

            saveToLogs();


        }

        public void increaseTemperature(object sender, EventArgs e)
        {

            sauna.saunaOn();
            saunaPowerTemp.Text = sauna.getSaunaTemp().ToString() + "°C";
            saveToLogs();
        }
        public void decreaseTemperature(object sender, EventArgs e)
        {
            
                sauna.saunaOff(house.getTemperature());
            
            
            saunaPowerTemp.Text = sauna.getSaunaTemp().ToString() + "°C";
            saveToLogs();

        }
        private void speakerStatus(object sender, RoutedEventArgs e)
        {
            //Lights status
            string kitchenStatus = kitchen.light == true ?  "ON" :  "OFF";
            speech.Speak($"Kitchen Lights are {kitchenStatus}");
            string livingroomStatus = livingroom.light == true ? "ON" : "OFF";
            speech.Speak($"Livingroom Lights are {livingroomStatus}");
            string saunaroomStatus = saunaroom.light == true ? "ON" : "OFF";
            speech.Speak($"Sauna room Lights are {saunaroomStatus}");
            //
            //Current house temperature
            string currenthouseTemp = house.getTemperature().ToString() ;
            speech.Speak($"Current house temperature is {currenthouseTemp } °C");
            //Sauna condition
            string saunaOnOrOff = sauna.saunaStatus == true ? "Turned ON" : "Turned OFF";
            string saunaCurrentTemp = sauna.getSaunaTemp().ToString();
            speech.Speak($"Sauna  is  {saunaOnOrOff  } with current temperature {saunaCurrentTemp} °C");


        }

        // Log saving 
        public void  saveToLogs()
        {
            string filePath = @"C:\Users\Erko\source\repos\RoomProject\RoomProject\logs.txt";
            List<string> loglist = new List<string>();
            loglist = File.ReadAllLines(filePath).ToList();
            DateTime localDate = DateTime.Now;

            string kitchenStatus = kitchen.light == true ? "ON" : "OFF";
            string livingroomStatus = livingroom.light == true ? "ON" : "OFF";
            string saunaroomStatus = saunaroom.light == true ? "ON" : "OFF";
            string saunaStatus = sauna.saunaStatus == true ? "ON" : "OFF";
            string newlog =$"{localDate.ToString()},{house.getTemperature().ToString()},{kitchenStatus},{livingroomStatus},{saunaroomStatus},{saunaStatus},{sauna.getSaunaTemp().ToString()}";
            loglist.Add(newlog);
            File.WriteAllLines(filePath, loglist);
        }
        //Open new Window
        private void openLogWindow(object sender, RoutedEventArgs e)
        {
            
            LogWindow logwindow = new LogWindow();
            logwindow.Show();
            
        }
        //Weather API CALL - finnish soon


        public void WeatherApp()
        {
            HttpClient client = new HttpClient();

            string URL = "http://api.openweathermap.org/data/2.5/weather?q=helsinki&appid=ae300bd9a386bccd8a3ac26676af1ec2";
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<Weather>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                cityTemp.Text = dataObjects.main.toCelsius().ToString("N2") + "°C";
                cityTempName.Text = dataObjects.name;
                cityTempClouds.Text = dataObjects.weather[0].description.ToString().ToUpper();

                //Image source
                string packUri = $"http://openweathermap.org/img/wn/{ dataObjects.weather[0].icon}.png";
                weatherIMG.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
               
            }
            else
            {
                MessageBox.Show("error");
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

        }
        
    }




}
