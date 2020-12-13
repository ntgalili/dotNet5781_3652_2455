using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Bus myBus;
        BackgroundWorker TestWorker;
        BackgroundWorker RefuelingWorker;
        //MessageBox message=new MessageBox(");
        public viewBusDetails(Bus B)
        {
            InitializeComponent();
            grid1.DataContext = B;
            myBus = B;
            grid1.IsEnabled = false;
            TestWorker = new BackgroundWorker();
            TestWorker.DoWork += myBus.BusTest;
            TestWorker.ProgressChanged += TestWorker_ProgressChanged; ;
            TestWorker.RunWorkerCompleted += TestWorker_RunWorkerCompleted; ;
            TestWorker.WorkerReportsProgress = true;
            TestWorker.WorkerSupportsCancellation = true;



            //RefuelingWorker.DoWork += myBus.BusRefueling;

        }

        private void TestWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        private void TestWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //int progress = e.ProgressPercentage;
            // .Show(progress + "% completed");
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TestWorker.RunWorkerAsync();
        }
    }
}
