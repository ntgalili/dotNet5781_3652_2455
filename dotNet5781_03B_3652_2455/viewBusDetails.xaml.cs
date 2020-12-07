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

namespace dotNet5781_03B_3652_2455
{
    /// <summary>
    /// Interaction logic for viewBusDetails.xaml
    /// </summary>
    public partial class viewBusDetails : Window
    {
        public viewBusDetails(Bus myBus)
        {
            InitializeComponent();
            grid1.DataContext = myBus;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
