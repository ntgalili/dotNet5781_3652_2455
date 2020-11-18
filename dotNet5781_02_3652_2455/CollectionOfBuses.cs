using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_3652_2455
{

    /// <summary>
    /// A class that defines a collection of bus lines
    /// </summary>
    internal class CollectionOfBuses : IEnumerable
    {
        private List<LineBus> ListOfBuses;

        /// <summary>
        /// the method adds a line to the collection
        /// </summary>
        /// <param name="ToAdd">the line to add</param>
        public void AddLine(LineBus ToAdd)
        {
            int countBuses = count(ToAdd.LineNum);//Find the number of lines with the same number that are already in the collection 
            if (countBuses >= 2)//if there are already 2
                throw new AddErrorException("can not add " + ToAdd.LineNum + " line, there are already two \n");//throw exeption "canot add"
            if (countBuses == 0)//When lines with the same number do not appear
                ListOfBuses.Add(ToAdd);//add the line to the list
            if (countBuses == 1)//When there is one line with the same number
            {
                foreach (LineBus lbs in ListOfBuses)//find the line with the same number
                {
                    if (lbs.LineNum == ToAdd.LineNum)
                    {
                        if (!(lbs.FirstStop.BS.Equals(ToAdd.LastStop.BS)) || !(lbs.LastStop.BS.Equals(ToAdd.FirstStop.BS)))//When the lines do not travel on opposite routes
                            throw new AddErrorException("The line:" + ToAdd.LineNum + " is not opposite to the existing line");
                        else
                            ListOfBuses.Add(ToAdd);//if the lines are travel on opposite routes add the line to the list
                        break;
                    }
                }
            }
            return;
        }

        /// <summary>
        /// Delete a line from the collection
        /// </summary>
        /// <param name="Todel">the line to delete</param>
        public void RemoveLine(LineBus Todel)
        {
            bool flag = true;
            foreach (LineBus lbs in ListOfBuses)//find the line in the list
            {
                if (lbs.Equals(Todel))//When the line is found
                {
                    ListOfBuses.Remove(lbs);//Delete The  line from the list
                    flag = false;
                }
            }
            if (flag)//if the line is not found
            {
                throw new RemoveErrorException("The line was not found");
            }
            return;
        }


        /// <summary>
        /// The method checks which lines pass through the bus stop
        /// </summary>
        /// <param name="myCode">the bos stop's code</param>
        /// <returns>list of lines that pass through the bus stop </returns>
        public List<LineBus> WhoIsTravling(int myCode)
        {
            List<LineBus> weTraveling = new List<LineBus>();
            foreach (LineBus lbs in ListOfBuses)//go over the List Of Buses
            {
                if (lbs.check(myCode))//if the line passes through the bus stop
                    weTraveling.Add(lbs);//Add the line to the list of lines traveling through the station
            }
            if (weTraveling.Count == 0)//When there are no lines passing through the station
                throw new FindErrorException("no bus passes through this bus stop");
            return weTraveling;
        }


        /// <summary>
        /// Sort the collection by travel time
        /// </summary>
        /// <returns>the sort list</returns>
        public List<LineBus> sort()
        {
            ListOfBuses.Sort();
            return ListOfBuses;
        }

        /// <summary>
        /// operator indexer
        /// </summary>
        /// <param name="index">line number</param>
        /// <returns>the line</returns>
        public LineBus this[int index]
        {
            get
            {
                foreach (LineBus lb in ListOfBuses)//go over the list
                {
                    if (lb.LineNum == index)//if the line is found
                        return lb;
                }
                throw new FindErrorException("the line" + index + "was not found");//if the line is not found
            }
        }

        /// <summary>
        /// Check how many times a certain number of line appears in the collection
        /// </summary>
        /// <param name="num">the line number</param>
        /// <returns>The number of times the line appears</returns>
        public int count(int num)
        {
            int countBuses = 0;
            foreach (LineBus lbs in ListOfBuses)//go over the list
            {
                if (lbs.LineNum == num)//if the line is found
                    countBuses++;
            }
            return countBuses;
        }

        /// <summary>
        /// Implementation of a virtual function to enable counting of the collection
        /// </summary>
        /// <returns>Organs of the collection</returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < ListOfBuses.Count; i++)
                yield return ListOfBuses[i];
        }
    }
}