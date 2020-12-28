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
       // public static List<Bus> ListBuses;
        public static List<Line> ListLines;
        public static List<LineStation> ListLineStations;
       // public static List<LineTrip> ListLineTrips;
        public static List<Station> ListStations;
        // public static List<Trip> ListTrips;
        // public static List<User> ListUsers;
        public static List<AdjacentStetions> ListAdjStations;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            //ListBuses = new List<Bus>
            //{
            //            new Bus
            //            {
            //              LicensePlate= 12345678,
            //              FromDate = new DateTime(2018/01/01),
            //              TotalTrip=300,
            //              FuelRemain=1000,
            //              Status=StatusOfBus.Ready
            //            },

            //            new Bus
            //            {
            //              LicensePlate= 23456789,
            //              FromDate = new DateTime(2018/01/01),
            //              TotalTrip=300,
            //              FuelRemain=1000,
            //              Status=StatusOfBus.Ready
            //            },

            //            new Bus
            //            {
            //              LicensePlate= 87654321,
            //              FromDate = new DateTime(2018/01/01),
            //              TotalTrip=300,
            //              FuelRemain=1000,
            //              Status=StatusOfBus.Ready
            //            }
            //};
            ListStations = new List<Station>
            {
                new Station
                {
                    Code=1,
                    Name="יוסף קארו/בן איש חי, בית שמש",
                    Longitude=35.000493,
                    Lattitude= 31.744547,
                },
                new Station
                {
                    Code=401,
                    Name="נהר הירקון/נהר הירדן, בית שמש",
                    Longitude=35.0002,
                    Lattitude= 31.70735,
                },

                new Station
                {
                    Code=407,
                    Name="נחל הקישון/ נחל שורק, בית שמש",
                    Longitude=34.989861,
                    Lattitude= 31.715411,
                },
                new Station
                {
                    Code=480,
                    Name="שדרות נהר הירקון/אליהו הנביא, בית שמש",
                    Longitude=35.001165,
                    Lattitude= 31.706773,
                },
                new Station
                {
                    Code=562,
                    Name="שדרות בן זאב/38, בית שמש",
                    Longitude=34.974625,
                    Lattitude= 31.746677,
                },
                new Station
                {
                    Code=563,
                    Name="שד.בן גוריון/שד.הדקל, בית שמש",
                    Longitude=34.980749,
                    Lattitude= 31.744038,
                },
                new Station
                {
                    Code=564,
                    Name="בן זאב/רש''י, בית שמש",
                    Longitude=34.992222,
                    Lattitude= 31.742662,
                },
                new Station
                {
                    Code=565,
                    Name="בית ישראל/שפת אמת, בית שמש",
                    Longitude=34.995005,
                    Lattitude= 31.742295,
                },
                new Station
                {
                    Code=566,
                    Name="שפת אמת/חיים הלוי, בית שמש",
                    Longitude=34.995859,
                    Lattitude= 31.740288,
                },
                new Station
                {
                    Code=567,
                    Name="שפת אמת/בית יעקב, בית שמש",
                    Longitude=34.995833,
                    Lattitude= 31.738094,
                },
                new Station
                {
                    Code=568,
                    Name="חזון אי''ש/שפת אמת, בית שמש",
                    Longitude=34.995107,
                    Lattitude= 31.73755,
                },
                new Station
                {
                    Code=569,
                    Name="חזון איש/אברהם, בית שמש",
                    Longitude=34.993086,
                    Lattitude= 31.738594,
                },
                new Station
                {
                    Code=571,
                    Name="רש'י/ חזון איש, בית שמש",
                    Longitude=34.991397,
                    Lattitude= 31.741169,
                },
                new Station
                {
                    Code=572,
                    Name="מעפילי אגוז/רשי, בית שמש",
                    Longitude=34.991023,
                    Lattitude= 31.74045,
                },


                new Station
                {
                    Code=573,
                    Name="שד.נהר הירדן/שד.הרב הרצוג, בית שמש",
                    Longitude=34.992279,
                    Lattitude= 31.736319,
                },

                new Station
                {
                    Code=574,
                    Name="שדרות נהר הירדן/קדושת אהרן, בית שמש",
                    Longitude=34.991927,
                    Lattitude= 31.733992,
                },


                new Station
                {
                    Code=575,
                    Name="שדרות נהר הירדן/האדמו''ר מבעלז, בית שמש",
                    Longitude=34.993077,
                    Lattitude= 31.731931,
                },


                 new Station
                {
                    Code=172,
                    Name="גבעת שאול/כתב סופר, ירושלים",
                    Longitude=35.195972,
                    Lattitude= 31.791222,
                },
                new Station
                {
                    Code=174,
                    Name="גבעת שאול/קוטלר, ירושלים",
                    Longitude=35.194683,
                    Lattitude= 31.791653,
                },
                new Station
                {
                    Code=176,
                    Name="גבעת שאול/נג'ארה, ירושלים",
                    Longitude=35.192721,
                    Lattitude= 31.792105,
                },


                new Station
                {
                    Code=179,
                    Name="נג'ארה/בן עוזיאל, ירושלים",
                    Longitude=35.191168,
                    Lattitude= 31.789376,
                },


                new Station
                {
                    Code=180,
                    Name="כפר שאול/קצנלבוגן, ירושלים",
                    Longitude=35.179234,
                    Lattitude= 31.786054,
                },

                new Station
                {
                    Code=180,
                    Name="כפר שאול/קצנלבוגן, ירושלים",
                    Longitude=35.179234,
                    Lattitude= 31.786054,
                },

                new Station
                {
                    Code=57023,
                    Name="דוד אלעזר/לח''י, צפת",
                    Longitude=35.489648,
                    Lattitude= 32.963282,
                },

                  new Station
                {
                    Code=57025,
                    Name="חיים וייצמן/הרצל, צפת",
                    Longitude=35.496737,
                    Lattitude= 32.957234,
                },

                  new Station
                {
                    Code=57026,
                    Name="חיים וייצמן/מ''ג יורדי הסירה, צפת",
                    Longitude=35.498349,
                    Lattitude= 32.957294,
                },

                new Station
                {
                    Code=57027,
                    Name="אליהו פרומצ'נקו/יעקב לוי, צפת",
                    Longitude=35.498143,
                    Lattitude= 32.960467,
                },

                new Station
                {
                    Code=57028,
                    Name="פרומצנקו/רימוני, צפת",
                    Longitude=35.498795,
                    Lattitude= 32.961903,
                },
            };



        }
    }
}

