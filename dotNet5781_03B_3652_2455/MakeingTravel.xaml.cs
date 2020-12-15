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
        BackgroundWorker travelWorker; //Process
        /// <summary>
        /// c-tor MakeingTravel
        /// </summary>
        /// <param name="B">bus</param>
        public MakeingTravel(Bus B)
        {
            InitializeComponent();
            myBus = B;
            grid1.DataContext = B;
            grid1.IsEnabled = false;
            travelWorker = new BackgroundWorker();
            //events of BackGroundWorker travelWorker
            travelWorker.DoWork += travelWorker_DoWork;
            travelWorker.ProgressChanged += travelWorker_ProgressChanged;
            travelWorker.RunWorkerCompleted += travelWorker_RunWorkerCompleted;
        }
        /// <summary>
        /// A travelWorker_DoWork method that performs the operations of the travel process
        /// </summary>
        private void travelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random r = new Random();
            int fast = r.Next(20, 51); //Lottery random number between 20 and 50 for travel speed
            for (int i = 1; i < 7; i++) //Dividing travel time into 6 parts Each part takes 1000 milliseconds so that each trip takes an hour of time in real time
            {
                Thread.Sleep((kilometer / fast) * 1000); //Sleep during the trip itself by speed and road
                travelWorker.ReportProgress(i); //Calling the travelWorker_ProgressChanged method
            }
            e.Result = "the traveling passed successfully!"; //A string sent to the travelWorker_RunWorkerCompleted method and executed at the end of the process
        }
        /// <summary>
        /// A method that is responsible for changes that occur during the process
        /// </summary>
        /// <param name="e">A parameter to represent the percentage of travel out of total travel</param>
        private void travelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage; //A parameter to represent the percentage of travel out of total travel
            resultLabel.Content = (((kilometer / 6.0) * progress) + " km /" + kilometer + "km"); //Displays the percentage of travel from total travel
        }
        /// <summary>
        /// The travelWorker_DoWork method that runs the travel process
        /// </summary>
        private void travelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myBus.BusStatus = (status)0; //Bus status update
            MessageBox.Show(e.Result.ToString()); //A text message stating that the trip was successful
            this.Close(); //Closing the procession window
        }
        /// <summary>
        /// The responsible method that allows the user to just press numbers and enter on the keyboard
        /// </summary>
        /// <param name="sender">Press a number key on the keyboard</param>
        /// <param name="e">Press the enter key on the keyboard</param>
        private void km_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox tx = sender as TextBox;
            if (tx == null) return; //If not, tap any character on the keyboard
            if (e == null) return; //If not, tap any character on the keyboard

            if (e.Key == Key.Enter || e.Key == Key.Return) //Each key press enters separately and checks if it is indeed good
            {
                if (tx.Text.Length > 0) //If you press the keys on the keyboard
                {
                    kilometer = int.Parse(tx.Text); //One keystroke
                    tx.Text = "";
                    bool flag = myBus.AddKM(kilometer); //Send to a method that returns true if it was able to make the trip and false if not
                    if (flag == true) //If the trip was made successfully
                    {
                        km.IsEnabled = false; 
                        myBus.BusStatus = (status)1; //Bus status update
                        travelWorker.WorkerReportsProgress = true;
                        travelWorker.RunWorkerAsync(); //Running a process
                    }
                    else //If the trip was not made
                        MessageBox.Show("the bus can not make this travel"); //Issuing a notice that the trip cannot take place
                }
                e.Handled = true;
                return;
            }
            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (char.IsControl(c)) return;
            if (char.IsDigit(c)) return;
            e.Handled = true;
            MessageBox.Show("only numbers are allowed", "Account", MessageBoxButton.OK, MessageBoxImage.Error); //If you press any character on a keyboard other than a number or enter, you get an error message
        }
    }
}

