using dotNet5781_02_3652_2455;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03A_3652_2455
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CollectionOfBuses myLines = new CollectionOfBuses();
        private List<BusStop> myBusStops = new List<BusStop>();
        private LineBus currentDisplayBusLine;

        /// <summary>
        /// the method add 40 bus stops to the list of the bus stops
        /// </summary>
        public void AddBusStops()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int num;
            bool flag;
            for (int i = 0; i < 40; i++)
            {
                num = rand.Next(1, 999999); //Random number for bus stop's code
                flag = true;
                foreach (BusStop bs in myBusStops) //Go through all the bus stops on the list and check if the code appears in the list
                {
                    if (bs.Code == num) //When the code appears in the list
                        flag = false;
                }
                if (flag)
                {
                    myBusStops.Add(new BusStop(num)); //When the code does not appear in the list
                }
                else
                {
                    i--;
                }
            }
        }
        /// <summary>
        /// the method add 10 buses to the collection of buses
        /// </summary>
        public void AddLines()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int num;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    num = rand.Next(1, 999); //Random number for bus line number
                    List<LineBusStop> route = new List<LineBusStop>();
                    for (int j = 0; j < 10; j++)
                    {
                        route.Add(new LineBusStop(myBusStops[rand.Next(40)])); //10 random stops for the bus route
                    }
                    myLines.AddLine(new LineBus(num, route, (Area)rand.Next(5))); //Random area for bus
                }
                catch (Exception) //error
                {
                    i--;
                }

            }
        }
        /// <summary>
        /// c-tor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Random rand = new Random(DateTime.Now.Millisecond);
            AddBusStops(); //A call for a method that will add 40 bus stops to the list of bus stops
            AddLines(); //A call for a method that will put in 10 buses

            //Link the combobox to the data collection
            cbBusLines.ItemsSource = myLines;
            cbBusLines.DisplayMemberPath = "LineNum";
            cbBusLines.SelectedIndex = 0;
        }
        /// <summary>
        /// Event for choosing a bus line from the collection of buses
        /// </summary>
        /// <param name="sender">line of bus</param>
        /// <param name="e">Details</param>
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowLineBus((cbBusLines.SelectedValue as LineBus).LineNum); //
        }
        /// <summary>
        /// method that show the bus
        /// </summary>
        /// <param name="index">line of bus</param>
        private void ShowLineBus(int index)
        {
            //View the selected bus route
            currentDisplayBusLine = myLines[index]; 
            UpGrid.DataContext = currentDisplayBusLine; 
            lbBusLineStations.DataContext = currentDisplayBusLine.Route; 
        }
    }
}
