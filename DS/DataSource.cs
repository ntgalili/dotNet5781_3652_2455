﻿using System;
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
            {//ListBuses = new List<Bus>
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
            }
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

                new Station
                {
                    Code = 20902,
                    Name = "שד' ישראל גורי/דרך קיבוץ גלויות, תל אביב",
                    Longitude = 34.780691,
                    Lattitude = 32.046386,
                 },
                 new Station
                 {
                     Code = 21000,
                     Name = "ביה''ח איכילוב/שד' דוד המלך, תל אביב",
                     Longitude = 34.787792,
                     Lattitude = 32.079787,
                 },
                 new Station
                 {
                     Code = 21022,
                     Name = "ת. רכבת השלום, תל אביב",
                     Longitude = 34.792974,
                     Lattitude = 32.073112,
                 },
                 new Station
                 {
                     Code = 21024,
                     Name = "ליאונרדו דה וינצ'י/קפלן, תל אביב",
                     Longitude = 34.784808,
                     Lattitude = 32.073875,
                 },
                 new Station
                 {
                     Code = 21005,
                     Name = "ארלוזורוב/דיזנגוף, תל אביב",
                     Longitude = 34.774385,
                     Lattitude = 32.087073,
                 },

                 new Station
                 {
                     Code = 21161,
                     Name = "דרך ז'בוטינסקי/אהרונוביץ, בני ברק",
                     Longitude = 34.840305,
                     Lattitude = 32.092564,
                 },                 
                new Station
                {
                     Code = 21165,
                     Name = "מגדל ויטה/דרך בן גוריון, בני ברק",
                     Longitude = 34.822193,
                     Lattitude = 32.094143,
                },                 
                new Station
                {
                     Code = 21230,
                     Name = "דרך בן גוריון/יהושע בן נון, בני ברק",
                     Longitude = 34.822562,
                     Lattitude = 32.092133,
                },                 
                new Station
                {
                     Code = 21232,
                     Name = "דרך בן גוריון/מגדים, בני ברק",
                     Longitude = 34.82271,
                     Lattitude = 32.088772,
                },                 
                new Station
                {
                     Code = 21365,
                     Name = "דרך ז'בוטינסקי/דב גרונר, בני ברק",
                     Longitude = 34.828052,
                     Lattitude = 32.091763,
                },
                new Station
                {
                     Code = 46203,
                     Name = "אבא חושי/פארק הכרמל, חיפה",
                     Longitude = 35.020919,
                     Lattitude = 32.758695,
                },
                new Station
                {
                     Code = 46216,
                     Name = "ת. רכבת חוף הכרמל, חיפה",
                     Longitude = 34.957647,
                     Lattitude = 32.793065,
                },
                new Station
                {
                     Code = 46217,
                     Name = "נווה דוד, חיפה",
                     Longitude = 34.958184,
                     Lattitude = 32.805604,
                },
                new Station
                {
                     Code = 46233,
                     Name = "אסתר המלכה, חיפה",
                     Longitude = 34.963318,
                     Lattitude = 32.809908,
                },
                new Station
                {
                     Code = 47092,
                     Name = "חניתה/אבא הילל סילבר, חיפה",
                     Longitude = 35.013987,
                     Lattitude = 32.790078,
                },
                new Station
                {
                     Code = 33537,
                     Name = "יחיאל מיכל פינס/הרב קטרוני, פתח תקווה",
                     Longitude = 34.890714,
                     Lattitude = 32.07915,
                },
                new Station
                {
                     Code = 33553,
                     Name = "חיים ארלוזורוב/הרצפלד, פתח תקווה",
                     Longitude = 34.873652,
                     Lattitude = 32.084529,
                },
                new Station
                {
                     Code = 34063,
                     Name = "בלינסון קניון אבנת/מסוף יותם ויואב, פתח תקווה",
                     Longitude = 34.865101,
                     Lattitude = 32.091798,
                },
                new Station
                {
                     Code = 34934,
                     Name = "החרש/עמל, פתח תקווה",
                     Longitude = 34.852768,
                     Lattitude = 32.096057,
                },
                new Station
                {
                     Code = 35311,
                     Name = "אלכסנדר זייד/שטרוק, פתח תקווה",
                     Longitude = 34.86392,
                     Lattitude = 32.076699,
                },
                new Station
                {
                     Code = 36446,
                     Name = "בית החולים תל השומר/מד''א, רמת גן",
                     Longitude = 34.845992,
                     Lattitude = 32.046427,
                },
                new Station
                {
                     Code = 36480,
                     Name = "עמק האלה/שד' אהרון קציר, רמת גן",
                     Longitude = 34.848083,
                     Lattitude = 32.052359,
                },
                new Station
                {
                     Code = 36481,
                     Name = "מנדס/שד' אהרון קציר, רמת גן",
                     Longitude = 34.846952,
                     Lattitude = 32.053695,
                },
                new Station
                {
                     Code = 37136,
                     Name = "כביש 4/מחלף בר אילן, רמת גן",
                     Longitude = 34.838934,
                     Lattitude = 32.065048,
                },
                new Station
                {
                     Code = 37780,
                     Name = "בית החולים תל השומר/מעבדות, רמת גן",
                     Longitude = 34.844102,
                     Lattitude = 32.047317,
                }
            };
            ListLines = new List<Line>
            {
                new Line
                {
                   LineNum=7,
                   Code=1,
                   Area=Areas.Jerusalem,
                   FirstStation=1,
                   LastStation=407,
                },
                new Line
                {
                   LineNum=650,
                   Code=1,
                   Area=Areas.General,
                   FirstStation=172,
                   LastStation=57028,
                },
                  new Line
                {
                   LineNum=420,
                   Code=1,
                   Area=Areas.Center,
                   FirstStation=21022,
                   LastStation=21161,
                },

                new Line
                {
                   LineNum=497,
                   Code=1,
                   Area=Areas.General,
                   FirstStation=21161,
                   LastStation=480,
                },

                new Line
                {
                   LineNum=8,
                   Code=1,
                   Area=Areas.Center,
                   FirstStation=33553,
                   LastStation=36481,
                },

            };

            ListLineStations = new List<LineStation>
            {
                new LineStation
                {
                    LineNum=7,
                    StationCode=1,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=565
                },
                 new LineStation
                {
                    LineNum=7,
                    StationCode=565,
                    LineStationIndex=2,
                    PrevStation=1,
                    NextStation=566
                },
                 new LineStation
                {
                    LineNum=7,
                    StationCode=566,
                    LineStationIndex=3,
                    PrevStation=565,
                    NextStation=567
                },
                 new LineStation
                {
                    LineNum=7,
                    StationCode=567,
                    LineStationIndex=4,
                    PrevStation=566,
                    NextStation=568
                },
                 new LineStation
                {
                    LineNum=7,
                    StationCode=568,
                    LineStationIndex=5,
                    PrevStation=567,
                    NextStation=569
                },
                    new LineStation
                {
                    LineNum=7,
                    StationCode=569,
                    LineStationIndex=6,
                    PrevStation=568,
                    NextStation=574
                },
                new LineStation
                {
                    LineNum=7,
                    StationCode=574,
                    LineStationIndex=7,
                    PrevStation=569,
                    NextStation=575
                },
                new LineStation
                {
                    LineNum=7,
                    StationCode=575,
                    LineStationIndex=8,
                    PrevStation=564,
                    NextStation=408
                },
                new LineStation
                {
                    LineNum=7,

                    StationCode=408,
                    LineStationIndex=9,
                    PrevStation=575,
                    NextStation=407
                },
                new LineStation
                {
                    LineNum=7,

                    StationCode=407,
                    LineStationIndex=10,
                    PrevStation=408,
                    NextStation=0
                },

                //line 650

                new LineStation
                {
                    LineNum=650,
                    StationCode=172,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=174
                },
                 new LineStation
                {
                    LineNum=650,
                    StationCode=174,
                    LineStationIndex=2,
                    PrevStation=172,
                    NextStation=176
                },
                 new LineStation
                {
                    LineNum=650,
                    StationCode=176,
                    LineStationIndex=3,
                    PrevStation=174,
                    NextStation=179
                },
                 new LineStation
                {
                    LineNum=650,
                    StationCode=179,
                    LineStationIndex=4,
                    PrevStation=176,
                    NextStation=57023
                },
                 new LineStation
                {
                    LineNum=650,
                    StationCode=57023,
                    LineStationIndex=5,
                    PrevStation=179,
                    NextStation=57025
                },
                    new LineStation
                {
                    LineNum=650,
                    StationCode=57025,
                    LineStationIndex=6,
                    PrevStation=57023,
                    NextStation=57026
                },
                new LineStation
                {
                    LineNum=650,
                    StationCode=57026,
                    LineStationIndex=7,
                    PrevStation=57025,
                    NextStation=57027
                },
                new LineStation
                {
                    LineNum=650,
                    StationCode=57027,
                    LineStationIndex=8,
                    PrevStation=57026,
                    NextStation=57028
                },
                new LineStation
                {
                    LineNum=650,

                    StationCode=57028,
                    LineStationIndex=9,
                    PrevStation=57027,
                    NextStation=0
                },


                //line 420

                new LineStation
                {
                    LineNum=420,
                    StationCode=21022,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=21024
                },
                 new LineStation
                {
                    LineNum=420,
                    StationCode=21024,
                    LineStationIndex=2,
                    PrevStation=21022,
                    NextStation=20902
                },
                 new LineStation
                {
                    LineNum=420,
                    StationCode=20902,
                    LineStationIndex=3,
                    PrevStation=21024,
                    NextStation=21000
                },
                 new LineStation
                {
                    LineNum=420,
                    StationCode=21000,
                    LineStationIndex=4,
                    PrevStation=20902,
                    NextStation=21005
                },
                 new LineStation
                {
                    LineNum=420,
                    StationCode=21005,
                    LineStationIndex=5,
                    PrevStation=21000,
                    NextStation=21365
                },
                    new LineStation
                {
                    LineNum=420,
                    StationCode=21365,
                    LineStationIndex=6,
                    PrevStation=21005,
                    NextStation=21165
                },
                new LineStation
                {
                    LineNum=420,
                    StationCode=21165,
                    LineStationIndex=7,
                    PrevStation=21365,
                    NextStation=21230
                },
                new LineStation
                {
                    LineNum=420,
                    StationCode=21230,
                    LineStationIndex=8,
                    PrevStation=21165,
                    NextStation=21232
                },
                new LineStation
                {
                    LineNum=420,

                    StationCode=21232,
                    LineStationIndex=9,
                    PrevStation=21230,
                    NextStation=21161
                },
                new LineStation
                {
                    LineNum=420,
                    StationCode=21161,
                    LineStationIndex=10,
                    PrevStation=408,
                    NextStation=0
                },


                ///
            };


        }
    }
}

