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
        public LineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            lineDataGrid.DataContext = bl.GetAllActiveLines();
        }
        private void lineDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Line line = (sender as DataGrid).SelectedItem as BO.Line;
            if (line.Active == true)
            {
                OneLineWindow win = new OneLineWindow(bl,bl.GetLine(line.LineNum,line.Code));
                win.Show();
            }
            else
                MessageBox.Show("Not Seccssed", "this line is not active", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
