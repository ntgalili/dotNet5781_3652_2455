using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DO;
namespace DS
{
    public static class DataSource
   {
        public static List<Bus> ListBuses;
        public static List<Line> ListLines;
        public static List<LineStation> ListLineStations;
        public static List<LineTrip> ListLineTrips;
        public static List<Station> ListStations;
        public static List<Trip> ListTrips;
        public static List<User> ListUsers;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            ListBuses = new List<Bus>
                    {
                        new Bus
                        {
                          LicensePlate= 12345678,
                          FromDate = new DateTime(2018/01/01),
                          TotalTrip=300,
                          FuelRemain=1000,
                          Status=StatusOfBus.Ready
                        },



                          new Bus
                        {
                          LicensePlate= 23456789,
                          FromDate = new DateTime(2018/01/01),
                          TotalTrip=300,
                          FuelRemain=1000,
                          Status=StatusOfBus.Ready
                        },

                          new Bus
                        {
                          LicensePlate= 87654321,
                          FromDate = new DateTime(2018/01/01),
                          TotalTrip=300,
                          FuelRemain=1000,
                          Status=StatusOfBus.Ready
                        }
                    };


            ListLines = new List<Line>
                    {

                        new Line
                        {
                           LineNum=14,
                           Code=1,
                           Area=Areas.Jerusalem,
                           FirstStation=1234,
                           LastStation=9876
                        },
                        //........
                    };


            //......
        }
    }
}

