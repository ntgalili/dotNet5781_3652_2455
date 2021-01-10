using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DLAPI;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL    //internal
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Station
        public IEnumerable<DO.Station> GetAllStations()
        {
            return from station in DataSource.ListStations
                   select station.Clone();
        }
        public DO.Station GetStation(int num)
        {
            DO.Station toGet = DataSource.ListStations.Find(s => s.Code == num);
            try { Thread.Sleep(2000); } catch (ThreadInterruptedException) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadStationCodeException(num, "Not found");
        }
        public void AddStation(DO.Station station)
        {
            if (DataSource.ListStations.FirstOrDefault(s => s.Code == station.Code) != null)
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code");
            DataSource.ListStations.Add(station.Clone());
        }
        public void UpdateStation(DO.Station station)
        {
            DO.Station toUpDate = DataSource.ListStations.Find(s => s.Code == station.Code);
            if (toUpDate != null)
            {
                DataSource.ListStations.Remove(toUpDate);
                DataSource.ListStations.Add(station.Clone());
            }
            else
                throw new DO.BadStationCodeException(station.Code, "Not found");
        }
        public void DeleteStation(int num)
        {
            DO.Station toDel;
            toDel = DataSource.ListStations.FirstOrDefault(s => s.Code == num);
            if (toDel == null)
                throw new DO.BadStationCodeException(num, "Not found");
            if (toDel.Active==false)
                throw new DO.BadStationCodeException(num, "the station is already canceled");
            toDel.Active = false;
        }
        #endregion











        #region Line
        public IEnumerable<DO.Line> GetAllLines()
        {
            return from Line in DataSource.ListLines
                   select Line.Clone();
        }
        public DO.Line GetLine(int num)
        {
            DO.Line toGet = DataSource.ListLines.Find(l => l.Code == num);
            try { Thread.Sleep(2000); } catch (ThreadInterruptedException) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new /*DO.BadLineCode*/Exception(/*num, "Not found"*/);
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.ListLines.FirstOrDefault(l => l.Code == line.Code) != null)
               // throw new DO.BadLineCodeException(line.Code, "Duplicate Line Code");
            DataSource.ListLines.Add(line.Clone());
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line toUpDate = DataSource.ListLines.Find(l => l.Code == line.Code);
            if (toUpDate != null)
            {
                DataSource.ListLines.Remove(toUpDate);
                DataSource.ListLines.Add(line.Clone());
            }
            else;
                //throw new DO.BadLineCodeException(line.Code, "Not found");
        }
        public void DeleteLine(int num)
        {
            DO.Line toDel;
            toDel = DataSource.ListLines.FirstOrDefault(l => l.Code == num);
            if (toDel == null) ;
               // throw new DO.BadLineCodeException(num, "Not found");
        }

        #endregion






        #region LineStation
        public void AddLineStation(DO.LineStation ls)
        {

            DataSource.ListLineStations.Add(ls.Clone());
        }

        public void UpdateLineStation(DO.LineStation ls)
        {
            DO.LineStation toUpDate = DataSource.ListLineStations.Find(s => s.StationCode == ls.StationCode);
            if (toUpDate != null)
            {
                DataSource.ListLineStations.Remove(toUpDate);
                DataSource.ListLineStations.Add(ls.Clone());
            }
            else
                throw new DO.BadStationCodeException(ls.StationCode, "Not found");
        }
        public void DeleteLineStation(int codeLine, int codeStation)
        {
            DO.LineStation toDel;
            toDel = DataSource.ListLineStations.FirstOrDefault(s => s.StationCode == codeStation && s.LineNum == codeLine);
            if (toDel == null)
                throw new DO.BadStationCodeException(codeStation, "Not found in " + codeLine);
            DataSource.ListLineStations.Remove(toDel);
        }


        public DO.LineStation GetLineStation(int codeLine, int codeStation)
        {
            DO.LineStation toGet = DataSource.ListLineStations.Find(s =>( s.StationCode == codeStation && s.LineNum== codeLine));
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException ex) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadStationCodeException(codeStation, "Not found in "+ codeLine);
        }
        #endregion
    }
}






