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

namespace dotNet5781_03B_3652_2455
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Bus> myBuses = new List<Bus>();
        static Random r = new Random();

        /// <summary>
        /// the method create a new random bus
        /// </summary>
        /// <returns>the new bus</returns>
        Bus newBus()
        {
            DateTime date = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 28));//random date for when the bus ascended to the road
            long num;
            if(date.Year<2018)//the Bus number must match the year of the bus ascended to the road
            {
                num=r.Next(1000000, 9999999);
            }
            else
            {
               num= r.Next(10000000, 99999999);
            }
            return new Bus(num, date);
        }


        void addBus(Bus myBus)
        {
            
            foreach(Bus b in myBuses)
            {
                if (b.LicensePlate == myBus.LicensePlate)
                    throw new AddErrorException("There is a Bus With same License Plate");
            }
            myBuses.Add(myBus);
        }

        void creatMyBuses()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    addBus(newBus());

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
      



        }
    }
}
