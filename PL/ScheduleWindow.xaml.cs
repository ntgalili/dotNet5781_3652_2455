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
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        IBL bl;
        BO.Line curLine;
        public ScheduleWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            ComboBoxLine.DataContext = bl.GetAllActiveLines();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLine = ComboBoxLine.SelectedItem as BO.Line;
            AreaLable.Content = curLine.Area;
            FirstStationLable.Content = curLine.MyStations.ToList()[0].Name;
            int size = curLine.MyStations.ToList().Count;
            LastStationLable.Content = curLine.MyStations.ToList()[size - 1].Name;
            lineTripDataGrid.DataContext = bl.GetAllLineTripByCode(curLine.Code);
        }

        private void AddTimeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan startAtTime = TimeSpan.Parse(TimeTextBox.Text);
                BO.LineTrip lineTrip = new BO.LineTrip();
                lineTrip.StartAtTime = startAtTime;
                lineTrip.CodeLine = curLine.Code;
                lineTrip.Active = true;
                bl.AddLineTrip(lineTrip);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Seccssed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshAllLineTripGrid();
        }

        private void DeleteTimeButton_Click(object sender, RoutedEventArgs e)
        {
            BO.LineTrip lineTrip = (sender as Button).DataContext as BO.LineTrip;
            try
            {
                MessageBoxResult res = MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק תחנה זו?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    bl.DeleteLineTrip(lineTrip.CodeLineTrip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Seccssed", " Delete station", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshAllLineTripGrid();
        }
        void RefreshAllLineTripGrid()
        {
            try
            {
                lineTripDataGrid.DataContext = bl.GetAllLineTripByCode(curLine.Code);
            }
            catch(Exception ex)
            {
                lineTripDataGrid.DataContext = null;
            }
        }
    }
}
