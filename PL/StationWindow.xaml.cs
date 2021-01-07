
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
    /// Interaction logic for StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        IBL bl;
        BO.Station st;
        public StationWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            stationDataGrid.DataContext = bl.GetAllStations();
            gridStation.DataContext = new BO.Station();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                st = gridStation.DataContext as BO.Station;
                if (st.Code > 0)
                {
                    bl.AddStation(st);
                    MessageBox.Show("succeeded", "AddStation", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded, there is a station with /the same code", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gridStation.DataContext = new BO.Station();
            stationDataGrid.DataContext = bl.GetAllStations();
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                st = gridStation.DataContext as BO.Station;
                if (st.Code > 0)
                {
                    bl.UpdateStation(st);
                    MessageBox.Show("succeeded", "UpDateStation", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded, no station found", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gridStation.DataContext = new BO.Station();
            stationDataGrid.DataContext = bl.GetAllStations();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            gridStation.DataContext = new BO.Station();
            stationDataGrid.DataContext = bl.GetAllStations();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                st = gridStation.DataContext as BO.Station;
                if (st.Code > 0)
                {
                    bl.DeleteStation(st.Code);
                    MessageBox.Show("succeeded", "DeleteStation", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded, no station found", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gridStation.DataContext = new BO.Station();
            stationDataGrid.DataContext = bl.GetAllStations();
        }
    }
}
