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

namespace dotNet5781_03B_3652_2455
{
    /// <summary>
    /// Interaction logic for MakeingTravel.xaml
    /// </summary>

    public partial class MakeingTravel : Window
    {
        Bus myBus;
        BackgroundWorker travelWorker;
        public MakeingTravel(Bus B)
        {
            InitializeComponent();
            myBus = B;
            grid1.DataContext = B;
            travelWorker = new BackgroundWorker();
            travelWorker.DoWork += travelWorker_DoWork;
            travelWorker.ProgressChanged += travelWorker_ProgressChanged;
            travelWorker.RunWorkerCompleted += travelWorker_RunWorkerCompleted;
        }
        private void travelWorker_DoWork (object sender,DoWorkEventArgs e)
        {
            //object obj = e.Argument;
            //travelWorker.ReportProgress
            e.Result = "finished ok";
        }
        private void travelWorker_ProgressChanged (object sender, ProgressChangedEventArgs e)
        {

        }
        private void travelWorker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
        {
            object result = e.Result;
        }
        private void ButtonDrive_Click(object sender, RoutedEventArgs e)
        {
            string str = (km.Text);
            float temp;
            bool flag = float.TryParse(str, out temp);
            if (flag == true)
            {
                if (myBus.AddKM(temp))
                { 
                    travelWorker.WorkerReportsProgress = true;
                    travelWorker.RunWorkerAsync();
                    this.Close();
                }
                else
                    MessageBox.Show("the bus can not make this travel");
            }

            else
                MessageBox.Show("wrong value");
        }
    }
}
