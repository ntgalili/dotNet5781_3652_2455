using BLAPI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for ElectronicBoardWindow.xaml
    /// </summary>
    public partial class ElectronicBoardWindow : Window
    {
        Stopwatch stopwatch;
        bool isTimerRun = false;
        Thread timerThread;
        IBL bl;
        BO.Station curStation;
        BackgroundWorker timerworker;
        TimeSpan startTime;
        public ElectronicBoardWindow(IBL _bl,BO.Station _s)
        {
            InitializeComponent();
            bl = _bl;
            curStation = _s;
            nameTextBox.IsEnabled = false;
            codeTextBox.IsEnabled = false;
            includeTextBox.IsEnabled = false;
            stopwatch = new Stopwatch();
            gridStation.DataContext = curStation;
            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            startTime =DateTime.Now.TimeOfDay;

            stopwatch.Restart();
            isTimerRun = true;
            timerworker.RunWorkerAsync();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            stopwatch.Stop();
            isTimerRun = false;
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TimeSpan curTime = startTime + stopwatch.Elapsed;
            string textTimer = curTime.ToString().Substring(0, 8);
            this.timerTextBlock.Text = textTimer;
            lineTimingDataGrid.DataContext = bl.GetAllTime(curTime, curStation);
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(1000);
            }
        }
    }
}
