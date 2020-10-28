using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace dotNet5781_01_3652_2455
{
    class Bus
    {
        public string LicensePlate;
        public DateTime StartTime;
        public DateTime DateOfTest;
        public float TravelOfTest;
        public float TotalTravel;
        public float Fuel;
    }
    class Program
    {
        enum Action { Exit, NewBus, chooseBus, Services, SeeTravel };

         static bool check(string str,DateTime date)
        {
            if (date.Year < 2018 && str.Length == 9)
                return true;
            if (date.Year >= 2018 && str.Length == 10)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            List<Bus> ListOfBuses;
            bool flag;
            string strChoice,strNum,strDate;
            Action choice;
            DateTime date;
            do
            {
                Console.WriteLine("enter your choice:");
                strChoice = Console.ReadLine();
                flag = Action.TryParse(strChoice, out choice);
                switch (choice)
                {
                    case Action.NewBus:
                        Console.WriteLine("enter the bus License Plate:");
                        strNum = Console.ReadLine();
                        Console.WriteLine("enter the date the bus entered the roads:");
                        strDate = Console.ReadLine();
                        flag = DateTime.TryParse(strDate, out date);
                        flag = check(strNum, date);

                        break;
                    case Action.chooseBus:
                        break;
                    case Action.Services:
                        break;
                    case Action.SeeTravel:
                        break;
                    case Action.Exit:
                        return;
                    default:
                        break;
                }
            } while (true);

        }
        reugdbicohb;ofpefkdoglrf;/
    }
}
