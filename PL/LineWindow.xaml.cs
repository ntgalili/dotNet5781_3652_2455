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
        public LineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            cbLine.DataContext = bl.GetAllActiveLines();
            StationsCB.DataContext = bl.GetAllStations();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curLine!=null&&curLine.Code != 0)
                {
                    MessageBoxResult res = MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק  קו זה?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
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
            //BO.LineStation ls = (sender as Button).DataContext as BO.LineStation;
            //try
            //{
            //    line.MyStations.ToList().Remove(ls);
            //    bl.UpdateLine(line);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Not Seccssed", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void DeleteStationButton_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation ls = (sender as Button).DataContext as BO.LineStation;
            try
            {
                MessageBoxResult res = MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק תחנה זו?", "Verification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (curLine.MyStations.Count() <= 2)
                {
                    MessageBox.Show("אין אפשרות למחוק - נשארו רק 2 תחנות", " Delete station", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (res == MessageBoxResult.Yes)
                    {
                        bl.deleteStationFromLine(ls.Code, curLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Seccssed"," Delete station", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            curLine = bl.GetLine(curLine.LineNum, curLine.Code);
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
                MessageBox.Show("התחנה כבר קיימת בקו", "add station", MessageBoxButton.OK, MessageBoxImage.Error);
                
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
