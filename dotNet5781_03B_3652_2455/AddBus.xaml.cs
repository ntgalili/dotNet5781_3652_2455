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
        Bus newBus;
        /// <summary>
        /// c-tor AddBus
        /// </summary>
        public AddBus()
        {
            InitializeComponent();
            newBus = new Bus();
            grid1.DataContext = newBus;
        }
        /// <summary>
        /// A push button that adds a bus to the list of buses
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try //If the bus can be added to the list
            {
                BusesCollection.addBus(newBus); //adds a bus to the list of buses
                MessageBox.Show("succeeded", "perfect", MessageBoxButton.OK); //Print a message about the success of the income
            }
            catch (Exception) //If an exception is thrown following the addition of a bus to the list with a license plate that already exists for one of the buses
            { 
                MessageBox.Show("dont succeeded, there is a bus with the same license plate", "please try again", MessageBoxButton.OK, MessageBoxImage.Error); //Print a message about the failure of the income
            }
            this.Close(); //Close the add window
        }

 
    }
}
