using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace dotNet5781_01_3652_2455
{/// <summary>
/// Bus definition class
/// </summary>
    class Bus
    {
        public string LicensePlate;
        public DateTime StartTime;
        public DateTime DateOfTest;
        public float TravelOfTest;
        public float TotalTravel;
        public float Fuel;
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="Num">The bus's License Plate</param>
        /// <param name="Date">The bus's first day on the road</param>
        public Bus(string Num, DateTime Date)
        {
            LicensePlate = Num;
            StartTime = Date;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 1200;
        }
        /// <summary>
        /// The method print the bus's License Plate and the travel since the last test
        /// </summary>
        public void Print()
        { 
            Console.WriteLine("License Plate of bus: {0}, the travel: {1}", LicensePlate, TotalTravel - TravelOfTest);
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


    class Program
    {
        /// <summary>
        /// the possible action
        /// </summary>
        enum Action { Exit, NewBus, chooseBus, Services, SeeTravel };

        /// <summary>
        /// The method check whether the Bus's License Plate and the date are appropriate
        /// </summary>
        /// <param name="str">The License Plate</param>
        /// <param name="date">The bus's first day on the road</param>
        /// <returns>true if the License Plate and the date are appropriate and false if not </returns>
        static bool Check(string str, DateTime Date)
        {
            if (Date.Year < 2018 && str.Length == 9)
                return true;
            if (Date.Year >= 2018 && str.Length == 10)
                return true;
            return false;  
        }

        /// <summary>
        /// find a bus in a list of buses
        /// </summary>
        /// <param name="ListOfBuses">The list of buses</param>
        /// <param name="Num">The License Plate of the bus that we are looking for</param>
        /// <returns>The bus if it is found and null if not</returns>
        static Bus Find(List<Bus> ListOfBuses, string Num)
        {
             foreach ( Bus b in ListOfBuses)//go over the list and find the bus
                if (b.LicensePlate == Num)//if the bus is found - return it
                   return b;
            return null;
        }

        /// <summary>
        /// The main method - the method is used to manage buses details
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("0: Exit \n1: enter new bus \n2:choosing a bus for travel \n3:services \n4:print total travel");
            List<Bus> ListOfBuses=new List<Bus> ();
            bool Flag;
            string StrChoice, StrNum, StrDate,StrToDo;
            Action Choice;
            DateTime Date;
            Bus Bus1;
            int NumKM = 0;
            Random R = new Random(DateTime.Now.Millisecond);
            //Perform actions according to the user's choice
            do
            {
                Console.WriteLine("enter your choice:");
                StrChoice = Console.ReadLine();
                Flag = Action.TryParse(StrChoice, out Choice);
                switch (Choice)
                {
                    case Action.NewBus:    //add a new bus to the list
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            StrNum = Console.ReadLine();
                            Console.WriteLine("enter the date the bus entered the roads:");
                            StrDate = Console.ReadLine();
                            Flag = DateTime.TryParse(StrDate, out Date);
                            if (!Check(StrNum, Date))//check if the details is o.k. by calling the check method' and prinf "error" if not
                            {
                                Console.WriteLine("ERROR");
                            }
                            else
                            {
                                Bus1 = new Bus(StrNum, Date);
                                ListOfBuses.Add(Bus1);//add the new bus 
                            }
                            break;
                        }
                    case Action.chooseBus:       //choose a bus to a travel
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            StrNum = Console.ReadLine();
                            NumKM = R.Next(0, 1200);  //a random travel
                            Bus1 = Find(ListOfBuses, StrNum);//find the bus by calling "find" method
                            if (Bus1 == null)//if the bus is not found
                                Console.WriteLine("the bus is not on the list!");
                            else
                            {
                                if (!(Bus1.AddKM(NumKM)))//if the bus can not do the travel
                                    Console.WriteLine("the bus can not travel!");
                            }
                            break;
                        }
                    case Action.Services:   // services to the bus
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            StrNum = Console.ReadLine();
                            Console.WriteLine("What do you want to do?     enter 'f' to fuel or 't' to test: ");
                            StrToDo = Console.ReadLine();
                            Bus1 = Find(ListOfBuses, StrNum);//find the bus
                            if (Bus1 == null)//if the bus is not found
                                Console.WriteLine("the bus is not on the list!");
                            else
                                Bus1.BusService(StrToDo);//do the service
                        }
                        break;
                    case Action.SeeTravel://print the travels of all the list
                        {
                            foreach (Bus b in ListOfBuses)//go over the list and print the travels
                                b.Print();//print the License Plate and the travel of the bus by calling "print" method
                        }
                        break;
                    case Action.Exit:           //Exit the program
                        Console.WriteLine("bye bye!");
                        Console.ReadKey();
                        return;
                    default:                //error choice
                        Console.WriteLine("ERROR choice, please try again!");
                        break;
                }
            } while (true);
        }
    }
}

//0: Exit
//1: enter new bus
//2:choosing a bus for travel
//3:servic
//4:print total travel
//enter your choice:
//1
//enter the bus License Plate:
//12 - 345 - 67
//enter the date the bus entered the roads:
//15 / 02 / 2016
//enter your choice:
//1
//enter the bus License Plate:
//234 - 56 - 789
//enter the date the bus entered the roads:
//10 / 05 / 2020
//enter your choice:
//3
//enter the bus License Plate:
//12 - 345 - 67
//What do you want to do? enter 'f' to fuel or 't' to test:
//t
//enter your choice:
//2
//enter the bus License Plate:
//12 - 345 - 67
//enter your choice:
//2
//enter the bus License Plate:
//234 - 56 - 789
//enter your choice:
//2
//enter the bus License Plate:
//123 - 56 - 78
//the bus is not on the list!
//enter your choice:
//4
//License Plate of bus: 12 - 345 - 67, the travel: 730
//License Plate of bus: 234 - 56 - 789, the travel: 804
//enter your choice:
//9
//ERROR choice, please try again!
//enter your choice:
//0
//bye bye!
//
