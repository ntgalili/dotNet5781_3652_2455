﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_3652_2455
{
    using System.CodeDom;
    using System.Runtime.Serialization;
 
[Serializable]
    public class ErrorException : Exception
    {
        public int capacity { get; private set; }
 
        public ErrorException() : base() { }
        public ErrorException(string message) : base(message) { }
        public ErrorException(string message, Exception inner) : base(message, inner) { }
        protected ErrorException(SerializationInfo info, StreamingContext context)
	 : base(info, context) { }
        // special constructor for our custom exception
        public ErrorException(int capacity, string message) : base(message)
        { this.capacity = capacity; }
 
        override public string ToString()
        { return "ErrorException:" + Message; }
    }

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
            protected set 
            {
                if (value <= 999999 && value >= 1)
                    code = value;
                else //when the value invalid
                {
                    code = 0;
                    throw new ErrorException ("ERROR code");
                }
                    
            } 
        }
        protected double latitude;

        /// <summary>
        /// Latitude's property
        /// </summary>
        public double Latitude {  get => latitude; protected set => latitude = value; }
        protected double longitude;

        /// <summary>
        /// Longitude's property
        /// </summary>
        public double Longitude { get => longitude; protected set => longitude = value; }
        protected string address;

        /// <summary>
        /// Address's property
        /// </summary>
        public string Address 
        { 
            get => address; 
            protected set
            {
                if (value != null)
                    address = value;
                else //if the address is invalid
                {
                    address = " ";
                     throw new ErrorException ("ERROR address");
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
            Longitude= r.NextDouble() * (35.5 - 34.3) + 34.3; //random location in Israel
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
           if(code.Equals((BusStop)obj).code)&& address.Equals((BusStop)obj).address&& Latitude.Equals((BusStop)obj).Latitude)&& Longitude.Equals((BusStop)obj).Longitude))
                return true;
            return false;
        }
    }

    /// <summary>
    /// the class describes a line bus stop
    /// </summary>
    class LineBusStop
    {
        BusStop BS;
        protected double distance;
        public double Distance { get => distance; protected set => distance = value; }
        TimeSpan timeFromLastBS;
        
        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="MyBusStop">the bus stop</param>
        LineBusStop(BusStop MyBusStop)
        {
            BS.Code=MyBusStop.Code;
            BS.Address=MyBusStop.Address;
            BS.Latitude=MyBusStop.Latitude;
            BS.Longitude=MyBusStop.Longitude;

            Random r=new Random(DateTime.Now.Millisecond);
            distance= r.NextDouble() * (100000-500) + 500;
            timeFromLastBS.Hours=(distance/1300)/60
            timeFromLastBS.Minutes +=(distance/1300)%60;
        }

        override public Tostring()
        {
            return BS.Code.ToString();
        }

        public override bool Equals(object obj)
        {
            if (distance.Equals(((LineBusStop)obj).distance) && timeFromLastBS.Equals(((LineBusStop)obj).timeFromLastBS) && BS.Equals(((LineBusStop)obj).BS))
                return true;
            return false;
        }


    }

   enum Area {General,North,South,Center,Jerusalem} ;
   

   class LineBus
   {
        Area travelArea;
        public Area TravelArea { get => TravelArea; private set => TravelArea = value; }

        List<LineBusStop>route;
        internal List<LineBusStop> Route
        { 
            get => Route;
            set
            {
                foreach (LineBusStop lbs in value)
                    Route.Add(lbs);
            }
        }

        int LineNum;
        public int LineNum 
        { 
            get => LineNum; 
            protected set 
            {
               if(value >0)
                LineNum = value; 
               else
                 throw new ErrorException ("ERROR LineNum");
            }
        }

       
       

        private LineBusStop firstStop;
        internal LineBusStop FirstStop { get => firstStop; private set => firstStop =new LineBusStop(value); }

        private LineBusStop lastStop;
        internal LineBusStop LastStop { get => lastStop; private set => lastStop = new LineBusStop(value); }

        LineBus(int numBus,List <LineBusStop> myStations,Area a)
        {
            LineNum=numBus;
            Route = myStations;
            firstStop = route[0];
            lastStop = route.Last();
        }

        public override string ToString()
        {
            return ("Line number:" + LineNum + " Area: " + TravelArea.ToString() + " Route:" + route.ToString());
        }

        public LineBusStop this [int i]
        {
            get 
            {
                if (i < 0 || i >= route.Count)
                {
                    throw ErrorException("Error index")
                }
                return route[i];
            }
            set
            {
                if(i<0||i>=route.Count)
                {
                    throw ErrorException("Error index")
                }
                route[i] = value;
            }
        }

        public void Add(int i, LineBusStop NewStop)
        {
            route.insert(i, new LineBusStop(NewStop));
        }

        public void delete(int i)
        {
            rouet.removeAt(i);
        }

        public bool search(LineBusStop LBS)
        {
            if (route.IndexOf(LBS) != -1)
                return true;
            return false;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            }
        }
    }

}





