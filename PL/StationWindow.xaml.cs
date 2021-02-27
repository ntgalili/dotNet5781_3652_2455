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
        bool isAdmin;
        public StationWindow(IBL _bl,bool _isAdmin)
        {
            InitializeComponent();
            bl = _bl;
            isAdmin = _isAdmin;
            stationDataGrid.DataContext = bl.GetAllStations();
            gridStation.DataContext = new BO.Station();
            includeComboBox.ItemsSource = Enum.GetValues(typeof(BO.StationInclude));
            UpDateButton.IsEnabled = false;
            if(isAdmin==false)
            {
                AddButton.Visibility = Visibility.Collapsed;
                UpDateButton.Visibility = Visibility.Collapsed;
                gridStation.IsEnabled = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                st = gridStation.DataContext as BO.Station;
                if (st.Lattitude > 33.3 || st.Lattitude < 31 || st.Longitude > 35.5 || st.Longitude < 34.3)
                {
                    MessageBox.Show("Invalid latitude and longitude", "AddStation", MessageBoxButton.OK);
                    return;
                }

                if (st != null && st.Code > 0)
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            stationDataGrid.DataContext = bl.GetAllStations();
            gridStation.DataContext = new BO.Station();
            codeTextBox.IsEnabled = true;
            lattitudeTextBox.IsEnabled = true;
            longitudeTextBox.IsEnabled = true;
            AddButton.IsEnabled = true;
            UpDateButton.IsEnabled = false;
            if (isAdmin == false)
            {
                AddButton.IsEnabled = false;
                UpDateButton.IsEnabled = false;
            }
        }

        private void stationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            st = (sender as DataGrid).SelectedItem as BO.Station;
            gridStation.DataContext = st;
            codeTextBox.IsEnabled = false;
            lattitudeTextBox.IsEnabled = false;
            longitudeTextBox.IsEnabled = false;
            AddButton.IsEnabled = false;
            UpDateButton.IsEnabled = true;
            if (isAdmin == false)
            {
                AddButton.IsEnabled = false;
                UpDateButton.IsEnabled = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
             if((sender as CheckBox).IsChecked==true)
                stationDataGrid.DataContext = bl.GetAllActiveStations();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == false)
                stationDataGrid.DataContext = bl.GetAllStations();
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                st = gridStation.DataContext as BO.Station;
                bl.UpdateStation(st);
                MessageBox.Show("succeeded", "UpDateStation", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded, Not found", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            gridStation.DataContext = new BO.Station();
            stationDataGrid.DataContext = bl.GetAllStations();
        }


        private void ElectronicButton_Click(object sender, RoutedEventArgs e)
        {
            if (st != null)
            {
                ElectronicBoardWindow win = new ElectronicBoardWindow(bl, st);
                win.ShowDialog();
            }
        }
    }
}
