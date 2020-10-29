using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace dotNet5781_01_3652_2455
{
    class Bus
    {
        public Bus(string Num, DateTime Date)
        {
            LicensePlate = Num;
            StartTime = Date;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 1200;
        }
        public string LicensePlate;
        public DateTime StartTime;
        public DateTime DateOfTest;
        public float TravelOfTest;
        public float TotalTravel;
        public float Fuel;
        public void print()
        { 
            Console.WriteLine("License Plate of bus: {0}, the travel: {1}", LicensePlate, TotalTravel - TravelOfTest);
        }
        public bool AddKM(int numKM)
        {
            if ((TotalTravel - TravelOfTest + numKM) > 20000 || (Fuel < numKM) || (DateOfTest.AddYears(1) < DateTime.Now))
            {
                return false;
            }
            Fuel = Fuel - numKM;
            TotalTravel = TotalTravel + numKM;
            return true;
        }
        public void BusService(string ToDo)
        {
            switch (ToDo)
            {
                case "f":
                    Fuel = 1200;
                    break;
                case "t":
                    DateOfTest = DateTime.Now;
                    TravelOfTest = TotalTravel;
                    break;
                default:
                    Console.WriteLine("ERROR! Service not found");
                    break;
            }
        }
    }




    class Program
    {
        enum Action { Exit, NewBus, chooseBus, Services, SeeTravel };

        static bool check(string str, DateTime date)
        {
            if (date.Year < 2018 && str.Length == 9)
                return true;
            if (date.Year >= 2018 && str.Length == 10)
                return true;
            return false;
        }

        static Bus find(List<Bus> ListOfBuses, string Num)
        {
             foreach ( Bus b in ListOfBuses)
                if (b.LicensePlate == Num)
                   return b;
            return null;
        }

        
        static void Main(string[] args)
        {
            List<Bus> ListOfBuses = null;
            bool flag;
            string strChoice, strNum, strDate,strToDo;
            Action choice;
            DateTime date;
            Bus bus1;
            int numKM = 0;
            Random r = new Random(DateTime.Now.Millisecond);

            do
            {
                Console.WriteLine("enter your choice:");
                strChoice = Console.ReadLine();
                flag = Action.TryParse(strChoice, out choice);
                switch (choice)
                {
                    case Action.NewBus:
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            strNum = Console.ReadLine();
                            Console.WriteLine("enter the date the bus entered the roads:");
                            strDate = Console.ReadLine();
                            flag = DateTime.TryParse(strDate, out date);
                            flag = check(strNum, date);
                            if (flag == false)
                            {
                                Console.WriteLine("ERROR");
                            }
                            else
                            {
                                bus1 = new Bus(strNum, date);
                                ListOfBuses.Add(bus1);
                            }
                            break;
                        }
                    case Action.chooseBus:
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            strNum = Console.ReadLine();
                            numKM = r.Next(0, 1200);
                            bus1 = find(ListOfBuses, strNum);
                            if (bus1 == null)
                                Console.WriteLine("the bus is not on the list!");
                            else
                            {
                                if (!(bus1.AddKM(numKM)))
                                    Console.WriteLine("the bus can not travel!");
                            }
                            break;
                        }
                    case Action.Services:
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            strNum = Console.ReadLine();
                            Console.WriteLine("What do you want to do?     enter 'f' to fuel or 't' to test: ");
                            strToDo = Console.ReadLine();
                            bus1 = find(ListOfBuses, strNum);
                            if (bus1 == null)
                                Console.WriteLine("the bus is not on the list!");
                            else
                                bus1.BusService(strToDo);
                        }
                        break;
                    case Action.SeeTravel:
                        {
                            foreach (Bus b in ListOfBuses)
                                b.print();
                        }
                        break;
                    case Action.Exit:
                        Console.WriteLine("bye bye!");
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
