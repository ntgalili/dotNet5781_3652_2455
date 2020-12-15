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
        internal static ObservableCollection<Bus> myBuses = new ObservableCollection<Bus>(); //collection list of buses
        /// <summary>
        /// A method that adds a bus to the list of buses
        /// </summary>
        /// <param name="myBus">bus to add</param>
        internal static void addBus(Bus myBus)
        {

            foreach (Bus b in BusesCollection.myBuses) //Go over the list of buses
            {
                if (b.LicensePlate == myBus.LicensePlate) //Check if there is a bus on the list with the same license plate as the bus you want to add to the list
                    throw new AddErrorException("There is a Bus With same License Plate"); //If so an unusual shot and do not add the new bus to the list
            }
            BusesCollection.myBuses.Add(myBus); //If there is no bus on the list with the same license plate as the bus you want to add to the list, we will add the bus
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
            return new Bus(num, date); //Creating a new bus
        }
        /// <summary>
        /// Create 10 new buses and add them to the list
        /// </summary>
        void creatMyBuses()
        {
            for (int i = 0; i < 10; i++)
            {
                try //If the lottery bus can be added to the list
                {
                    BusesCollection.addBus(newBus()); //Call to the method of adding a bus

                }
                catch (Exception) //If an exception is thrown then do not add the bus and allow a raffle of the bus so that finally there will be 10 buses on the list
                {
                    i--;
                }
            }
        }
        /// <summary>
        /// main method
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            creatMyBuses(); //Creating a list of buses
            for (int i = 0; i < 3; i++) //Lottery of 9 buses from the list
            {
                BusesCollection.myBuses[r.Next(0, 10)].DateOfTest = DateTime.Now; //The lottery bus will have an up-to-date date
                BusesCollection.myBuses[r.Next(0, 10)].Fuel = 1200; //The Muggle bus will be full of fuel
                BusesCollection.myBuses[r.Next(0, 10)].TotalTravel += 20000; //The Muggle bus will be with full travel
            }
            ListOfBuses.DataContext = BusesCollection.myBuses;
        }
        /// <summary>
        /// Push-button to add a bus to the list
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBus AddBusWindow = new AddBus(); //Add a bus to the list
            AddBusWindow.ShowDialog(); 
        }
        /// <summary>
        /// Press button to make a trip to the bus on the list - the button is next to each bus on the list
        /// </summary>
        /// <param name="sender">Button</param>
        private void Traveling_Click(object sender, RoutedEventArgs e)
        {
            Bus s = (sender as Button).DataContext as Bus;
            MakeingTravel making = new MakeingTravel(s); //Call to the process of making a trip
            making.ShowDialog();
        }
        /// <summary>
        /// Double-clicking on a bus from the list opens a window for displaying the bus details
        /// </summary>
        /// <param name="sender">ListBox</param>
        private void ListOfBuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewBusDetails myDetails = new viewBusDetails(((sender as ListBox).SelectedItem as Bus), false);
            myDetails.Show();
        }
        /// <summary>
        /// Press button to refuel the bus on the list - the button is next to each bus on the list
        /// </summary>
        /// <param name="sender">Button</param>
        private void Refueling_Click(object sender, RoutedEventArgs e)
        {
            Bus s = (sender as Button).DataContext as Bus;
            viewBusDetails myDetails = new viewBusDetails(s, true); //Call to the process of refueling
            myDetails.Show();
        }
    }
}
