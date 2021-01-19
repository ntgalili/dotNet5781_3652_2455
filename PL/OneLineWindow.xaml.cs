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
    /// Interaction logic for OneLineWindow.xaml
    /// </summary>
    public partial class OneLineWindow : Window
    {
        IBL bl;
        BO.Line line;
        public OneLineWindow(IBL _bl,BO.Line _line)
        {
            InitializeComponent();
            bl = _bl;
            line = _line;
            OneLineGrid.DataContext = line;
            myStationsListBox.DataContext = line.MyStations;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation ls = (sender as Button).DataContext as BO.LineStation;
            try 
            {
                line.MyStations.ToList().Remove(ls);
                bl.UpdateLine(line);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Not Seccssed", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
