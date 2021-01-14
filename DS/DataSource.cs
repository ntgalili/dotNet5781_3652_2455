using System;
using System.Collections.Generic;
using System.Device.Location;
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
        private static Random r = new Random();
        private static double  distance(double X1, double Y1, double X2, double Y2)
        {
            var sCoord = new GeoCoordinate(X1, Y1);
            var eCoord = new GeoCoordinate(X1, Y1);
            
            return sCoord.GetDistanceTo(eCoord);
        }
       

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
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=401,
                    Name="נהר הירקון/נהר הירדן, בית שמש",
                    Longitude=35.0002,
                    Lattitude= 31.70735,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=407,
                    Name="נחל הקישון/ נחל שורק, בית שמש",
                    Longitude=34.989861,
                    Lattitude= 31.715411,
                    Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                    Code=480,
                    Name="שדרות נהר הירקון/אליהו הנביא, בית שמש",
                    Longitude=35.001165,
                    Lattitude= 31.706773,
                    Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                    Code=562,
                    Name="שדרות בן זאב/38, בית שמש",
                    Longitude=34.974625,
                    Lattitude= 31.746677,
                    Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                    Code=563,
                    Name="שד.בן גוריון/שד.הדקל, בית שמש",
                    Longitude=34.980749,
                    Lattitude= 31.744038,
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=564,
                    Name="בן זאב/רש''י, בית שמש",
                    Longitude=34.992222,
                    Lattitude= 31.742662,
                    Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                    Code=565,
                    Name="בית ישראל/שפת אמת, בית שמש",
                    Longitude=34.995005,
                    Lattitude= 31.742295,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=566,
                    Name="שפת אמת/חיים הלוי, בית שמש",
                    Longitude=34.995859,
                    Lattitude= 31.740288,
                    Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                    Code=567,
                    Name="שפת אמת/בית יעקב, בית שמש",
                    Longitude=34.995833,
                    Lattitude= 31.738094,
                    Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                    Code=568,
                    Name="חזון אי''ש/שפת אמת, בית שמש",
                    Longitude=34.995107,
                    Lattitude= 31.73755,
                    Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                    Code=569,
                    Name="חזון איש/אברהם, בית שמש",
                    Longitude=34.993086,
                    Lattitude= 31.738594,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=571,
                    Name="רש'י/ חזון איש, בית שמש",
                    Longitude=34.991397,
                    Lattitude= 31.741169,
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=572,
                    Name="מעפילי אגוז/רשי, בית שמש",
                    Longitude=34.991023,
                    Lattitude= 31.74045,
                    Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                    Code=573,
                    Name="שד.נהר הירדן/שד.הרב הרצוג, בית שמש",
                    Longitude=34.992279,
                    Lattitude= 31.736319,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=574,
                    Name="שדרות נהר הירדן/קדושת אהרן, בית שמש",
                    Longitude=34.991927,
                    Lattitude= 31.733992,
                    Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                    Code=575,
                    Name="שדרות נהר הירדן/האדמו''ר מבעלז, בית שמש",
                    Longitude=34.993077,
                    Lattitude= 31.731931,
                    Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                    Code=172,
                    Name="גבעת שאול/כתב סופר, ירושלים",
                    Longitude=35.195972,
                    Lattitude= 31.791222,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=174,
                    Name="גבעת שאול/קוטלר, ירושלים",
                    Longitude=35.194683,
                    Lattitude= 31.791653,
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=176,
                    Name="גבעת שאול/נג'ארה, ירושלים",
                    Longitude=35.192721,
                    Lattitude= 31.792105,
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=179,
                    Name="נג'ארה/בן עוזיאל, ירושלים",
                    Longitude=35.191168,
                    Lattitude= 31.789376,
                    Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                    Code=180,
                    Name="כפר שאול/קצנלבוגן, ירושלים",
                    Longitude=35.179234,
                    Lattitude= 31.786054,
                    Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                    Code=57023,
                    Name="דוד אלעזר/לח''י, צפת",
                    Longitude=35.489648,
                    Lattitude= 32.963282,
                    Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                    Code=57025,
                    Name="חיים וייצמן/הרצל, צפת",
                    Longitude=35.496737,
                    Lattitude= 32.957234,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code=57026,
                    Name="חיים וייצמן/מ''ג יורדי הסירה, צפת",
                    Longitude=35.498349,
                    Lattitude= 32.957294,
                    Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                    Code=57027,
                    Name="אליהו פרומצ'נקו/יעקב לוי, צפת",
                    Longitude=35.498143,
                    Lattitude= 32.960467,
                    Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                    Code=57028,
                    Name="פרומצנקו/רימוני, צפת",
                    Longitude=35.498795,
                    Lattitude= 32.961903,
                    Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                    Code = 20902,
                    Name = "שד' ישראל גורי/דרך קיבוץ גלויות, תל אביב",
                    Longitude = 34.780691,
                    Lattitude = 32.046386,
                    Include=StationInclude.DigitalScreen,
                    Active=true
                 },
                new Station
                 {
                     Code = 21000,
                     Name = "ביה''ח איכילוב/שד' דוד המלך, תל אביב",
                     Longitude = 34.787792,
                     Lattitude = 32.079787,
                     Include=StationInclude.Eccess,
                     Active=true
                 },
                new Station
                 {
                     Code = 21022,
                     Name = "ת. רכבת השלום, תל אביב",
                     Longitude = 34.792974,
                     Lattitude = 32.073112,
                     Include=StationInclude.LinesRoute,
                     Active=true
                 },
                new Station
                 {
                     Code = 21024,
                     Name = "ליאונרדו דה וינצ'י/קפלן, תל אביב",
                     Longitude = 34.784808,
                     Lattitude = 32.073875,
                     Include=StationInclude.Bench,
                     Active=true
                 },
                new Station
                 {
                     Code = 21005,
                     Name = "ארלוזורוב/דיזנגוף, תל אביב",
                     Longitude = 34.774385,
                     Lattitude = 32.087073,
                     Include=StationInclude.Roof,
                     Active=true
                 },
                new Station
                 {
                     Code = 21161,
                     Name = "דרך ז'בוטינסקי/אהרונוביץ, בני ברק",
                     Longitude = 34.840305,
                     Lattitude = 32.092564,
                     Include=StationInclude.LinesRoute,
                     Active=true
                 },                 
                new Station
                {
                     Code = 21165,
                     Name = "מגדל ויטה/דרך בן גוריון, בני ברק",
                     Longitude = 34.822193,
                     Lattitude = 32.094143,
                     Include=StationInclude.Eccess,
                     Active=true
                },                 
                new Station
                {
                     Code = 21230,
                     Name = "דרך בן גוריון/יהושע בן נון, בני ברק",
                     Longitude = 34.822562,
                     Lattitude = 32.092133,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                },                 
                new Station
                {
                     Code = 21232,
                     Name = "דרך בן גוריון/מגדים, בני ברק",
                     Longitude = 34.82271,
                     Lattitude = 32.088772,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                },                 
                new Station
                {
                     Code = 21365,
                     Name = "דרך ז'בוטינסקי/דב גרונר, בני ברק",
                     Longitude = 34.828052,
                     Lattitude = 32.091763,
                     Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                     Code = 46203,
                     Name = "אבא חושי/פארק הכרמל, חיפה",
                     Longitude = 35.020919,
                     Lattitude = 32.758695,
                     Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                     Code = 46216,
                     Name = "ת. רכבת חוף הכרמל, חיפה",
                     Longitude = 34.957647,
                     Lattitude = 32.793065,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                     Code = 46217,
                     Name = "נווה דוד, חיפה",
                     Longitude = 34.958184,
                     Lattitude = 32.805604,
                     Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                     Code = 46233,
                     Name = "אסתר המלכה, חיפה",
                     Longitude = 34.963318,
                     Lattitude = 32.809908,
                     Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                     Code = 47092,
                     Name = "חניתה/אבא הילל סילבר, חיפה",
                     Longitude = 35.013987,
                     Lattitude = 32.790078,
                     Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                     Code = 33537,
                     Name = "יחיאל מיכל פינס/הרב קטרוני, פתח תקווה",
                     Longitude = 34.890714,
                     Lattitude = 32.07915,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                     Code = 33553,
                     Name = "חיים ארלוזורוב/הרצפלד, פתח תקווה",
                     Longitude = 34.873652,
                     Lattitude = 32.084529,
                     Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                     Code = 34063,
                     Name = "בלינסון קניון אבנת/מסוף יותם ויואב, פתח תקווה",
                     Longitude = 34.865101,
                     Lattitude = 32.091798,
                     Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                     Code = 34934,
                     Name = "החרש/עמל, פתח תקווה",
                     Longitude = 34.852768,
                     Lattitude = 32.096057,
                     Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                     Code = 35311,
                     Name = "אלכסנדר זייד/שטרוק, פתח תקווה",
                     Longitude = 34.86392,
                     Lattitude = 32.076699,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                },
                new Station
                {
                     Code = 36446,
                     Name = "בית החולים תל השומר/מד''א, רמת גן",
                     Longitude = 34.845992,
                     Lattitude = 32.046427,
                     Include=StationInclude.Eccess,
                     Active=true
                },
                new Station
                {
                     Code = 36480,
                     Name = "עמק האלה/שד' אהרון קציר, רמת גן",
                     Longitude = 34.848083,
                     Lattitude = 32.052359,
                     Include=StationInclude.LinesRoute,
                     Active=true
                },
                new Station
                {
                     Code = 36481,
                     Name = "מנדס/שד' אהרון קציר, רמת גן",
                     Longitude = 34.846952,
                     Lattitude = 32.053695,
                     Include=StationInclude.Bench,
                     Active=true
                },
                new Station
                {
                     Code = 37136,
                     Name = "כביש 4/מחלף בר אילן, רמת גן",
                     Longitude = 34.838934,
                     Lattitude = 32.065048,
                     Include=StationInclude.Roof,
                     Active=true
                },
                new Station
                {
                     Code = 37780,
                     Name = "בית החולים תל השומר/מעבדות, רמת גן",
                     Longitude = 34.844102,
                     Lattitude = 32.047317,
                     Include=StationInclude.DigitalScreen,
                     Active=true
                }
            };

            ListLines = new List<Line>
            {
                new Line
                {
                   LineNum=7,
                   Code=1,
                   Active=true,
                   Area=Areas.Jerusalem,
                   FirstStation=1,
                   LastStation=407,
                },
                new Line
                {
                   LineNum=650,
                   Code=2,
                   Active=true,
                   Area=Areas.General,
                   FirstStation=172,
                   LastStation=57028,
                },
                new Line
                {
                   LineNum=420,
                   Code=3,
                   Active=true,
                   Area=Areas.Center,
                   FirstStation=21022,
                   LastStation=21161,
                },
                new Line
                {
                   LineNum=497,
                   Code=4,
                   Active=true,
                   Area=Areas.General,
                   FirstStation=21161,
                   LastStation=480,
                },
                new Line
                {
                   LineNum=8,
                   Code=5,
                   Active=true,
                   Area=Areas.Center,
                   FirstStation=33553,
                   LastStation=37780,
                },
                new Line
                {
                   LineNum=417,
                   Code=6,
                   Active=true,
                   Area=Areas.Jerusalem,
                   FirstStation=480,
                   LastStation=180,
                },
                new Line
                {
                   LineNum=402,
                   Code=7,
                   Active=true,
                   Area=Areas.Center,
                   FirstStation=180,
                   LastStation=21365,
                },
                new Line
                {
                   LineNum=153,
                   Active=true,
                   Code=8,
                   Area=Areas.North,
                   FirstStation=21365,
                   LastStation=57028,
                },
                new Line
                {
                   LineNum=921,
                   Active=true,
                   Code=9,
                   Area=Areas.Center,
                   FirstStation=37780,
                   LastStation=33537,
                },
                new Line
                {
                   LineNum=89,
                   Active=true,
                   Code=10,
                   Area=Areas.Center,
                   FirstStation=21005,
                   LastStation=47092,
                }
            };

            ListLineStations = new List<LineStation>
            {
                //line 7
                new LineStation
                {
                    LineCode=1,
                    StationCode=1,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=565
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=565,
                    LineStationIndex=2,
                    PrevStation=1,
                    NextStation=566
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=566,
                    LineStationIndex=3,
                    PrevStation=565,
                    NextStation=567
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=567,
                    LineStationIndex=4,
                    PrevStation=566,
                    NextStation=568
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=568,
                    LineStationIndex=5,
                    PrevStation=567,
                    NextStation=569
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=569,
                    LineStationIndex=6,
                    PrevStation=568,
                    NextStation=574
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=574,
                    LineStationIndex=7,
                    PrevStation=569,
                    NextStation=575
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=575,
                    LineStationIndex=8,
                    PrevStation=564,
                    NextStation=480
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=480,
                    LineStationIndex=9,
                    PrevStation=575,
                    NextStation=407
                },
                new LineStation
                {
                    LineCode=1,
                    StationCode=407,
                    LineStationIndex=10,
                    PrevStation=480,
                    NextStation=0
                },

                //line 650
                new LineStation
                {
                    LineCode=2,
                    StationCode=172,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=174
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=174,
                    LineStationIndex=2,
                    PrevStation=172,
                    NextStation=176
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=176,
                    LineStationIndex=3,
                    PrevStation=174,
                    NextStation=179
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=179,
                    LineStationIndex=4,
                    PrevStation=176,
                    NextStation=57023
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=57023,
                    LineStationIndex=5,
                    PrevStation=179,
                    NextStation=57025
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=57025,
                    LineStationIndex=6,
                    PrevStation=57023,
                    NextStation=57026
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=57026,
                    LineStationIndex=7,
                    PrevStation=57025,
                    NextStation=57027
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=57027,
                    LineStationIndex=8,
                    PrevStation=57026,
                    NextStation=57028
                },
                new LineStation
                {
                    LineCode=2,
                    StationCode=57028,
                    LineStationIndex=9,
                    PrevStation=57027,
                    NextStation=0
                },

                //line 420
                new LineStation
                {
                    LineCode=3,
                    StationCode=21022,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=21024
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21024,
                    LineStationIndex=2,
                    PrevStation=21022,
                    NextStation=20902
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=20902,
                    LineStationIndex=3,
                    PrevStation=21024,
                    NextStation=21000
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21000,
                    LineStationIndex=4,
                    PrevStation=20902,
                    NextStation=21005
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21005,
                    LineStationIndex=5,
                    PrevStation=21000,
                    NextStation=21365
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21365,
                    LineStationIndex=6,
                    PrevStation=21005,
                    NextStation=21165
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21165,
                    LineStationIndex=7,
                    PrevStation=21365,
                    NextStation=21230
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21230,
                    LineStationIndex=8,
                    PrevStation=21165,
                    NextStation=21232
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21232,
                    LineStationIndex=9,
                    PrevStation=21230,
                    NextStation=21161
                },
                new LineStation
                {
                    LineCode=3,
                    StationCode=21161,
                    LineStationIndex=10,
                    PrevStation=480,
                    NextStation=0
                },

                ///line 497
                new LineStation
                {
                    LineCode=4,
                    StationCode=21161,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=21165
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=21165,
                    LineStationIndex=2,
                    PrevStation=21161,
                    NextStation=21230
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=21230,
                    LineStationIndex=3,
                    PrevStation=21165,
                    NextStation=21232
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=21232,
                    LineStationIndex=4,
                    PrevStation=21230,
                    NextStation=21365
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=21365,
                    LineStationIndex=5,
                    PrevStation=21232,
                    NextStation=562
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=562,
                    LineStationIndex=6,
                    PrevStation=21365,
                    NextStation=563
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=563,
                    LineStationIndex=7,
                    PrevStation=562,
                    NextStation=564
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=564,
                    LineStationIndex=8,
                    PrevStation=563,
                    NextStation=407
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=407,
                    LineStationIndex=9,
                    PrevStation=564,
                    NextStation=480
                },
                new LineStation
                {
                    LineCode=4,
                    StationCode=480,
                    LineStationIndex=10,
                    PrevStation=407,
                    NextStation=0
                },

                //line 8
                new LineStation
                {
                    LineCode=5,
                    StationCode=33553,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=34063
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=34063,
                    LineStationIndex=2,
                    PrevStation=33553,
                    NextStation=34934
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=34934,
                    LineStationIndex=3,
                    PrevStation=34063,
                    NextStation=35311
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=35311,
                    LineStationIndex=4,
                    PrevStation=34934,
                    NextStation=36446
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=36446,
                    LineStationIndex=5,
                    PrevStation=35311,
                    NextStation=36480
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=36480,
                    LineStationIndex=6,
                    PrevStation=36446,
                    NextStation=36481
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=36481,
                    LineStationIndex=7,
                    PrevStation=36480,
                    NextStation=37136
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=37136,
                    LineStationIndex=8,
                    PrevStation=36481,
                    NextStation=37780
                },
                new LineStation
                {
                    LineCode=5,
                    StationCode=37780,
                    LineStationIndex=9,
                    PrevStation=37136,
                    NextStation=0
                },
     
                //line 417
                new LineStation
                {
                    LineCode=6,
                    StationCode=480,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=407
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=407,
                    LineStationIndex=2,
                    PrevStation=480,
                    NextStation=401
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=401,
                    LineStationIndex=3,
                    PrevStation=407,
                    NextStation=563
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=563,
                    LineStationIndex=4,
                    PrevStation=401,
                    NextStation=573
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=573,
                    LineStationIndex=5,
                    PrevStation=563,
                    NextStation=574
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=574,
                    LineStationIndex=6,
                    PrevStation=573,
                    NextStation=172
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=172,
                    LineStationIndex=7,
                    PrevStation=574,
                    NextStation=174
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=174,
                    LineStationIndex=8,
                    PrevStation=172,
                    NextStation=179
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=179,
                    LineStationIndex=9,
                    PrevStation=174,
                    NextStation=180
                },
                new LineStation
                {
                    LineCode=6,
                    StationCode=180,
                    LineStationIndex=10,
                    PrevStation=179,
                    NextStation=0
                },

                //line 402
                new LineStation
                {
                    LineCode=7,
                    StationCode=180,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=179
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=179,
                    LineStationIndex=2,
                    PrevStation=180,
                    NextStation=176
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=176,
                    LineStationIndex=3,
                    PrevStation=179,
                    NextStation=174
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=174,
                    LineStationIndex=4,
                    PrevStation=176,
                    NextStation=172
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=172,
                    LineStationIndex=5,
                    PrevStation=174,
                    NextStation=21161
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=21161,
                    LineStationIndex=6,
                    PrevStation=172,
                    NextStation=21165
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=21165,
                    LineStationIndex=7,
                    PrevStation=21161,
                    NextStation=21230
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=21230,
                    LineStationIndex=8,
                    PrevStation=21165,
                    NextStation=21365
                },
                new LineStation
                {
                    LineCode=7,
                    StationCode=21365,
                    LineStationIndex=9,
                    PrevStation=21230,
                    NextStation=0
                },

                //line 89
                new LineStation
                {
                    LineCode=10,
                    StationCode=21005,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=21024
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=21024,
                    LineStationIndex=2,
                    PrevStation=21005,
                    NextStation=21022
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=21022,
                    LineStationIndex=3,
                    PrevStation=21024,
                    NextStation=21000
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=21000,
                    LineStationIndex=4,
                    PrevStation=21022,
                    NextStation=20902
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=20902,
                    LineStationIndex=5,
                    PrevStation=21000,
                    NextStation=46203
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=46203,
                    LineStationIndex=6,
                    PrevStation=20902,
                    NextStation=46216
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=46216,
                    LineStationIndex=7,
                    PrevStation=46203,
                    NextStation=46217
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=46217,
                    LineStationIndex=8,
                    PrevStation=46216,
                    NextStation=46233
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=46233,
                    LineStationIndex=9,
                    PrevStation=46217,
                    NextStation=47092
                },
                new LineStation
                {
                    LineCode=10,
                    StationCode=47092,
                    LineStationIndex=10,
                    PrevStation=46233,
                    NextStation=0
                },

                //line 921
                new LineStation
                {
                    LineCode=9,
                    StationCode=37780,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=37136
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=37136,
                    LineStationIndex=2,
                    PrevStation=37780,
                    NextStation=36481
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=36481,
                    LineStationIndex=3,
                    PrevStation=37136,
                    NextStation=36480
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=36480,
                    LineStationIndex=4,
                    PrevStation=36481,
                    NextStation=34063
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=34063,
                    LineStationIndex=5,
                    PrevStation=36480,
                    NextStation=36446
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=36446,
                    LineStationIndex=6,
                    PrevStation=34063,
                    NextStation=35311
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=35311,
                    LineStationIndex=7,
                    PrevStation=36446,
                    NextStation=34934
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=34934,
                    LineStationIndex=8,
                    PrevStation=35311,
                    NextStation=33553
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=33553,
                    LineStationIndex=9,
                    PrevStation=34934,
                    NextStation=33537
                },
                new LineStation
                {
                    LineCode=9,
                    StationCode=33537,
                    LineStationIndex=10,
                    PrevStation=33553,
                    NextStation=0
                },

                //line 153
                new LineStation
                {
                    LineCode=8,
                    StationCode=21365,
                    LineStationIndex=1,
                    PrevStation=0,
                    NextStation=21232
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=21232,
                    LineStationIndex=2,
                    PrevStation=21365,
                    NextStation=21230
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=21230,
                    LineStationIndex=3,
                    PrevStation=21232,
                    NextStation=21165
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=21165,
                    LineStationIndex=4,
                    PrevStation=21230,
                    NextStation=21161
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=21161,
                    LineStationIndex=5,
                    PrevStation=21165,
                    NextStation=57023
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=57023,
                    LineStationIndex=6,
                    PrevStation=21161,
                    NextStation=57025
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=57025,
                    LineStationIndex=7,
                    PrevStation=57023,
                    NextStation=57026
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=57026,
                    LineStationIndex=8,
                    PrevStation=57025,
                    NextStation=57027
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=57027,
                    LineStationIndex=9,
                    PrevStation=57026,
                    NextStation=57028
                },
                new LineStation
                {
                    LineCode=8,
                    StationCode=57028,
                    LineStationIndex=10,
                    PrevStation=57027,
                    NextStation=0
                }
            };

            ListAdjStations = new List<AdjacentStetions>
            {
                new AdjacentStetions
                {
                    Station1=480,
                    Station2=407,
                    Distance=distance(35.001165,31.715411,34.989861,31.715411),
                    Time=new TimeSpan(0,(int)(distance(35.001165,31.715411,34.989861,31.715411)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=407,
                    Station2=401,
                    Distance=distance(34.989861,31.715411,35.0002,31.70735),
                    Time=new TimeSpan(0,(int)(distance(34.989861,31.715411,35.0002,31.70735)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=401,
                    Station2=563,
                    Distance=distance(35.0002,31.70735,34.980749,31.744038),
                    Time=new TimeSpan(0,(int)(distance(35.0002,31.70735,34.980749,31.744038)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=563,
                    Station2=573,
                    Distance=distance(34.980749,31.744038,34.992279,31.736319),
                    Time=new TimeSpan(0,(int)(distance(34.980749,31.744038,34.992279,31.736319)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=573,
                    Station2=574,
                    Distance=distance(34.992279,31.736319,34.991927,31.733992),
                    Time=new TimeSpan(0,(int)(distance(34.992279,31.736319,34.991927,31.733992)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=574,
                    Station2=172,
                    Distance=distance(34.991927,31.733992,35.195972,31.791222),
                    Time=new TimeSpan(0,(int)(distance(34.991927,31.733992,35.195972,31.791222)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=172,
                    Station2=174,
                    Distance=distance(35.195972,31.791222,35.194683,31.791653),
                    Time=new TimeSpan(0,(int)(distance(35.195972,31.791222,35.194683,31.791653)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=174,
                    Station2=179,
                    Distance=distance(35.194683,31.791653,35.191168,31.789376),
                    Time=new TimeSpan(0,(int)(distance(35.194683,31.791653,35.191168,31.789376)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=179,
                    Station2=180,
                    Distance=distance(35.191168,31.789376,35.179234,31.786054),
                    Time=new TimeSpan(0,(int)(distance(35.191168,31.789376,35.179234,31.786054)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=179,
                    Station2=57023,
                    Distance=distance(35.191168,31.789376,35.489648,32.963282),
                    Time=new TimeSpan(0,(int)(distance(35.191168,31.789376,35.489648,32.963282)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=179,
                    Station2=176,
                    Distance=distance(35.191168,31.789376,35.192721,31.792105),
                    Time=new TimeSpan(0,(int)(distance(35.191168,31.789376,35.192721,31.792105)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=176,
                    Station2=179,
                    Distance=distance(35.192721,31.792105,35.191168,31.789376),
                    Time=new TimeSpan(0,(int)(distance(35.192721,31.792105,35.191168,31.789376)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=176,
                    Station2=174,
                    Distance=distance(35.192721,31.792105,35.194683,31.791653),
                    Time=new TimeSpan(0,(int)(distance(35.192721,31.792105,35.194683,31.791653)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=172,
                    Station2=21161,
                    Distance=distance(35.195972,31.791222,34.840305,32.092564),
                    Time=new TimeSpan(0,(int)(distance(35.195972,31.791222,34.840305,32.092564)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21161,
                    Station2=21165,
                    Distance=distance(34.840305,32.092564,34.822193,32.094143),
                    Time=new TimeSpan(0,(int)(distance(34.840305,32.092564,34.822193,32.094143)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21165,
                    Station2=21230,
                    Distance=distance(34.822193,32.094143,34.822562,32.092133),
                    Time=new TimeSpan(0,(int)(distance(34.822193,32.094143,34.822562,32.092133)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21230,
                    Station2=21365,
                    Distance=distance(34.822562,32.092133,34.828052,32.091763),
                    Time=new TimeSpan(0,(int)(distance(34.822562,32.092133,34.828052,32.091763)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21005,
                    Station2=21024,
                    Distance=distance(34.774385,32.087073,34.784808,32.073875),
                    Time=new TimeSpan(0,(int)(distance(34.774385,32.087073,34.784808,32.073875)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21024,
                    Station2=21022,
                    Distance=distance(34.784808,32.073875,34.792974,32.073112),
                    Time=new TimeSpan(0,(int)(distance(34.784808,32.073875,34.792974,32.073112)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21022,
                    Station2=21024,
                    Distance=distance(34.792974,32.073112,34.784808,32.073875),
                    Time=new TimeSpan(0,(int)(distance(34.792974,32.073112,34.784808,32.073875)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21022,
                    Station2=21000,
                    Distance=distance(34.792974,32.073112,34.787792,32.079787),
                    Time=new TimeSpan(0,(int)(distance(34.792974,32.073112,34.787792,32.079787)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21000,
                    Station2=20902,
                    Distance=distance(34.787792,32.079787,34.780691,32.046386),
                    Time=new TimeSpan(0,(int)(distance(34.787792,32.079787,34.780691,32.046386)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=20902,
                    Station2=21000 ,
                    Distance=distance(34.780691,32.046386,34.787792,32.079787),
                    Time=new TimeSpan(0,(int)(distance(34.780691,32.046386,34.787792,32.079787)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=20902,
                    Station2=46203,
                    Distance=distance(34.780691,32.046386,35.020919,32.758695),
                    Time=new TimeSpan(0,(int)(distance(34.780691,32.046386,35.020919,32.758695)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=46203,
                    Station2=46216,
                    Distance=distance(35.020919,32.758695,34.957647,32.793065),
                    Time=new TimeSpan(0,(int)(distance(35.020919,32.758695,34.957647,32.793065)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=46216,
                    Station2=46217,
                    Distance=distance(34.957647,32.793065,34.958184,32.805604),
                    Time=new TimeSpan(0,(int)(distance(34.957647,32.793065,34.958184,32.805604)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=46217,
                    Station2=46233,
                    Distance=distance(34.958184,32.805604,34.963318,32.809908),
                    Time=new TimeSpan(0,(int)(distance(34.958184,32.805604,34.963318,32.809908)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=46233,
                    Station2=47092,
                    Distance=distance(34.963318,32.809908,35.013987,32.790078),
                    Time=new TimeSpan(0,(int)(distance(34.963318,32.809908,35.013987,32.790078)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=37780,
                    Station2=37136,
                    Distance=distance(34.844102,32.047317,34.838934,32.065048),
                    Time=new TimeSpan(0,(int)(distance(34.844102,32.047317,34.838934,32.065048)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=37136,
                    Station2=37780,
                    Distance=distance(34.838934,32.065048,34.844102,32.047317),
                    Time=new TimeSpan(0,(int)(distance(34.838934,32.065048,34.844102,32.047317)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=37136,
                    Station2=36481,
                    Distance=distance(34.838934,32.065048,34.846952,32.053695),
                    Time=new TimeSpan(0,(int)(distance(34.838934,32.065048,34.846952,32.053695)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36481,
                    Station2=36480,
                    Distance=distance(34.846952,32.053695,34.848083,32.052359),
                    Time=new TimeSpan(0,(int)(distance(34.846952,32.053695,34.848083,32.052359)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36480,
                    Station2=36481,
                    Distance=distance(34.848083,32.052359,34.846952,32.053695),
                    Time=new TimeSpan(0,(int)(distance(34.846952,32.053695,34.848083,32.052359)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36481,
                    Station2=34063,
                    Distance=distance(34.846952,32.053695,34.865101,32.091798),
                    Time=new TimeSpan(0,(int)(distance(34.846952,32.053695,34.865101,32.091798)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36480,
                    Station2=34063,
                    Distance=distance(34.848083,32.052359,34.865101,32.091798),
                    Time=new TimeSpan(0,(int)(distance(34.848083,32.052359,34.865101,32.091798)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=34063,
                    Station2=36446,
                    Distance=distance(34.865101,32.091798,34.845992,32.046427),
                    Time=new TimeSpan(0,(int)(distance(34.865101,32.091798,34.845992,32.046427)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36446,
                    Station2=35311,
                    Distance=distance(34.845992,32.046427,34.86392,32.076699),
                    Time=new TimeSpan(0,(int)(distance(34.845992,32.046427,34.86392,32.076699)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=35311,
                    Station2=34934,
                     Distance=distance(34.86392,32.076699,34.852768,32.096057),
                    Time=new TimeSpan(0,(int)(distance(34.86392,32.076699,34.852768,32.096057)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=34934,
                    Station2=35311,
                     Distance=distance(34.852768,32.096057,34.86392,32.076699),
                    Time=new TimeSpan(0,(int)(distance(34.852768,32.096057,34.86392,32.076699)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=34934,
                    Station2=33553,
                    Distance=distance(34.852768,32.096057,34.873652,32.084529),
                    Time=new TimeSpan(0,(int)(distance(34.852768,32.096057,34.873652,32.084529)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=33553,
                    Station2=33537,
                     Distance=distance(34.873652,32.084529,34.890714,32.07915),
                    Time=new TimeSpan(0,(int)(distance(34.873652,32.084529,34.890714,32.07915)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21365,
                    Station2=21232,
                     Distance=distance(34.828052,32.091763,34.82271,32.088772),
                    Time=new TimeSpan(0,(int)(distance(34.828052,32.091763,34.82271,32.088772)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21232,
                    Station2=21230,
                     Distance=distance(34.82271,32.088772,34.822562,32.092133),
                    Time=new TimeSpan(0,(int)(distance(34.82271,32.088772,34.822562,32.092133)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21230,
                    Station2=21232,
                     Distance=distance(34.822562,32.092133,34.82271,32.088772),
                    Time=new TimeSpan(0,(int)(distance(34.822562,32.092133,34.82271,32.088772)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21232,
                    Station2=21161,
                     Distance=distance(34.82271,32.088772,34.840305,31.744547),
                    Time=new TimeSpan(0,(int)(distance(34.82271,32.088772,34.840305,31.744547)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21161,
                    Station2=57023,
                     Distance=distance(34.840305,31.744547,35.489648,32.963282),
                    Time=new TimeSpan(0,(int)(distance(34.840305,31.744547,35.489648,32.963282)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=57023,
                    Station2=57025,
                     Distance=distance(35.489648,32.963282,35.496737,32.957234),
                    Time=new TimeSpan(0,(int)(distance(35.489648,32.963282,35.496737,32.957234)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=57025,
                    Station2=57026,
                     Distance=distance(35.496737,32.957234,35.498349,32.957294),
                    Time=new TimeSpan(0,(int)(distance(35.496737,32.957234,35.498349,32.957294)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=57026,
                    Station2=57027,
                     Distance=distance(35.498349,32.957294,35.498143,32.960467),
                    Time=new TimeSpan(0,(int)(distance(35.498349,32.957294,35.498143,32.960467)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=57027,
                    Station2=57028,
                     Distance=distance(35.498143,32.960467,35.498795,32.961903),
                    Time=new TimeSpan(0,(int)(distance(35.498143,32.960467,35.498795,32.961903)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=1,
                    Station2=565,

                    Distance=distance(35.000493,31.744547,34.995005,31.742295),
                    Time=new TimeSpan(0,(int)(distance(35.000493,31.744547,34.995005,31.742295)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=565,
                    Station2=566,

                    Distance=distance(34.995005,31.742295,34.995859,31.740288),
                    Time=new TimeSpan(0,(int)(distance(34.995005,31.742295,34.995859,31.740288)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=566,
                    Station2=567,

                    Distance=distance(34.995859,31.740288,34.995833,31.738094),
                    Time=new TimeSpan(0,(int)(distance(34.995859,31.740288,34.995833,31.738094)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=567,
                    Station2=568,

                    Distance=distance(34.995833,31.738094,34.995107,31.73755),
                    Time=new TimeSpan(0,(int)(distance(34.995833,31.738094,34.995107,31.73755)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=568,
                    Station2=569,

                    Distance=distance(34.995107,31.73755,34.993086,31.738594),
                    Time=new TimeSpan(0,(int)(distance(34.995107,31.73755,34.993086,31.738594)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=569,
                    Station2=574,

                    Distance=distance(34.993086,31.738594,34.991927,31.733992),
                    Time=new TimeSpan(0,(int)(distance(34.993086,31.738594,34.991927,31.733992)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=574,
                    Station2=575,

                    Distance=distance(34.991927,31.733992,34.993077,31.731931),
                    Time=new TimeSpan(0,(int)(distance(34.991927,31.733992,34.993077,31.731931)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=575,
                    Station2=480,

                    Distance=distance(34.993077,31.731931,35.001165,31.706773),
                    Time=new TimeSpan(0,(int)(distance(34.993077,31.731931,35.001165,31.706773)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=480,
                    Station2=407,

                    Distance=distance(35.001165,31.706773,34.989861,31.715411),
                    Time=new TimeSpan(0,(int)(distance(35.001165,31.706773,34.989861,31.715411)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=21024,
                    Station2=20902,

                    Distance=distance(34.784808,32.073875,34.780691,32.046386),
                    Time=new TimeSpan(0,(int)(distance(34.784808,32.073875,34.780691,32.046386)*r.NextDouble()),0),

                },
                new AdjacentStetions
                {
                    Station1=21000,
                    Station2=21005,
                    Distance=distance(34.792974,32.073112,34.774385,32.087073),
                    Time=new TimeSpan(0,(int)(distance(34.792974,32.073112,34.774385,32.087073)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21005,
                    Station2=21365,
                    Distance=distance(34.774385,32.087073,34.828052,32.091763),
                    Time=new TimeSpan(0,(int)(distance(34.774385,32.087073,34.828052,32.091763)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21365,
                    Station2=21165,
                     Distance=distance(34.828052,32.091763,34.822193,32.094143),
                    Time=new TimeSpan(0,(int)(distance(34.828052,32.091763,34.822193,32.094143)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=174,
                    Station2=176,
                    Distance=distance(35.194683,31.791653,35.192721,31.792105),
                    Time=new TimeSpan(0,(int)(distance(35.194683,31.791653,35.192721,31.792105)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21232,
                    Station2=21365,
                     Distance=distance(34.82271,32.088772,34.828052,32.091763),
                    Time=new TimeSpan(0,(int)(distance(34.82271,32.088772,34.828052,32.091763)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=21365,
                    Station2=562,
                     Distance=distance(34.828052,32.091763,34.974625,31.746677),
                    Time=new TimeSpan(0,(int)(distance(34.828052,32.091763,34.974625,31.746677)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=562,
                    Station2=563,
                    Distance=distance(34.980749,31.744038,34.992279,31.736319),
                    Time=new TimeSpan(0,(int)(distance(34.980749,31.744038,34.992279,31.736319)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=563,
                    Station2=564,
                    Distance=distance(34.980749,31.744038,34.992222,31.742662),
                    Time=new TimeSpan(0,(int)(distance(34.980749,31.744038,34.992222,31.742662)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=564,
                    Station2=407,
                    Distance=distance(34.992222,31.742662,34.989861,31.715411),
                    Time=new TimeSpan(0,(int)(distance(34.992222,31.742662,34.989861,31.715411)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=407,
                    Station2=480,
                    Distance=distance(34.989861,31.715411,35.001165,31.715411),
                    Time=new TimeSpan(0,(int)(distance(34.989861,31.715411,35.001165,31.715411)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=33553,
                    Station2=34063,
                     Distance=distance(34.873652,32.084529,34.865101,32.091798),
                    Time=new TimeSpan(0,(int)(distance(34.873652,32.084529,34.865101,32.091798)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=34063,
                    Station2=34934,
                    Distance=distance(34.865101,32.091798,34.852768,32.096057),
                    Time=new TimeSpan(0,(int)(distance(34.865101,32.091798,34.852768,32.096057)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=35311,
                    Station2=36446,
                    Distance=distance(34.86392,32.076699,34.845992,32.046427),
                    Time=new TimeSpan(0,(int)(distance(34.86392,32.076699,34.845992,32.046427)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36446,
                    Station2=36480,
                    Distance=distance(34.845992,32.046427,34.848083,32.052359),
                    Time=new TimeSpan(0,(int)(distance(34.845992,32.046427,34.848083,32.052359)*r.NextDouble()),0),
                },
                new AdjacentStetions
                {
                    Station1=36481,
                    Station2=37136,
                    Distance=distance(34.846952,32.053695,34.838934,32.065048),
                    Time=new TimeSpan(0,(int)(distance(34.846952,32.053695,34.838934,32.065048)*r.NextDouble()),0),
                },
            };
         
        }
        
    }
}

