using System;
using System.Collections.Generic;
using System.Device.Location;
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
        public IEnumerable<DO.Station> GetAllActiveStations()
        {
            return from station in DataSource.ListStations
                   where station.Active == true
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
        public IEnumerable<DO.Line> GetAllActiveLines()
        {
            return from Line in DataSource.ListLines
                   where Line.Active == true
                   select Line.Clone();
        }
        public DO.Line GetLine(int num, int code)
        {
            DO.Line toGet = DataSource.ListLines.Find(l=> (l.LineNum == num && l.Code == code));
            try { Thread.Sleep(2000); } catch (ThreadInterruptedException) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadLineCodeException(num, "Not found");

        }
        public int AddLine(DO.Line line)
        {
            line.Code = DO.config.LineID++;
            DataSource.ListLines.Add(line.Clone());
            return line.Code;
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line toUpDate = DataSource.ListLines.Find(l => l.Code == line.Code);
            if (toUpDate != null)
            {
                DataSource.ListLines.Remove(toUpDate);
                DataSource.ListLines.Add(line.Clone());
            }
            else
                throw new DO.BadLineCodeException(line.Code, "Not found");
        }
        public void DeleteLine(int num, int code)
        {
            DO.Line toDel;
            toDel = DataSource.ListLines.FirstOrDefault(l => (l.LineNum == num && l.Code == code));
            if (toDel == null) 
                throw new DO.BadLineCodeException(num, "Not found");
            toDel.Active = false;
        }

        #endregion

        #region LineStation
        public void AddLineStation(DO.LineStation ls)
        {
            if (DataSource.ListLineStations.FirstOrDefault(s => s.StationCode == ls.StationCode && s.LineCode==ls.LineCode) != null)
                throw new DO.BadLineStationException(ls.StationCode,ls.LineCode, "Duplicate station Code");
            DataSource.ListLineStations.Add(ls.Clone());
        }
        public IEnumerable<DO.LineStation> GetAllLinesStation()
        {
            return from ls in DataSource.ListLineStations
                   select ls.Clone();
        }
        public IEnumerable<DO.LineStation>GetAllLinesStationByLine(int lineCode)
        {
            return from ls in DataSource.ListLineStations
                   where ls.LineCode== lineCode
                   orderby ls.LineStationIndex
                   select ls.Clone();
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
                throw new DO.BadLineStationException(ls.StationCode,ls.LineCode, "Not found");
        }
        public void DeleteLineStation(int lineCode, int codeStation)
        {
            DO.LineStation toDel;
            toDel = DataSource.ListLineStations.FirstOrDefault(s => s.StationCode == codeStation && s.LineCode == lineCode);
            if (toDel == null)
                throw new DO.BadLineStationException(codeStation, "Not found in " + lineCode);
            DataSource.ListLineStations.Remove(toDel);
        }

        public DO.LineStation GetLineStation(int lineCode, int codeStation)
        {
            DO.LineStation toGet = DataSource.ListLineStations.Find(s =>( s.StationCode == codeStation && s.LineCode== lineCode));
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException ex) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadLineStationException(codeStation, "Not found in "+ lineCode);
        }
        #endregion

        #region AdjacentStations
        public DO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2)
        {
            DO.AdjacentStetions toGet = DataSource.ListAdjStations.Find(adj => (adj.Station1 == numS1 && adj.Station2 == numS2));
            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException ex) { }
            if (toGet != null)
                return toGet.Clone();
            else
                throw new DO.BadAdjacentStetionsException(numS1,numS2, "Not found");
        }
        public void AddAdjacentStetions(DO.AdjacentStetions adj)
        {
            if (DataSource.ListAdjStations.FirstOrDefault(a => a.Station1 == adj.Station1&& a.Station2 == adj.Station2) != null)
                throw new DO.BadLineStationException(adj.Station1,adj.Station2, "Duplicate AdjacentStetions");
            DataSource.ListAdjStations.Add(adj.Clone());
        }
        public void UpdateAdjacentStetions(DO.AdjacentStetions adj)
        {
            DO.AdjacentStetions toUpDate = DataSource.ListAdjStations.Find(a => a.Station1 == adj.Station1 && a.Station2 == adj.Station2);
            if (toUpDate != null)
            {
                DataSource.ListAdjStations.Remove(toUpDate);
                DataSource.ListAdjStations.Add(adj.Clone());
            }
            else
                throw new DO.BadAdjacentStetionsException(adj.Station1,adj.Station2, "Not found");
        }
        public void DeleteAdjacentStetions(int numS2, int numS1)
        {
            DO.AdjacentStetions toDel;
            toDel = DataSource.ListAdjStations.FirstOrDefault(a => a.Station1 == numS1 && a.Station2 == numS2);
            if (toDel == null)
                throw new DO.BadLineStationException(numS1,numS2, "Not found");
            DataSource.ListAdjStations.Remove(toDel);
        }


        public IEnumerable<DO.AdjacentStetions> GetALLAdjStetionsbycode(int code)
        {
            return from item in DataSource.ListAdjStations
                   where (item.Station1 == code || item.Station2 == code)
                   select item; 
        }

        #endregion
    }
}






