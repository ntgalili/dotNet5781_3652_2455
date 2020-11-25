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
        public void AddBusStops()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int num;
            bool flag;
            for (int i = 0; i < 40; i++)
            {
                num = rand.Next(1, 999999);
                flag = true;
                foreach (BusStop bs in myBusStops)
                {
                    if (bs.Code == num)
                        flag = false;
                }
                if (flag)
                {
                    myBusStops.Add(new BusStop(num));
                }
                else
                {
                    i--;
                }
            }
        }

        public void AddLines()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int num;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    num = rand.Next(1, 999);
                    List<LineBusStop> route = new List<LineBusStop>();
                    for (int j = 0; j < 10; j++)
                    {
                        route.Add(new LineBusStop(myBusStops[rand.Next(40)]));
                    }
                    myLines.AddLine(new LineBus(num, route, (Area)rand.Next(5)));
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
            Random rand = new Random(DateTime.Now.Millisecond);
            AddBusStops();
            AddLines();
            cbBusLines.ItemsSource = myLines;
            cbBusLines.DisplayMemberPath = "LineNum";
            cbBusLines.SelectedIndex = 5;
        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowLineBus((cbBusLines.SelectedValue as LineBus).LineNum);
        }

        private void ShowLineBus(int index)
        {
            currentDisplayBusLine = myLines[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Route;
        }
    }
}
