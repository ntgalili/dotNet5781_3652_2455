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
using System.Windows.Shapes;

using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IBL bl;
        BO.Station st;
        bool isAdmin;
        public AdminWindow(IBL _bl,bool _isAdmin)
        {
            InitializeComponent();
            bl = _bl;
            isAdmin = _isAdmin;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            if (rbStations.IsChecked == true)
            {
                StationWindow win = new StationWindow(bl, isAdmin);
                win.Show();
            }
            else if (rbLines.IsChecked == true)
            {
               LineWindow win = new LineWindow(bl, isAdmin);
                win.Show();
            }
            else
            {
                ScheduleWindow win = new ScheduleWindow(bl, isAdmin);
                win.Show();
            }
        }
    }
}

