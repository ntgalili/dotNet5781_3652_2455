using BLAPI;

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

namespace PL
{
    /// <summary>
    /// Interaction logic for AddLineWindow.xaml
    /// </summary>
    public partial class AddLineWindow : Window
    {
        IBL bl;
        BO.Line lineToAdd;
        BO.LineStation startStation;
        BO.LineStation endStation;
        public AddLineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            AddLineGrid.DataContext = new BO.Line();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            comboBoxStarting.ItemsSource = bl.GetAllStations();
            comboBoxDestination.ItemsSource = bl.GetAllStations();
            RefreshButton.IsEnabled = false;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineGrid.DataContext = new BO.Line();
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            comboBoxStarting.ItemsSource = bl.GetAllStations();
            comboBoxDestination.ItemsSource = bl.GetAllStations();
            RefreshButton.IsEnabled = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                startStation = (BO.LineStation)(comboBoxStarting.DataContext as BO.Station);
                endStation = (BO.LineStation)(comboBoxDestination.DataContext as BO.Station);
                lineToAdd = AddLineGrid.DataContext as BO.Line;
                if (lineToAdd != null && lineToAdd.Code > 0)
                {
                    bl.AddLineStation(startStation);
                    bl.AddLineStation(endStation);
                    bl.AddLine(lineToAdd);
                    MessageBox.Show("succeeded", "AddLine", MessageBoxButton.OK);
                    AddLineGrid.DataContext = new BO.Line();
                    areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont succeeded", "please try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshButton.IsEnabled = true;
        }

    }
}
