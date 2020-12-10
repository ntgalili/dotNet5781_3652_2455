﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_3652_2455
{
    public enum ToDo { TestService, FuelService };
    public enum status { ready, traveling, refueling, serviced };//enum for the bus status
    /// <summary>
    /// Bus definition class
    /// </summary>
    public class Bus
    {

        private DateTime startTime;
        public DateTime StartTime { get => startTime; set => startTime = value; }

        private long licensePlate;
        public long LicensePlate 
        { 
            get => licensePlate; 
            set
            {
                if(StartTime.Year>=2018)
                {
                    while(value < 10000000)
                    {
                        value = value * 10;
                    }
                    licensePlate = value % 100000000; 

                }
                if (StartTime.Year < 2018)
                {
                    while (value < 1000000)
                    {
                        value = value * 10;
                    }
                    licensePlate = value % 10000000;
                }
            }
        }

        private DateTime dateOfTest;
        public DateTime DateOfTest { get => dateOfTest; set => dateOfTest = value; }

        private float travelOfTest;
        public float TravelOfTest { get => travelOfTest; set => travelOfTest = value; }

        private float totalTravel;
        public float TotalTravel { get => totalTravel; set => totalTravel = value; }

        private float fuel;
        public float Fuel { get => fuel; set => fuel = value; }

        private status busStatus;
        private status BusStatus { get => busStatus; set => busStatus = value; }

        
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="Num">The bus's License Plate</param>
        /// <param name="Date">The bus's first day on the road</param>
        public Bus(long Num, DateTime Date)
        {
            StartTime = Date;
            LicensePlate = Num;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 0;
            
        }
        public Bus() { }
        /// <summary>
        /// The method print the bus's License Plate and the travel since the last test
        /// </summary>
        public void Print()
        {
            Console.WriteLine("License Plate of bus: {0}, the travel: {1}",
                 LicensePlate.ToString(StartTime < new DateTime(2018, 1, 1) ? "00-000-00" : "000-00-000"),
                 TotalTravel - TravelOfTest);
        }
        /// <summary>
        /// the method checks whether the bus can travel and update its details if so
        /// </summary>
        /// <param name="numKM">The Km of the new travel</param>
        /// <returns>true-if the travel can made and false if not</returns>
        public bool AddKM(int numKM)
        {
            if ((TotalTravel - TravelOfTest + numKM) > 20000 || (Fuel < numKM) || (DateOfTest.AddYears(1) < DateTime.Now))//if  the bus is dangerous or it does not have enough fuel
            {
                return false;
            }
            Fuel = Fuel - numKM;//update the details
            TotalTravel = TotalTravel + numKM;
            return true;
        }
        /// <summary>
        /// The method performs services for the bus
        /// </summary>
        /// <param name="ToDoSomething">the service</param>
        public void BusService(ToDo ToDoSomething)
        {
            if (ToDoSomething == 0)
            {
                DateOfTest = DateTime.Now;
                TravelOfTest = TotalTravel;
            }
            Fuel = 1200;
            this.busStatus = 0;
        }
    }
}
