using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_3652_2455
{
    /// <summary>
    /// Bus definition class
    /// </summary>
    class Bus
    {
        public long LicensePlate;
        public DateTime StartTime;
        public DateTime DateOfTest;
        public float TravelOfTest;
        public float TotalTravel;
        public float Fuel;
        enum status { ready,traveling,refueling,serviced};//enum for the bus status
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="Num">The bus's License Plate</param>
        /// <param name="Date">The bus's first day on the road</param>
        public Bus(long Num, DateTime Date)
        {
            LicensePlate = Num;
            StartTime = Date;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 0;
        }
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
        /// <param name="ToDo">the service</param>
        public void BusService(string ToDo)
        {
            switch (ToDo)
            {
                case "f":        //to fuel the bus
                    Fuel = 1200;
                    break;
                case "t":       //to do test
                    DateOfTest = DateTime.Now;
                    TravelOfTest = TotalTravel;
                    break;
                default:       //error string
                    Console.WriteLine("ERROR! Service not found");
                    break;
            }
        }
    }
}
