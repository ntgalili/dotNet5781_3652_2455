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
    /// Interaction logic for LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window
    {
        IBL bl;
        BO.Line curLine;
        bool isAdmin;
        public LineWindow(IBL _bl,bool _isAdmin)
        {
            InitializeComponent();
            bl = _bl;
            isAdmin = _isAdmin;
            cbLine.DataContext = bl.GetAllActiveLines();
            StationsCB.DataContext = bl.GetAllStations();
            AreaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            areaTextBox.IsEnabled = false;
            lineNumTextBox.IsEnabled = false;
            if (isAdmin == true)
            {
                labelOfStation.IsEnabled = true;
                StationsCB.IsEnabled = true;
                indexLable.IsEnabled = true;
                indexTextBox.IsEnabled = true;
                AddStationButton.IsEnabled = true;
                AddLineButton.IsEnabled = true;
                DeleteLineButton.IsEnabled = true;
            }
            else
            {
                labelOfStation.Visibility = Visibility.Collapsed;
                StationsCB.Visibility = Visibility.Collapsed;
                indexLable.Visibility = Visibility.Collapsed;
                indexTextBox.Visibility = Visibility.Collapsed;
                AddStationButton.Visibility = Visibility.Collapsed;
                AddLineButton.Visibility = Visibility.Collapsed;
                DeleteLineButton.Visibility = Visibility.Collapsed;
                lineStationDataGrid.Columns[3].Visibility = Visibility.Collapsed;
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curLine!=null&&curLine.Code != 0)
                {
                    MessageBoxResult res = MessageBox.Show(" Are you sure you want to delete this line?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        bl.DeleteLine(curLine.LineNum, curLine.Code);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Seccssed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshLine();
            curLine = new BO.Line();
        }

        private void DeleteStationButton_Click(object sender, RoutedEventArgs e)
        {
                BO.LineStation ls = (sender as Button).DataContext as BO.LineStation;
                try
                {
                    MessageBoxResult res = MessageBox.Show("Are you sure you want to delete this station?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (curLine.MyStations.Count() <= 2)
                    {
                        MessageBox.Show("Unable to delete this station - there are only 2 stations left for this line", " Delete station", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                        if (res == MessageBoxResult.Yes)
                        bl.deleteStationFromLine(ls.Code, curLine);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Not Seccssed", " Delete station", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            curLine = bl.GetLine(curLine.Code);
            RefreshAllLineStationsGrid();
        }
        void RefreshAllLineStationsGrid()
        {
            lineStationDataGrid.DataContext = curLine.MyStations.ToList();
        }
        private void cbLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLine = (cbLine.SelectedItem as BO.Line);
            gridLine.DataContext = curLine;

            if (curLine != null)
            {
                RefreshAllLineStationsGrid(); 
            }
        }
        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lineStationDataGrid.DataContext = null;
            cbLine.DataContext = bl.GetAllLineByArea((BO.Areas)AreaComboBox.SelectedItem);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineWindow win = new AddLineWindow(bl, RefreshLine);
            win.Show();
        }


        private void AddStationButton_Click(object sender, RoutedEventArgs e)
        {
            BO.Station station = (StationsCB.SelectedItem as BO.Station);
            if (station==null)
            {
                MessageBox.Show("you need to select a station", "add station", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int index;
            bool flag= int.TryParse(indexTextBox.Text, out index);
            if(!flag)
            {
                index = curLine.MyStations.Count();
            }
            try
            {
                bl.AddStationToLine(station.Code, curLine, index);
            }
            catch(Exception ex)
            {
                MessageBox.Show("This station already exists on the line", "add station", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            RefreshAllLineStationsGrid();

        }

        private void indexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx == null) return; //If not, tap any character on the keyboard
            if (e == null) return; //If not, tap any character on the keyboard

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (char.IsControl(c)) return;
            if (char.IsDigit(c)) return;
            e.Handled = true;
            MessageBox.Show("only numbers are allowed", "Account", MessageBoxButton.OK, MessageBoxImage.Error);
        
        }

        void RefreshLine()
        {
            cbLine.DataContext = bl.GetAllActiveLines();
            curLine = new BO.Line();
            lineStationDataGrid.DataContext = null;
        }
    }
}
