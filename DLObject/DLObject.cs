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
            try { Thread.Sleep(2000); } catch (ThreadInterruptedException ex) { }
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

    }
}






