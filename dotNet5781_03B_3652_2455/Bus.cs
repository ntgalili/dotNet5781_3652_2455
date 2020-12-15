using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace dotNet5781_03B_3652_2455
{
    public enum status { ready, traveling, refueling, serviced };//enum for the bus status
    /// <summary>
    /// Bus definition class.
    /// </summary>
    public class Bus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;//A property change event
        public event EventHandler StatusChanged;//Bus status change event
        private DateTime startTime;
        /// <summary>
        ///startTime  property
        /// </summary>
        public DateTime StartTime { get => startTime; set => startTime = value; }

        private long licensePlate;
        /// <summary>
        /// licensePlate property
        /// </summary>
        public long LicensePlate
        {
            get => licensePlate;
            set
            {
                if (StartTime.Year >= 2018)
                {
                    while (value < 10000000)// Adjusting the license plate
                    {
                        value = value * 10;
                    }
                    licensePlate = value % 100000000;

                }
                if (StartTime.Year < 2018)
                {
                    while (value < 1000000) //Adjusting the license plate
                    {
                        value = value * 10;
                    }
                    licensePlate = value % 10000000;
                }
            }
        }

        private DateTime dateOfTest;
        /// <summary>
        /// dateOfTest property
        /// </summary>
        public DateTime DateOfTest
        {
            get => dateOfTest;
            set
            {
                dateOfTest = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DateOfTest"));//report a change
                }
                if (StatusChanged != null)
                {
                    StatusChanged(this, new EventArgs());//report a change
                }
            }
        }
        private float travelOfTest;
        /// <summary>
        /// travelOfTest property
        /// </summary>
        public float TravelOfTest { get => travelOfTest; set => travelOfTest = value; }

        private float totalTravel;
        /// <summary>
        /// TotalTravel property
        /// </summary>
        public float TotalTravel
        {
            get => totalTravel;
            set
            {
                totalTravel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TotalTravel"));//report a change
                }
                if (StatusChanged != null)
                {
                    StatusChanged(this, new EventArgs());//report a change
                }
            }
        }
        private float fuel;
        /// <summary>
        /// fuel property
        /// </summary>
        public float Fuel
        {
            get => fuel;
            set
            {
                fuel = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Fuel"));//report a change
                }
                if (StatusChanged != null)
                {
                    StatusChanged(this, new EventArgs());//report a change
                }
            }
        }
        status busStatus;
        /// <summary>
        /// busStatus property
        /// </summary>
        public status BusStatus
        {
            get => busStatus;
            set
            {
                busStatus = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BusStatus"));//report a change
                }
                if(StatusChanged != null)
                {
                    StatusChanged(this, new EventArgs());//report a change
                }
            }
        }
        private string color;
        /// <summary>
        /// color property
        /// </summary>
        public string Color
        {
            get => color;
            set
            {
                color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Color"));//report a change
                }
            }
        }
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="Num">The bus's License Plate</param>
        /// <param name="Date">The bus's first day on the road</param>
        public Bus(long Num=1000000, DateTime Date=new DateTime())
        {
            StatusChanged += colors;  //Registration of the method for the event StatusChanged
            StartTime = Date;
            LicensePlate = Num;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 0;
            BusStatus = status.ready;
        }
        /// <summary>
        /// the method matches  the bus's color according to its status
        /// </summary>
        /// <param name="sender">the bus</param>
        /// <param name="e">more detials </param>
        private void colors(object sender, EventArgs e)
        {
            if (BusStatus == status.ready && Fuel > 0 && (TotalTravel - TravelOfTest) < 20000 && (DateOfTest.AddYears(1) >= DateTime.Now))//if the bus can travel
            {
                Color = "#FF90FF74";//GREEN
                return;
            }
            if (BusStatus == status.refueling)//if the bus is refueling
            {
                Color = "#FFF9FF64";//yellow
                return;
            }
            if (BusStatus == status.serviced)//when the bus is in a test
            {
                Color = "#FF70A0FF";//blue
                return;
            }
            if (BusStatus == status.traveling)//when the bus is in a traveling
            {
                Color = "#FFFFB870";//orange
                return;
            }
            Color = "#FFFF6464";//red
            return;
        }
        /// <summary>
        /// the method checks whether the bus can travel and update its details if so
        /// </summary>
        /// <param name="numKM">The Km of the new travel</param>
        /// <returns>true-if the travel can made and false if not</returns>
        public bool AddKM(int numKM)
        {
            if ((TotalTravel - TravelOfTest + numKM) > 20000 || (Fuel < numKM) || (DateOfTest.AddYears(1) < DateTime.Now) || BusStatus != status.ready)//if  the bus is dangerous or it does not have enough fuel
            {
                return false;
            }
            Fuel = Fuel - numKM;//update the details
            TotalTravel = TotalTravel + numKM;
            return true;
        }
        /// <summary>
        /// mothod for performing a test
        /// </summary>
        /// <param name="sender">the bus</param>
        /// <param name="e">more details</param>
        public void BusTest(object sender, DoWorkEventArgs e)
        {
            this.BusStatus = status.serviced;
            for (int i = 1; i < 25; i++)//hourly progress report
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(6000);
            }
            DateOfTest = DateTime.Now;
            TravelOfTest = TotalTravel;
            Fuel = 1200;
            this.BusStatus = 0;
        }
        /// <summary>
        /// Refueling method
        /// </summary>
        /// <param name="sender">the bus</param>
        /// <param name="e">more details</param>
        public void BusRefueling(object sender, DoWorkEventArgs e)
        {
            this.BusStatus = status.refueling;
            for (int i = 1; i <= 1200; i++)
            {
                Fuel = i;
                (sender as BackgroundWorker).ReportProgress(i);//progress report
                Thread.Sleep(10);
            }
            this.BusStatus = status.ready;
        }
    }
}
