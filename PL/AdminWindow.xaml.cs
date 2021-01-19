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
        public AdminWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            if (rbStations.IsChecked == true)
            {
                StationWindow win = new StationWindow(bl);
                win.Show();
            }
            else if (rbLines.IsChecked == true)
            {
               LineWindow win = new LineWindow(bl);
                win.Show();
                //MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            //else
            //{
            //    //CoursesWindow win = new CoursesWindow(bl);
            //    //win.Show();
            //    MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //}
        }
    }
}

