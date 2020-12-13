using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public viewBusDetails(Bus B,bool  flag)
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


            RefuelingWorker = new BackgroundWorker();
            RefuelingWorker.DoWork += myBus.BusRefueling;
            RefuelingWorker.ProgressChanged += RefuelingWorker_ProgressChanged;
            RefuelingWorker.RunWorkerCompleted += RefuelingWorker_RunWorkerCompleted;
            RefuelingWorker.WorkerReportsProgress = true;
            RefuelingWorker.WorkerSupportsCancellation = true;
            if(myBus.BusStatus!=status.ready)
            {
                TestButton.IsEnabled = false;
                RefuelingButton.IsEnabled = false;
            }
            if (flag)
            {
                RefuelingWorker.RunWorkerAsync();
                TestButton.IsEnabled = false;
                RefuelingButton.IsEnabled = false;
            }

        }

        private void RefuelingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelProgress.DataContext = "succseded";
            Thread.Sleep(2000);
            this.Close();
        }

        private void RefuelingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            LabelProgress.Content = (progress) + " Liters";
        }

        private void TestWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelProgress.DataContext = "succseded";
            Thread.Sleep(2000);
            this.Close();
        }
        private void TestWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            LabelProgress.Content = "Tere are " +( 24-progress) + " hours left";
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TestWorker.RunWorkerAsync();
            TestButton.IsEnabled = false;
            RefuelingButton.IsEnabled = false;
        }

        private void RefuelingButton_Click(object sender, RoutedEventArgs e)
        {
            RefuelingWorker.RunWorkerAsync();
            TestButton.IsEnabled = false;
            RefuelingButton.IsEnabled = false;
        }
    }
}
