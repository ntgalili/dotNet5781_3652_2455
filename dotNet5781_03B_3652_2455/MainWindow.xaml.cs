using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03B_3652_2455
{
    public static class BusesCollection
    {
        internal static ObservableCollection<Bus> myBuses = new ObservableCollection<Bus>();
        internal static void addBus(Bus myBus)
        {

            foreach (Bus b in BusesCollection.myBuses)
            {
                if (b.LicensePlate == myBus.LicensePlate)
                    throw new AddErrorException("There is a Bus With same License Plate");
            }
            BusesCollection.myBuses.Add(myBus);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();

        /// <summary>
        /// the method create a new random bus
        /// </summary>
        /// <returns>the new bus</returns>
        Bus newBus()
        {
            DateTime date = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 28));//random date for when the bus ascended to the road
            long num;
            if (date.Year < 2018)//the Bus number must match the year of the bus ascended to the road
            {
                num = r.Next(1000000, 9999999);
            }
            else
            {
                num = r.Next(10000000, 99999999);
            }
            return new Bus(num, date);
        }
        void creatMyBuses()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    BusesCollection.addBus(newBus());

                }
                catch (Exception)
                {
                    i--;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            creatMyBuses();
            for (int i = 0; i < 3; i++)
            {
                BusesCollection.myBuses[r.Next(0, 10)].DateOfTest = DateTime.Now;
                BusesCollection.myBuses[r.Next(0, 10)].Fuel = 1200;
                BusesCollection.myBuses[r.Next(0, 10)].TotalTravel += 20000;
            }
            ListOfBuses.DataContext = BusesCollection.myBuses;
            // ListOfBuses.IsReadOnly = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus AddBusWindow = new AddBus();
            AddBusWindow.ShowDialog();
        }

        private void Traveling_Click(object sender, RoutedEventArgs e)
        {
            Bus s = (sender as Button).DataContext as Bus;
            MakeingTravel making = new MakeingTravel(s);
            making.ShowDialog();
        }

        private void ListOfBuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewBusDetails myDetails = new viewBusDetails(((sender as ListBox).SelectedItem as Bus), false);
            myDetails.Show();
        }

        private void Refueling_Click(object sender, RoutedEventArgs e)
        {
            Bus s = (sender as Button).DataContext as Bus;
            viewBusDetails myDetails = new viewBusDetails(s, true);
            myDetails.Show();
        }
    }
}
