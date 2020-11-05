﻿using System;
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
        public Bus(long Num, DateTime Date)
        {
            LicensePlate = Num;
            StartTime = Date;
            DateOfTest = Date;
            TravelOfTest = 0;
            TotalTravel = 0;
            Fuel = 1200;
        }
        public long LicensePlate;
        public DateTime StartTime;
        public DateTime DateOfTest;
        public float TravelOfTest;
        public float TotalTravel;
        public float Fuel;
        public void print()
        {
            Console.WriteLine("License Plate of bus: {0}, the travel: {1}",
                LicensePlate.ToString(StartTime < new DateTime(2018, 1, 1) ? "00-000-00" : "000-00-000"),
                TotalTravel - TravelOfTest);
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

        static bool check(long num, DateTime date)
        {
            if (date < new DateTime(2018, 1, 1) && (num >= 1000000 && num <= 9999999))
                return true;
            if (date >= new DateTime(2018, 1, 1) && (num >= 10000000 && num <= 99999999))
                return true;
            return false;
        }
        static Bus find(List<Bus> ListOfBuses, long Num)
        {
             foreach ( Bus b in ListOfBuses)
                if (b.LicensePlate == Num)
                   return b;
            return null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("0: Exit \n1: enter new bus \n2:choosing a bus for travel \n3:services \n4:print total travel");
            List<Bus> ListOfBuses=new List<Bus> ();
            bool flag;
            string strChoice, strNum, strDate,strToDo;
            Action choice;
            DateTime date;
            Bus bus1;
            int numKM = 0;
            Random r = new Random(DateTime.Now.Millisecond);
            long numOfBus = 0;
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
                            flag=long.TryParse(strNum,out numOfBus);
                            Console.WriteLine("enter the date the bus entered the roads:");
                            strDate = Console.ReadLine();
                            flag = DateTime.TryParse(strDate, out date);
                            flag = check(numOfBus, date);
                            if (flag == false)
                            {
                                Console.WriteLine("ERROR");
                            }
                            else
                            {
                                bus1 = new Bus(numOfBus, date);
                                ListOfBuses.Add(bus1);
                            }
                            break;
                        }
                    case Action.chooseBus:
                        {
                            Console.WriteLine("enter the bus License Plate:");
                            strNum = Console.ReadLine();
                            flag = long.TryParse(strNum, out numOfBus);
                            numKM = r.Next(0, 1200);
                            bus1 = find(ListOfBuses, numOfBus);
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
                            flag = long.TryParse(strNum, out numOfBus);
                            Console.WriteLine("What do you want to do?     enter 'f' to fuel or 't' to test: ");
                            strToDo = Console.ReadLine();
                            bus1 = find(ListOfBuses,numOfBus);
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
                        Console.ReadKey();
                        return;
                    default:
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
