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
        static List<int> codesBusStop;
        protected int code; //the bus stop code
        /// <summary>
        /// code's property
        /// </summary>
        public int Code
        {
            get => code;
            internal set
            {
                if (value <= 999999 && value >= 1)
                {
                    foreach (int num in codesBusStop)
                    {
                        if (num == value)
                            throw new CodeErrorException("error code");
                    }
                    code = value;
                    codesBusStop.Add(code);
                }
                else //when the value invalid
                {
                    throw new CodeErrorException("error code");
                }
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
                if (value != null)
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
        public override bool Equals(object obj)
        {
            if (((BusStop)obj).code == code)
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
        internal BusStop BS { get => bs; private set => bs = value; }
        protected double distance;
        public double Distance { get => distance; internal set => distance = value; }
        TimeSpan timeFromLastBS;
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
            distance = r.NextDouble() * (100000 - 500) + 500;
            TimeFromLastBS = new TimeSpan(((int)(distance / 1300) / 60), ((int)(distance / 1300) % 60), 0);
        }
        override public string ToString()
        {
            return bs.Code.ToString();
        }
        public override bool Equals(object obj)
        {
            if (distance.Equals(((LineBusStop)obj).distance) && TimeFromLastBS.Equals(((LineBusStop)obj).TimeFromLastBS) && bs.Equals(((LineBusStop)obj).BS))
                return true;
            return false;
        }
    }





    enum Area { General, North, South, Center, Jerusalem };
    class LineBus : IComparable
    {

        Area travelArea;
        public Area TravelArea { get => TravelArea; private set => TravelArea = value; }

        List<LineBusStop> route;
        internal List<LineBusStop> Route
        {
            get => route;
            set
            {
                foreach (LineBusStop lbs in value)
                    route.Add(lbs);
            }
        }
        int lineNum;
        public int LineNum
        {
            get => lineNum;
            protected set
            {
                if (value > 0)
                    lineNum = value;
                else
                    throw new LineNumErrorException("ERROR LineNum");
            }
        }
        private LineBusStop firstStop;
        internal LineBusStop FirstStop { get => firstStop; private set => firstStop = value; }
        private LineBusStop lastStop;
        internal LineBusStop LastStop { get => lastStop; private set => lastStop = value; }
        LineBus(int numBus, List<LineBusStop> myStations, Area a)
        {
            LineNum = numBus;
            Route = myStations;
            firstStop = route[0];
            lastStop = route.Last();
            travelArea = a;
        }
        public override string ToString()
        {
            return ("Line number:" + LineNum + " Area: " + TravelArea.ToString() + " Route:" + route.ToString());
        }
        public LineBusStop this[int i]
        {
            get
            {
                if (i < 0 || i >= route.Count)
                {
                    throw new IndexErrorException();
                }
                return route[i];
            }
            set
            {
                if (i < 0 || i >= route.Count)
                {
                    throw new IndexErrorException();
                }
                route[i] = value;
            }
        }
        public void Add(int i, LineBusStop NewStop)
        {
            route.Insert(i, NewStop);
        }
        public void delete(int i)
        {
            route.RemoveAt(i);
        }
        public bool search(LineBusStop LBS)
        {
            if (route.IndexOf(LBS) != -1)
                return true;
            return false;
        }
        public bool check(int myCode)
        {
            foreach (LineBusStop lbs in route)
            {
                if (myCode==lbs.BS.Code)
                    return true;
            }
            return false;
        }
        public double FindDistance(LineBusStop lbs1, LineBusStop lbs2)
        {
            if (!(check(lbs1.BS.Code) && check(lbs2.BS.Code)))
            {
                throw new FindErrorException("the bus stops were not found");
            }

            double distanceBetween = 0;
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
                        distanceBetween += lbs.Distance;
                        if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)))
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
            LineBusStop first;
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
            //try
            //{

            //}
        }

    }

}





