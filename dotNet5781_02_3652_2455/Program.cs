using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_3652_2455
{
    /// <summary>
    /// the class describes a bus stop 
    /// </summary>
    class BusStop
    {
        protected int code; //the bus stop code
        /// <summary>
        /// code's property
        /// </summary>
        public int Code
        {
            get => code;

            internal set
            {
                if (value <= 999999 && value >= 1)//When the code is valid
                    code = value;
                else //when the value invalid
                    throw new CodeErrorException("error code");
            }
        }
        protected double latitude;
        /// <summary>
        /// Latitude's property
        /// </summary>
        public double Latitude { get => latitude; internal set => latitude = value; }


        protected double longitude;
        /// <summary>
        /// Longitude's property
        /// </summary>
        public double Longitude { get => longitude; internal set => longitude = value; }

        protected string address;
        /// <summary>
        /// Address's property
        /// </summary>
        public string Address
        {
            get => address;
            internal set
            {
                if (value != null)////When the address is valid
                    address = value;
                else //if the address is invalid
                {
                    address = " ";
                    throw new AddressErrorException("error address - default value entered");
                }
            }
        }



        /// <summary>
        /// c_tor 
        /// </summary>
        /// <param name="c">the code</param>
        /// <param name="a">the address</param>
        public BusStop(int c, string a = " ")
        {
            Code = c;
            Address = a;
            Random r = new Random(DateTime.Now.Millisecond);
            Latitude = r.NextDouble() * (33.3 - 31) + 31; //random location in Israel
            Longitude = r.NextDouble() * (35.5 - 34.3) + 34.3; //random location in Israel
        }



        /// <summary>
        /// representation of the class by a string
        /// </summary>
        /// <returns>string</returns>
        override public string ToString()
        {
            return ("Bus Station Code:" + Code + "," + Latitude + "°N" + Longitude + "°E");
        }


        /// <summary>
        /// A method checks whether the BusStops are equal
        /// </summary>
        /// <param name="obj">The BusStop to check</param>
        /// <returns>if the BusStop are equal return true, if not return false</returns>
        public override bool Equals(object obj)
        {
            if (((BusStop)obj).code == code)//Bus stations are equal, when their code is the same
            {
                return true;
            }
            return false;
        }
    }





    /// <summary>
    /// the class describes a line bus stop
    /// </summary>
    class LineBusStop
    {
        BusStop bs;
        /// <summary>
        /// bs property
        /// </summary>
        internal BusStop BS { get => bs; private set => bs = value; }


        protected double distance;
        /// <summary>
        /// distance property
        /// </summary>
        public double Distance { get => distance; internal set => distance = value; }
        
        
        
        TimeSpan timeFromLastBS;
        /// <summary>
        /// timeFromLastBS property
        /// </summary>
        public TimeSpan TimeFromLastBS { get => timeFromLastBS; private set => timeFromLastBS = value; }



        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="MyBusStop">the bus stop</param>
        LineBusStop(BusStop MyBusStop)
        {
            bs.Code = MyBusStop.Code;
            bs.Address = MyBusStop.Address;
            bs.Latitude = MyBusStop.Latitude;
            bs.Longitude = MyBusStop.Longitude;

            Random r = new Random(DateTime.Now.Millisecond);
            distance = r.NextDouble() * (100000 - 500) + 500; //Random distance
            TimeFromLastBS = new TimeSpan(((int)(distance / 1300) / 60), ((int)(distance / 1300) % 60), 0);//Time between stations as a function of distance
        }


        /// <summary>
        /// representation of the class by a string
        /// </summary>
        /// <returns>string of the code of the bus stop</returns>
        override public string ToString()
        {
            return bs.Code.ToString();
        }


        /// <summary>
        /// A method checks whether the line BusStops are equal
        /// </summary>
        /// <param name="obj">The line BusStop to check</param>
        /// <returns>if the line BusStop are equal return true, if not return false</returns>
        public override bool Equals(object obj)
        {
            //line busstops are equal when they are located at the same bus stop and when the distance and travel time from the previous line busstops are the same
            if (distance.Equals(((LineBusStop)obj).distance) && TimeFromLastBS.Equals(((LineBusStop)obj).TimeFromLastBS) && bs.Equals(((LineBusStop)obj).BS))
                return true;
            return false;
        }
    }




    /// <summary>
    /// enum To define a line activity area
    /// </summary>
    enum Area { General, North, South, Center, Jerusalem };

   
    /// <summary>
    /// class for setting up a bus line
    /// </summary>
    class LineBus : IComparable
    {

        Area travelArea;
        /// <summary>
        /// travelArea property
        /// </summary>
        public Area TravelArea { get => TravelArea; private set => TravelArea = value; }

        /// <summary>
        /// The route of the line
        /// </summary>
        List<LineBusStop> route;
        /// <summary>
        /// route property
        /// </summary>
        internal List<LineBusStop> Route
        {
            get => route;
            set
            {
                foreach (LineBusStop lbs in value)///Gets a collection of stations and adds you to the route
                    route.Add(lbs);
            }
        }


        int lineNum;
        /// <summary>
        /// lineNum property
        /// </summary>
        public int LineNum
        {
            get => lineNum;
            protected set
            {
                if (value > 0)//When the number is valid
                    lineNum = value;
                else//When the number is invalid
                    throw new LineNumErrorException("ERROR LineNum");
            }
        }


        private LineBusStop firstStop;
        /// <summary>
        /// firstStop property
        /// </summary>
        internal LineBusStop FirstStop { get => firstStop; private set => firstStop = value; }


        private LineBusStop lastStop;
        /// <summary>
        /// lastStop property
        /// </summary>
        internal LineBusStop LastStop { get => lastStop; private set => lastStop = value; }

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="numBus">line number</param>
        /// <param name="myStations">the line route</param>
        /// <param name="a">//teh line area</param>
        LineBus(int numBus, List<LineBusStop> myStations, Area a)
        {
            LineNum = numBus;
            Route = myStations;
            firstStop = route[0];
            lastStop = route.Last();
            travelArea = a;
        }

        /// <summary>
        /// representation of the class by a string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return ("Line number:" + LineNum + " Area: " + TravelArea.ToString() + " Route:" + route.ToString());
        }

        /// <summary>
        /// indexer operator
        /// </summary>
        /// <param name="i">the bus stop index</param>
        /// <returns>the bus stop</returns>
        public LineBusStop this[int i]
        {
            get
            {
                if (i < 0 || i >= route.Count)//if the index is invalid
                {
                    throw new IndexErrorException();
                }
                return route[i];//return the bus stop
            }
            set
            {
                if (i < 0 || i >= route.Count)//if the index is invalid
                {
                    throw new IndexErrorException();
                }
                route[i] = value;//Placement of the bus stop
            }
        }


        /// <summary>
        /// add bus stop to the route
        /// </summary>
        /// <param name="i">the index to add the bus stop</param>
        /// <param name="NewStop">the line bus stop to add</param>
        public void Add(int i, LineBusStop NewStop)
        {
            route.Insert(i, NewStop);
        }

        /// <summary>
        /// delete a bus stop from the route
        /// </summary>
        /// <param name="i">the code of the line bus stop to delete</param>
        public void delete(int code)
        {
            for (int i=0;i<route.Count;i++)
            {
                if (route[i].BS.Code == code)//if the code of the line bus stop and the code to delete is same 
                {
                    route.RemoveAt(i);//remove the line bus stop
                    break;
                }
            }
        }

        ///// <summary>
        ///// Checks if a particular bus stop exists on the route
        ///// </summary>
        ///// <param name="LBS">the line bus stop to search</param>
        ///// <returns></returns>
        //public bool search(LineBusStop LBS)
        //{
        //    if (route.IndexOf(LBS) != -1)//if the line bus stop is in the route 
        //        return true;
        //    return false;
        //}


        /// <summary>
        /// Checks if a particular bus stop exists on the route
        /// </summary>
        /// <param name="myCode">the bus stop's code</param>
        /// <returns>true if the bus stop is in the route and alse if not</returns>
        public bool check(int myCode)
        {
            foreach (LineBusStop lbs in route)//Scanning the bus stops on the route
            {
                if (myCode==lbs.BS.Code)//if the bus stop is in the route
                    return true;
            }
            return false;
        }


        /// <summary>
        /// find the distance between 2 line bus stops
        /// </summary>
        /// <param name="lbs1">line bus stop 1</param>
        /// <param name="lbs2">line bus stop 2</param>
        /// <returns>the distance</returns>
        public double FindDistance(LineBusStop lbs1, LineBusStop lbs2)
        {
            if (!(check(lbs1.BS.Code) && check(lbs2.BS.Code)))//if the bus stop's are not in the route
            {
                throw new FindErrorException("the bus stops were not found");
            }

            double distanceBetween = 0;
            LineBusStop first;
            bool flag = true;
            foreach (LineBusStop lbs in route)////Scanning the bus stops on the route
            {
                if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)) && flag)//find the first bus stop 
                {
                    first = lbs;
                    flag = false;
                }
                else
                {
                    if (!flag)//When the first bus stop is found start summing up the distance
                    {
                        distanceBetween += lbs.Distance;
                        if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)))//when the last bus stop is found stop summing up the distance
                            break;
                    }
                }
            }
            return distanceBetween;
        }
        public TimeSpan findTime(LineBusStop lbs1, LineBusStop lbs2)
        {
            TimeSpan timeBetween = new TimeSpan();
            LineBusStop first;
            bool flag = true;
            foreach (LineBusStop lbs in route)
            {
                if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)) && flag)
                {
                    first = lbs;
                    flag = false;
                }
                else
                {
                    if (!flag)
                    {
                        timeBetween = timeBetween + lbs.TimeFromLastBS;
                        if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)))
                            break;
                    }
                }
            }
            return timeBetween;
        }

        public LineBus SubRoute(LineBusStop lbs1, LineBusStop lbs2)
        {
            List<LineBusStop> sub=new List<LineBusStop>();
            bool flag = true;
            foreach (LineBusStop lbs in route)
            {
                if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)) && flag)
                {
                    flag = false;
                    sub.Add(lbs);
                }
                else
                {
                    if (!flag)
                    {
                        sub.Add(lbs);
                        if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)))
                            break;
                    }
                }
            }
            return new LineBus(LineNum,sub,travelArea);
        }

        public int CompareTo(object obj)
        {
            TimeSpan ObjTime= ((LineBus)obj).findTime(((LineBus)obj).FirstStop, ((LineBus)obj).LastStop);
            TimeSpan MyTime= findTime(FirstStop, LastStop);
            return (MyTime.CompareTo(ObjTime));
        }

        public override bool Equals(object obj)
        {
            return ((((LineBus)obj).LineNum.Equals(LineNum))&& (((LineBus)obj).FirstStop.Equals(FirstStop)) && (((LineBus)obj).LastStop.Equals(LastStop)));
        }
    }





    class Program
    {
        
        static void Main(string[] args)
        {

            string Ans;
            int num1,num2,num3;
            bool flag = true;
            List<BusStop> listOfBustops = new List<BusStop>();
            Console.WriteLine("Enter 40 bus stops:");
            for(int i=0;i<40;i++)
            {
                Console.WriteLine("enter the code: 000000");
                Ans =Console.ReadLine();
                flag = int.TryParse(Ans, out num1);
                if (!flag)
                {
                    Console.WriteLine("Error: the code is incorrect");
                    i--;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("enter the address");
                    Ans = Console.ReadLine();
                    try
                    {
                        foreach(BusStop bs in listOfBustops)
                        {
                            if (bs.Code == num1)
                                throw new AddErrorException("There is alreadya station with the same code");
                            listOfBustops.Add(new BusStop(num1, Ans));
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex);
                        i--;
                    }


                }


            }

            Console.WriteLine("Enter 10 Line buses");
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("enter a line number");
                Ans = Console.ReadLine();
                flag = int.TryParse(Ans, out num1);
                if (!flag)
                {
                    Console.WriteLine("Error number");
                    i--;
                }
                else
                {
                    Console.WriteLine("enter the code of the first bus stop");

                }
            }
              
        }

    }

}





