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
        int code; //the bus stop code
        /// <summary>
        /// code's property
        /// </summary>
        public int Code 
        { 
            get => code;
            private set 
            {
                if (value <= 999999 && value >= 1)
                    code = value;
                else //when the value invalid
                {
                    Console.WriteLine("ERROR code");
                    code = 0;
                }
                    
            } 
        }
        double latitude;

        /// <summary>
        /// Latitude's property
        /// </summary>
        public double Latitude {  get => latitude; private set => latitude = value; }
        double longitude;

        /// <summary>
        /// Longitude's property
        /// </summary>
        public double Longitude { get => longitude; private set => longitude = value; }
        string address;

        /// <summary>
        /// Address's property
        /// </summary>
        public string Address 
        { 
            get => address; 
            private set
            {
                if (value != null)
                    address = value;
                else //if the address is invalid
                {
                    Console.WriteLine("ERROR address");
                    address = " ";
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
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
