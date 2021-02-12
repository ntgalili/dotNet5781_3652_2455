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
        Action action;
        IBL bl;
        BO.Line lineToAdd;
        int  startStation;
        int endStation;
        public AddLineWindow(IBL _bl,Action _action)
        {
            InitializeComponent();
            bl = _bl;
            action = _action;
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
                startStation =(comboBoxStarting.SelectedItem as BO.Station).Code;
                endStation = (comboBoxDestination.SelectedItem as BO.Station).Code;
                
                lineToAdd = AddLineGrid.DataContext as BO.Line;
                if (lineToAdd == null || lineToAdd.LineNum <= 0|| startStation== endStation)
                {
                    MessageBox.Show("Missing information,please try again!", "AddLine", MessageBoxButton.OK);
                }
                else
                {
                    lineToAdd.Active = true;
                    bl.AddLine(lineToAdd, startStation, endStation);
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

        private void Window_Closed(object sender, EventArgs e)
        {
            action.Invoke();
        }
    }
}
