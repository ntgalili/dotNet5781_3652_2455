using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        public int LineNum { get; set; }
        public int StationCode { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }

        public void AddStation(DO.LineStation ls)
        {

            DataSource.ListLineStations.Add(ls.Clone());
        }

        public void UpdateStation(DO.LineStation ls)
        {
            DO.LineStation toUpDate = DataSource.ListLineStations.Find(s => s.StationCode == ls.StationCode);
            if (toUpDate != null)
            {
                DataSource.ListStations.Remove(toUpDate);
                DataSource.ListStations.Add(ls.Clone());
            }
            else
                throw new DO.BadStationCodeException(ls.StationCode, "Not found");
        }
        public void DeleteStation(int num)
        {
            DO.Station toDel;
            toDel = DataSource.ListLineStations.FirstOrDefault(s => s.StationCode == num);
            if (toDel == null)
                throw new DO.BadStationCodeException(num, "Not found");
            DataSource.ListLineStations.Remove(toDel);
        }


        public DO.LineStation GetStation(int num)
        {
            DO.Station toGet = DataSource.ListLineStations.Find(s => s.StationCode == num);
            try
            {
                Thread.Sleep(2000); 
            } 
            catch (ThreadInterruptedException ex) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadStationCodeException(num, "Not found");
        }
    }
}
