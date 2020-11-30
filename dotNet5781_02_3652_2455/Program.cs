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
    public class BusStop
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
            return ("Bus Station Code: " + Code + "    " + Latitude + "°N:   " + Longitude + "°E:   ");
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
    public class LineBusStop
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

        private static Random r = new Random();


        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="MyBusStop">the bus stop</param>
        public LineBusStop(int mycode,string myaddress=" ")
        {
            bs = new BusStop(mycode, myaddress);

        
            distance = r.NextDouble() * (100000 - 500) + 500; //Random distance
            TimeFromLastBS = new TimeSpan(((int)(distance / 1300) / 60), ((int)(distance / 1300) % 60), 0);//Time between stations as a function of distance
        }

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="MyBusStop">the bus stop</param>
        public LineBusStop (BusStop mybs)
        {
            bs = mybs;
            
            distance = r.NextDouble() * (100000 - 500) + 500; //Random distance
            TimeFromLastBS = new TimeSpan(((int)(distance / 1300) / 60), ((int)(distance / 1300) % 60), 0);//Time between stations as a function of distance
        }

        /// <summary>
        /// representation of the class by a string
        /// </summary>
        /// <returns>string of the code of the bus stop</returns>
        override public string ToString()
        {
            return (bs.ToString()+ TimeFromLastBS.ToString());
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
    public enum Area { General, North, South, Center, Jerusalem };

   
    /// <summary>
    /// class for setting up a bus line
    /// </summary>
    public class LineBus : IComparable
    {

        Area travelArea;
        /// <summary>
        /// travelArea property
        /// </summary>
        public Area TravelArea { get => travelArea; private set => travelArea = value; }

        /// <summary>
        /// The route of the line
        /// </summary>
        List<LineBusStop> route;
        /// <summary>
        /// route property
        /// </summary>
        public List<LineBusStop> Route
        {
            get => route;
            set
            {
                //             foreach (LineBusStop lbs in value)///Gets a collection of stations and adds you to the route
                //                  route.Add(lbs);
                route = value;
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
        public LineBus(int numBus, List<LineBusStop> myStations, Area a)
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
            string str = "Line number:" + LineNum + " Area: " + TravelArea.ToString() + " Route: ";
            foreach(LineBusStop bs in route)
            {
                str+= bs.ToString()+" ";
            }
            return (str);
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
        public void Add(int i,BusStop NewStop)
        {
            route.Insert(i,new LineBusStop(NewStop));
        }

        /// <summary>
        /// delete a bus stop from the route
        /// </summary>
        /// <param name="i">the code of the line bus stop to delete</param>
        public void delete(int code)
        {
            if (route.Count == 2)
                throw new RemoveErrorException("can not delete ,the bus have only two bus stops");
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


        /// <summary>
        /// Find the traveling time between 2 bus stops
        /// </summary>
        /// <param name="lbs1">1 bus stop</param>
        /// <param name="lbs2">2 bus stop</param>
        /// <returns>traveling time between 2 bus stops</returns>
        public TimeSpan findTime(LineBusStop lbs1, LineBusStop lbs2)
        {
            TimeSpan timeBetween = new TimeSpan();
            LineBusStop first;
            bool flag = true;
            foreach (LineBusStop lbs in route)//go over the route
            {
                if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)) && flag)//find the first bus stop
                {
                    first = lbs;
                    flag = false;
                }
                else//When The first bus stop is found start to sum the time
                {
                    if (!flag)
                    {
                        timeBetween = timeBetween + lbs.TimeFromLastBS;
                        if ((lbs.BS.Equals(lbs1.BS) || lbs.BS.Equals(lbs2.BS)))//Continue until the last bus stop is found
                            break;
                    }
                }
            }
            return timeBetween;
        }


        /// <summary>
        /// find the sub route between 2 bus stops
        /// </summary>
        /// <param name="code1">code of bus stop 1</param>
        /// <param name="code2">code of bus stop 2</param>
        /// <returns> the sub route</returns>
        public LineBus SubRoute(int code1, int code2)
        {
            List<LineBusStop> sub=new List<LineBusStop>();
            bool flag = true;
            foreach (LineBusStop lbs in route)//go over the route
            {
                if ((lbs.BS.Code==code1) || (lbs.BS.Code == code2) && flag)//find the first bus stop
                {
                    flag = false;
                    sub.Add(lbs);
                }
                else//Once the first bus stop was found, start picking up the bus stops
                {
                    if (!flag)
                    {
                        sub.Add(lbs);//Collect the station
                        if ((lbs.BS.Code == code1) || (lbs.BS.Code == code2))//Continue until you reach the last bus stop
                            break;
                    }
                }
            }
            return new LineBus(LineNum,sub,travelArea);//create a line with the sub bus stop
        }


        /// <summary>
        /// Comparing the lines by total travel time
        /// </summary>
        /// <param name="obj">The line for comparison</param>
        /// <returns>If the parameters are equal returns 0, or 1 \ -1 if one is greater than the other</returns>
        public int CompareTo(object obj)
        {
            TimeSpan ObjTime= ((LineBus)obj).findTime(((LineBus)obj).FirstStop, ((LineBus)obj).LastStop);//Travel time of the other line
            TimeSpan MyTime= findTime(FirstStop, LastStop);//Travel time of the one line
            return (MyTime.CompareTo(ObjTime));//Returns the comparison between travel times
        }

        /// <summary>
        /// Check if the lines are the same
        /// </summary>
        /// <param name="obj">The line for comparison</param>
        /// <returns>return if the lines are the same</returns>
        public override bool Equals(object obj)
        {
            return ((((LineBus)obj).LineNum.Equals(LineNum))&& (((LineBus)obj).FirstStop.Equals(FirstStop)) && (((LineBus)obj).LastStop.Equals(LastStop)));//Refund if the line number is the same, and the start and end stations
        }
    }


    class Program
    {
        /// <summary>
        /// Check if a bus stop is on the list
        /// </summary>
        /// <param name="listOfBs">List of bus stops</param>
        /// <param name="code">bus stop's code</param>
        /// <returns>true if the bus stop is in the list and false if not</returns>
        public static bool search(List<BusStop> listOfBs,int code)
        {
            foreach(BusStop bs in listOfBs)//go over the list 
            {
                if (bs.Code == code)//if the bus stop is found
                    return true;
            }
            return false;//if the bus stop is not found
        }

        /// <summary>
        /// find how many bus stops that have less than 2 lines traveling through them
        /// </summary>
        /// <param name="myBusStops">list of bus stops</param>
        /// <param name="myCollection">collection of buses</param>
        /// <returns>count of bus stops that have less than 2 lines traveling through them</returns>
        public static int counter (List<BusStop> myBusStops,CollectionOfBuses myCollection)
        {
            int count = 0;
            foreach(BusStop bs in myBusStops)//go over the bus stops
            {
                if ((myCollection.WhoIsTravling(bs.Code)).countOfCollection() >= 2)//check how many buses traveling through the bus stop
                    count++;
            }
            return count;
        }


        /// <summary>
        /// add a line to a collection of buses
        /// </summary>
        /// <param name="myBuses">the collection</param>
        /// <param name="myBusStops">list of bus stops</param>
        public static void AddLine(CollectionOfBuses myBuses,List<BusStop> myBusStops)
        {
            string Ans;
            bool flag;
            int num1, num2;
            Area a = new Area();
            List<LineBusStop> myroute = new List<LineBusStop>();
            Console.WriteLine("enter a line number");
            Ans = Console.ReadLine();
            flag = int.TryParse(Ans, out num1);
            if (!flag)//if the number is invalid
            {
                throw new AddErrorException("Error number");
            }
            else
            {
                Console.WriteLine("enter the codes of the bus stops, you need to enter at least 2 bus stops,at the end press 0");
                Ans = Console.ReadLine();
                flag = int.TryParse(Ans, out num2);
                while (num2 != 0 || myroute.Count() < 2)//Continue until 0 and until 2 stops have been entered
                { 
                    if (!search(myBusStops, num2) || !flag)//if the bus stop is not on the list
                        throw new AddErrorException("The bus stop is not on the list");
                    foreach(BusStop bs in myBusStops)//go over the bus stops and find the bus stop
                    {
                        if(num2==bs.Code)
                            myroute.Add(new LineBusStop(num2));//add the  bus stop to the line's route
                    }
                     Console.WriteLine("The next bus stop");
                     Ans = Console.ReadLine();
                    flag = int.TryParse(Ans, out num2);
                }

                Console.WriteLine("enter the area of the bus: General, North, South, Center, Jerusalem");
                Ans = Console.ReadLine();
                flag = Area.TryParse(Ans, out a);
                if (!flag)
                    a = 0;

                myBuses.AddLine(new LineBus(num1, myroute, a));//add the bus stop to the route
            }
        }
        /// <summary>
        /// add bus stop to a bus
        /// </summary>
        /// <param name="myCollection">collection of buses</param>
        /// <param name="bs">the bus stop</param>
        static public void AddStopToBus (CollectionOfBuses myCollection, BusStop bs)
        {
            string Ans;
            bool flag;
            int numofbus,i;
            Console.WriteLine("choose which line to add it to");
            Ans = Console.ReadLine();
            flag = int.TryParse(Ans, out numofbus);
            if (numofbus != 0 && flag)//if the number is invalid
            {
                foreach (LineBus lb in myCollection)//find the bus in the collection
                {
                    if (lb.LineNum == numofbus)
                    {
                        Console.WriteLine("enter index to add the bus stop");
                        Ans = Console.ReadLine();
                        flag = int.TryParse(Ans, out i);
                        lb.Add(i, bs);//and the bus stop to the line in  i index
                        return;
                    }
                }
            }
            throw new AddErrorException("Error line number");//if the line is not in the collection
        }


        /// <summary>
        /// add bus stop to the list
        /// </summary>
        /// <param name="myBusStop">list of bus stops</param>
        static public void AddBusStop(List<BusStop> myBusStop)
        {
            string Ans;
            bool flag;
            int num1;
            Console.WriteLine("enter the code: 000000");
            Ans = Console.ReadLine();
            flag = int.TryParse(Ans, out num1);
            if (!flag)//if the code is invalid
                throw new AddErrorException("Error code");
            else
            {
                Console.WriteLine("enter the address");
                Ans = Console.ReadLine();
                if (search(myBusStop, num1))//if the bus stop is already in the list
                    throw new AddErrorException("There is already a bus stop with the same code");
                myBusStop.Add(new BusStop(num1, Ans));//add the bus stop to the list
            }
        }

        /// <summary>
        /// The possible actions
        /// </summary>
        enum Choice { Exit, AddLine, AddBusStopToLine , DeleteLine, DeleteStopBus, WhoTraveling, BestTraveling , PrintAll, PrintBusStops}


        static void Main(string[] args)
        {
            Choice c;
            string Ans;
            int num, num2,count = 0; ;
            bool flag;
            CollectionOfBuses myCollection = new CollectionOfBuses();
            List<BusStop> listOfBustops = new List<BusStop>();


            Console.WriteLine("Enter 40 bus stops:");
            //enter 40 bus stops to the list of bus stop
            for(int i=0;i<40;i++)
            {
                try
                {
                    AddBusStop(listOfBustops);//add bus stop by calling the AddBusStop function
                }
                catch(Exception ex)//catch  exception and print it
                {
                    Console.WriteLine(ex);
                    i--;
                } 
            }

            Console.WriteLine("Enter 10 Line buses");
            for(int i=0;i<10;i++)//add 10 line to the collectoin
            {
                try
                {
                    AddLine(myCollection, listOfBustops); //add line by calling to the AddLine function
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);//catch  exception and print it
                    i--;
                }
            }
            
            foreach(BusStop bs in listOfBustops)//go over the list of the buses and Check whether there are lines at all bus stops
            {
                try
                {
                    if ((myCollection.WhoIsTravling(bs.Code)).countOfCollection() >= 2)//Count at some bus stops traveling 2 lines
                        count++;
                }
                catch(Exception ex)//When there is no line traveling at the station catch the exception 
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("enter 1 to add it to line or enter another number to delete the bus stop");
                    Ans = Console.ReadLine();
                    try
                    {
                        num = int.Parse(Ans);
                        if (num == 1)
                            AddStopToBus(myCollection, bs);//and the bus stop to a line
                        else//if the user want to remove the bus stop
                            throw new AddErrorException();

                    }
                    catch (Exception)
                    {
                        listOfBustops.Remove(bs);//remove the bus stop
                        Console.WriteLine("the bus stop has been deleted");
                    }
                }
            }

            while ((10-count) != 0) //Make sure there are at least 10 bus stops that pass through 2 bus lines
            { 
                Console.WriteLine("you need to enter more"+(10-count)+"different bus stop to the lines routes" );
                for(int i=0;i<(10-count);i++)//Add the stations to the routes
                {
                    Console.WriteLine("enter the code bus stop to add ");
                    Ans = Console.ReadLine();
                    try
                    {
                        num = int.Parse(Ans);
                        foreach (BusStop bs in listOfBustops)//go over the bu stops and find the bus stop to add
                        {
                            if (bs.Code == num)
                                AddStopToBus(myCollection, bs);//add the bus stop to a line
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Error, try again");
                    }
                }
                count = counter(listOfBustops, myCollection);//Check how many bus stops there are that carry at least 2 buses
            }
            do
            {
                Console.WriteLine("enter your choice: \n 0 to Exit \n 1 to AddLine \n 2 to AddBusStopToLine \n"
                    + " 3 to DeleteLine\n 4 to DeleteStopBus\n 5 to  WhoTraveling \n 6 to BestTraveling \n 7 to PrintAll\n 8 to PrintBusStops \n");
                Ans = Console.ReadLine();
                flag = Choice.TryParse(Ans, out c);
                switch (c)
                {
                    case Choice.Exit://to exit
                        {
                            break;
                        }
                    case Choice.AddLine://add line to the collection
                        {
                            AddLine(myCollection, listOfBustops);
                            break;
                        }
                    case Choice.AddBusStopToLine://add bus stop to a line
                        {
                            Console.WriteLine("enter the code of the bus stop");
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans,out num);
                            if(!flag)//error code
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            try
                            {
                                foreach (BusStop bs in listOfBustops)//find the bus stop
                                {
                                    if (bs.Code == num)
                                    {
                                        AddStopToBus(myCollection, bs);//add the bus stop to a line
                                        flag = false;
                                    }  
                                }
                                if (flag)
                                    throw new AddErrorException("the bus stop is not found");
                            }
                            catch(Exception ex)//catch Exception and print it
                            {
                                Console.WriteLine(ex);
                            }
                                break;
                        }
                    case Choice.DeleteLine://delete line
                        {
                            Console.WriteLine("enter line to delete");
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans, out num);
                            if (!flag)//error number
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            try
                            {
                                foreach (LineBus lb in myCollection)//find the bus
                                {
                                    if (lb.LineNum == num)
                                        myCollection.RemoveLine(lb);//remove the bus
                                }
                            }
                            catch (Exception)//catch Exception
                            {
                                Console.WriteLine();
                            }
                            foreach (BusStop bs in listOfBustops)//go over the bus stop and Check if there is a bus stop where there are no buses 
                            {
                                try
                                {
                                    (myCollection.WhoIsTravling(bs.Code)).countOfCollection();
                                }
                                catch (Exception ex)//When there are no buses passing through the station an exception is thrown
                                {
                                    Console.WriteLine(ex);
                                    Console.WriteLine("enter 1 to add it to line or enter another number to delete the bus stop");
                                    Ans = Console.ReadLine();
                                    try
                                    {
                                        num = int.Parse(Ans);
                                        if (num == 1)
                                            AddStopToBus(myCollection, bs);//add the bus stop to a line
                                        else
                                            throw new AddErrorException();

                                    }
                                    catch (Exception)
                                    {
                                        listOfBustops.Remove(bs);//delete the bus stop
                                        Console.WriteLine("the bus stop has been deleted");
                                    }
                                }
                            }
                                break;
                        }
                    case Choice.DeleteStopBus://delete bus stop 
                        {
                            Console.WriteLine("enter line number");
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans, out num);
                            if (!flag)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            try
                            {
                                foreach (LineBus lb in myCollection)//go over the collection
                                {
                                    if (lb.LineNum == num)//when the line is found
                                    {
                                        Console.WriteLine("enter code of bus stop");
                                        Ans = Console.ReadLine();
                                        flag = int.TryParse(Ans, out num2);
                                        try
                                        {
                                            lb.delete(num2);//delte the bus stop
                                            myCollection.WhoIsTravling(num2).countOfCollection();//Check if there are any buses left at the bus stop

                                        }
                                        catch(Exception ex)//When there were no buses left at the bus stop delete it
                                        {
                                            foreach (BusStop bs in listOfBustops)
                                                if (bs.Code == num2)
                                                    listOfBustops.Remove(bs);
                                            Console.WriteLine(ex);
                                        }
                                    } 
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        }
                    case Choice.WhoTraveling://Find the buses that travel at the bus stop
                        {
                            Console.WriteLine("enter code number");
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans, out num);
                            if (!flag)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            try
                            {
                                CollectionOfBuses MyLine = myCollection.WhoIsTravling(num);//Find the buses that travel at the bus stop
                                foreach (LineBus lb in MyLine)//print the lines that traveling on the bus stop
                                    Console.WriteLine(lb);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                                break;
                        }
                    case Choice.BestTraveling://Find travel between 2 bus stops, by travel time
                        {
                            Console.WriteLine("enter two codes of bus stops (Enter between them)");
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans, out num);
                            if (!flag)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            Ans = Console.ReadLine();
                            flag = int.TryParse(Ans, out num2);
                            if (!flag)
                            {
                                Console.WriteLine("Error");
                                break;
                            }
                            try
                            {
                                CollectionOfBuses myc = new CollectionOfBuses();
                                foreach (LineBus lb in myCollection)//Go over the collection
                                {
                                    LineBus subbus = lb.SubRoute(num,num2);//Find the subway between the 2 stations
                                    if (subbus.Route.Count != 0)
                                         myc.AddLine(subbus);//When the bus is not traveling at these bus stops
                                }
                                myc.sort();//Sort the buses by travel times between stations
                                myc.Print();//print the buses
                            }
                            catch(Exception)
                            {
                                Console.WriteLine();
                            }
                                
                            break;
                        }
                    case Choice.PrintAll://print all of the buses
                        {
                            myCollection.Print();
                            break;
                        }
                    case Choice.PrintBusStops://print all the bus stops and the line that traveling  through them
                        {
                            try
                            {
                                foreach (BusStop bs in listOfBustops)//go over the bus stops
                                {
                                    Console.WriteLine(bs + ": ");
                                    (myCollection.WhoIsTravling(bs.Code)).Print();//find the lines that traveling on this bus stops
                                    Console.WriteLine();
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("error choice");
                        break;
                }
            }
            while (c != 0);
            Console.ReadKey();
        }
        
    }
}





