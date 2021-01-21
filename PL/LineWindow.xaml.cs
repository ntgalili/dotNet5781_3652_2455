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
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
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
                if (res == MessageBoxResult.Yes)
                {
                    curLine.MyStations.ToList().Remove(ls);
                    bl.UpdateLine(curLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Seccssed", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RefreshAllLineStationsGrid();
        }
        void RefreshAllLineStationsGrid()
        {
            lineStationDataGrid.DataContext = bl.GetAllLinesStationByLine(curLine.Code);
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
    }
}
