using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoomsTask
{
    public partial class LogWindow : Window
    {

        public LogWindow()
        {
            InitializeComponent();
            
            dataGridView1.ItemsSource = Logs.GetLogs();
          

        }
       

    }

   
    
}