/*
 * 
 * Enter 40 bus stops:
enter the code: 000000
1
enter the address
1
enter the code: 000000
2
enter the address
2
enter the code: 000000
3
enter the address
3
enter the code: 000000
4
enter the address
4
enter the code: 000000
5
enter the address
5
enter the code: 000000
6
enter the address
6
enter the code: 000000
7
enter the address
7
enter the code: 000000
8
enter the address
8
enter the code: 000000
9
enter the address
9
enter the code: 000000
10
enter the address
10
Enter 10 Line buses
enter a line number
111
enter the codes of the bus stops, you need to enter at least 2 bus stops,at the end press 0
1
The next bus stop
2
The next bus stop
3
The next bus stop
4
The next bus stop
5
The next bus stop
6
The next bus stop
7
The next bus stop
8
The next bus stop
9
The next bus stop
10
The next bus stop
0
enter the area of the bus: General, North, South, Center, Jerusalem
1
enter a line number
222
enter the codes of the bus stops, you need to enter at least 2 bus stops,at the end press 0
2
The next bus stop
4
The next bus stop
6
The next bus stop
8
The next bus stop
10
The next bus stop
0
enter the area of the bus: General, North, South, Center, Jerusalem
2
enter a line number
333
enter the codes of the bus stops, you need to enter at least 2 bus stops,at the end press 0
3
The next bus stop
6
The next bus stop
9
The next bus stop
2
The next bus stop
5
The next bus stop
8
The next bus stop
1
The next bus stop
4
The next bus stop
7
The next bus stop
10
The next bus stop
0
enter the area of the bus: General, North, South, Center, Jerusalem
3
enter a line number
444
enter the codes of the bus stops, you need to enter at least 2 bus stops,at the end press 0
10
The next bus stop
9
The next bus stop
8
The next bus stop
7
The next bus stop
6
The next bus stop
5
The next bus stop
4
The next bus stop
3
The next bus stop
2
The next bus stop
1
The next bus stop
0
enter the area of the bus: General, North, South, Center, Jerusalem
4
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

7
number of bus:111
number of bus:222
number of bus:333
number of bus:444
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

8
Bus Station Code:1,31.3943294357482°N34.578767679389°E:
number of bus:111
number of bus:333
number of bus:444

Bus Station Code:2,32.4201529719029°N34.8299576473096°E:
number of bus:111
number of bus:222
number of bus:333
number of bus:444

Bus Station Code:3,32.9207461224965°N34.8628419098271°E:
number of bus:111
number of bus:333
number of bus:444

Bus Station Code:4,33.1479890053384°N34.5502472770634°E:
number of bus:111
number of bus:222
number of bus:333
number of bus:444

Bus Station Code:5,31.9464107827034°N35.3981449359554°E:
number of bus:111
number of bus:333
number of bus:444

Bus Station Code:6,31.3580303151431°N34.8804138339033°E:
number of bus:111
number of bus:222
number of bus:333
number of bus:444

Bus Station Code:7,32.3666311016617°N35.1590332391015°E:
number of bus:111
number of bus:333
number of bus:444

Bus Station Code:8,31.6523105751967°N34.7048887319886°E:
number of bus:111
number of bus:222
number of bus:333
number of bus:444

Bus Station Code:9,31.1937574617536°N35.1612151691975°E:
number of bus:111
number of bus:333
number of bus:444

Bus Station Code:10,32.3323656549362°N34.3451108077751°E:
number of bus:111
number of bus:222
number of bus:333
number of bus:444

enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

6
enter two codes of bus stops (Enter between them)
3
666

enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

6
enter two codes of bus stops (Enter between them)
3
6
number of bus:333
number of bus:222
number of bus:111
number of bus:444
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

5
enter code number
3
Line number:111 Area: North Route: 1 2 3 4 5 6 7 8 9 10
Line number:333 Area: Center Route: 3 6 9 2 5 8 1 4 7 10
Line number:444 Area: Jerusalem Route: 10 9 8 7 6 5 4 3 2 1
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

3
enter line to delete
333

enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

7
number of bus:111
number of bus:222
number of bus:444
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

6
enter two codes of bus stops (Enter between them)
3
8
number of bus:222
number of bus:111
number of bus:444
enter your choice:
 0 to Exit
 1 to AddLine
 2 to AddBusStopToLine
 3 to DeleteLine
 4 to DeleteStopBus
 5 to  WhoTraveling
 6 to BestTraveling
 7 to PrintAll
 8 to PrintBusStops

0

*/

