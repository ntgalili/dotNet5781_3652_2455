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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        Bus newBus = new Bus();
        public AddBus()
        {
            InitializeComponent();
            grid1.DataContext = newBus;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusesCollection.addBus(newBus);
                MessageBox.Show("succeeded", "perfect", MessageBoxButton.OK);
            }
            catch(Exception)
            {
                MessageBox.Show("dont succeeded, there is a bus with the same license plate", "please try again",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
