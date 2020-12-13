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
using System.ComponentModel;
using System.Threading;

namespace dotNet5781_03B_3652_2455
{
    /// <summary>
    /// Interaction logic for MakeingTravel.xaml
    /// </summary>

    public partial class MakeingTravel : Window
    {
        int kilometer;
        Bus myBus;
        BackgroundWorker travelWorker;
        public MakeingTravel(Bus B)
        {
            InitializeComponent();
            myBus = B;
            grid1.DataContext = B;
            grid1.IsEnabled = false;
            travelWorker = new BackgroundWorker();
            travelWorker.DoWork += travelWorker_DoWork;
            travelWorker.ProgressChanged += travelWorker_ProgressChanged;
            travelWorker.RunWorkerCompleted += travelWorker_RunWorkerCompleted;
        }
        private void travelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random r = new Random();
            int fast = r.Next(20, 51);
            for (int i = 1; i < 7; i++)
            {
                Thread.Sleep((kilometer / fast) * 1000);
                travelWorker.ReportProgress(i);
            }
            e.Result = "the traveling passed successfully!";
        }
        private void travelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            resultLabel.Content = (((kilometer / 6.0) * progress) + " km /" + kilometer + "km");
        }
        private void travelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus.BusStatus = (status)0;
            MessageBox.Show(e.Result.ToString());
            this.Close();
        }
        private void km_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx == null) return;
            if (e == null) return;

            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (tx.Text.Length > 0)
                {
                    kilometer = int.Parse(tx.Text);
                    tx.Text = "";
                    bool flag = myBus.AddKM(kilometer);
                    if (flag == true)
                    {
                        km.IsEnabled = false;
                        myBus.BusStatus = (status)1;
                        travelWorker.WorkerReportsProgress = true;
                        travelWorker.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("the bus can not make this travel");
                }
                e.Handled = true;
                return;
            }
            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (char.IsControl(c)) return;
            if (char.IsDigit(c)) return;
            e.Handled = true;
            MessageBox.Show("only numbers are allowed", "Account", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        {

        }

    private void Window_Loaded_1(object sender, RoutedEventArgs e)
    {

        System.Windows.Data.CollectionViewSource busViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("busViewSource")));
        // Load data by setting the CollectionViewSource.Source property:
        // busViewSource.Source = [generic data source]
    }
}
}
