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
    /// Interaction logic for UpDateStationWindow.xaml
    /// </summary>
    public partial class UpDateStationWindow : Window
    {
        IBL bl;
        BO.Station st;
        public UpDateStationWindow(IBL _bl,BO.Station _st)
        {
            InitializeComponent();
            bl = _bl;
            st = _st;
        }

        //private void UpDateButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        st = gridStation.DataContext as BO.Station;
        //        if (st.Code > 0)
        //        {
        //            bl.UpdateStation(st);
        //            MessageBox.Show("succeeded", "UpDateStation", MessageBoxButton.OK);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("dont succeeded, no station found", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    gridStation.DataContext = new BO.Station();
        //    stationDataGrid.DataContext = bl.GetAllStations();
        //}
    }
}
