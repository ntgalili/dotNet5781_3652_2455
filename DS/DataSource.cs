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
                    LineNum=33,
                    Code=1,
                    Area=Areas.Jerusalem,
                    FirstStation=1234,
                    LastStation=9876
                },
                     
                new Line
                {
                    LineNum=20,
                    Code=5,
                    Area=Areas.North,
                    FirstStation=5555,
                    LastStation=8493
                },

                new Line
                {
                    LineNum=79,
                    Code=9,
                    Area=Areas.General,
                    FirstStation=5555,
                    LastStation=9876
                }
            };

            ListLineStations = new List<LineStation>
            {
                new LineStation
                {
                    LineNum=33,
                    StationCode=1234,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=9876
                },
                new LineStation
                {
                    LineNum=33,
                    StationCode=9876,
                    LineStationIndex=2,
                    PrevStation=1234,
                    NextStation=0
                },

                new LineStation
                {
                    LineNum=20,
                    StationCode=5555,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=8493
                },
                new LineStation
                {
                    LineNum=33,
                    StationCode=8493 ,
                    LineStationIndex=2,
                    PrevStation=5555,
                    NextStation=0
                },

                new LineStation
                {
                    LineNum=79,
                    StationCode=5555,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=8493
                },
                new LineStation
                {
                    LineNum=33,
                    StationCode=8493,
                    LineStationIndex=2,
                    PrevStation=5555,
                    NextStation=0
                },
            };

          
        }
    }
}

