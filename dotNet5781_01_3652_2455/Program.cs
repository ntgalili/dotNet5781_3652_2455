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
        static void Main(string[] args)
        {
            List<Bus> ListOfBuses;
            bool flag;
            string str;
            Action choice;
            do
            {
                Console.WriteLine("enter your choice:");
                str = Console.ReadLine();
                flag = Action.TryParse(str, out choice);
                switch (choice)
                {
                    case Action.Exit:
                        break;
                    case Action.NewBus:
                        break;
                    case Action.chooseBus:
                        break;
                    case Action.Services:
                        break;
                    case Action.SeeTravel:
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
