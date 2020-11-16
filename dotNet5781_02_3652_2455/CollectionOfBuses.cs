using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_3652_2455
{
    class CollectionOfBuses : IEnumerable
    {
        private List<LineBus> ListOfBuses;


        public void AddLine(LineBus ToAdd)
        {
            int countBuses = count(ToAdd.LineNum);
            if (countBuses >= 2)
                throw new AddErrorException("can not add " + ToAdd.LineNum + " line, there are already two \n");
            if (countBuses == 0)
                ListOfBuses.Add(ToAdd);
            if(countBuses==1)
            {
                foreach(LineBus lbs in ListOfBuses)
                {
                    if(lbs.LineNum==ToAdd.LineNum)
                    {
                        if (!(lbs.FirstStop.BS.Equals(ToAdd.LastStop.BS)) || !(lbs.LastStop.BS.Equals(ToAdd.FirstStop.BS)))
                            throw new AddErrorException("The line:" + ToAdd.LineNum + " is not opposite to the existing line");
                        else
                            ListOfBuses.Add(ToAdd);
                        break;
                    }
                }
            }
            return;
        }

        public void RemoveLine(LineBus Todel)
        {
            bool flag = true;
            foreach (LineBus lbs in ListOfBuses)
            {
                if (lbs.Equals(Todel))
                {
                    ListOfBuses.Remove(lbs);
                    flag = false;
                }
            }
            if(flag)
            {
                throw new RemoveErrorException("The line was not found");
            }
            return;
        }

        public List<LineBus> WhoIsTravling (int myCode)
        {
            List<LineBus> weTraveling = new List<LineBus>();
            foreach(LineBus lbs in ListOfBuses)
            {
                if (lbs.check(myCode))
                    weTraveling.Add(lbs);
            }
            if (weTraveling.Count == 0)
                throw new FindErrorException("no bus passes through this bus stop");
            return weTraveling;
        }
        public List<LineBus> sort ()
        {
            ListOfBuses.Sort();
            return ListOfBuses;
        }
        public LineBus this[int index]
        {
            get
            {
                foreach(LineBus lb in ListOfBuses)
                {
                    if (lb.LineNum == index)
                        return lb;
                }
                throw new FindErrorException("the line" + index + "was not found"); 
            }
        }

        public int count(int num)
        {
            int countBuses = 0;
            foreach(LineBus lbs in ListOfBuses)
            {
                if (lbs.LineNum == num)
                    countBuses++;
            }
            return countBuses;
        }
    }
}
