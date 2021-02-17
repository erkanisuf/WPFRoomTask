using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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


        public MainWindow()
        {
            InitializeComponent();
           /* var icon = new PackIcon { Kind = PackIconKind.SmileyHappy };
            putka.Kind = PackIconKind.SmileyHappy;*/

        }

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

        }




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

        }








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
        }





        private void inputClear(object sender, RoutedEventArgs e) {
            inputTemp.Text = string.Empty;
        }
    }


}
