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
        /// <summary>
        /// return all stations
        /// </summary>
        /// <returns>a collection of all stations</returns>
        public IEnumerable<DO.Station> GetAllStations()
        {
            return from station in DataSource.ListStations
                   orderby station.Code
                   select station.Clone();
        }
        /// <summary>
        /// return all active stations
        /// </summary>
        /// <returns>a collecion of all active stations</returns>
        public IEnumerable<DO.Station> GetAllActiveStations()
        {
            return from station in DataSource.ListStations
                   where station.Active == true
                   orderby station.Code
                   select station.Clone();
        }
        /// <summary>
        /// return DO station
        /// </summary>
        /// <param name="num">code of station to return </param>
        /// <returns>station that have this code</returns>
        public DO.Station GetStation(int num)
        {
            DO.Station toGet = DataSource.ListStations.Find(s => s.Code == num); //fine station thet havve this code
            //try { Thread.Sleep(1000); } catch (ThreadInterruptedException) { }
            if (toGet != null) //if the station found - cloning the station 
                return toGet.Clone();
            else
                throw new DO.BadStationCodeException(num, "Not found"); //if the station not found
        }
        /// <summary>
        /// add station to collection stations
        /// </summary>
        /// <param name="station">station to add</param>
        public void AddStation(DO.Station station)
        {
            if (DataSource.ListStations.FirstOrDefault(s => s.Code == station.Code) != null) //check if we have station with this code in collection of station
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code");
            DataSource.ListStations.Add(station.Clone()); //add this station of collection of stations
        }
        /// <summary>
        /// up date station
        /// </summary>
        /// <param name="station">station to up date</param>
        public void UpdateStation(DO.Station station)
        {
            DO.Station toUpDate = DataSource.ListStations.Find(s => s.Code == station.Code); //find station with this code in collection of stations
            if (toUpDate != null) //if the station found
            {
                DataSource.ListStations.Remove(toUpDate); //remove this station
                DataSource.ListStations.Add(station.Clone()); //add new station (up date) to collection of station
            }
            else //if the station are not found
                throw new DO.BadStationCodeException(station.Code, "Not found");
        }
        /// <summary>
        /// delete station
        /// </summary>
        /// <param name="num">code of station to delete</param>
        public void DeleteStation(int num)
        {
            DO.Station toDel;
            toDel = DataSource.ListStations.FirstOrDefault(s => s.Code == num); //find station with thus code
            if (toDel == null) //if station not found
                throw new DO.BadStationCodeException(num, "Not found");
            if (toDel.Active==false)//if this station is not active
                throw new DO.BadStationCodeException(num, "the station is already canceled");
            toDel.Active = false; 
        }
        #endregion

        #region Line
        /// <summary>
        /// return all lines
        /// </summary>
        /// <returns>a collection of all lines</returns>
        public IEnumerable<DO.Line> GetAllLines()
        {
            return from Line in DataSource.ListLines
                   select Line.Clone();
        }
        /// <summary>
        /// return all active lines
        /// </summary>
        /// <returns>a collection of all active lines</returns>
        public IEnumerable<DO.Line> GetAllActiveLines()
        {
            return from Line in DataSource.ListLines
                   where Line.Active == true //if this line is active
                   select Line.Clone();
        }
        /// <summary>
        /// return line
        /// </summary>
        /// <param name="num">num of line</param>
        /// <param name="code">runing code of line</param>
        /// <returns>a line that have this code and num line</returns>
        public DO.Line GetLine(int num, int code)
        {
            DO.Line toGet = DataSource.ListLines.Find(l=> (l.LineNum == num && l.Code == code)); //find this line
            //try { Thread.Sleep(2000); } catch (ThreadInterruptedException) { }
            if (toGet != null) //if the line is found
                return toGet.Clone();
            else //if the line is not found 
                throw new DO.BadLineCodeException(num, "Not found");

        }
        /// <summary>
        /// add line
        /// </summary>
        /// <param name="line">line to add</param>
        /// <returns>runing code of this line</returns>
        public int AddLine(DO.Line line)
        {
            line.Code = DO.config.LineID++;
            DataSource.ListLines.Add(line.Clone()); //add line to collection of all lines
            return line.Code;
        }
        /// <summary>
        /// up date line
        /// </summary>
        /// <param name="line">line to up date</param>
        public void UpdateLine(DO.Line line)
        {
            DO.Line toUpDate = DataSource.ListLines.Find(l => l.Code == line.Code);//find the line thet have this code line 
            if (toUpDate != null) //uf the line is found
            {
                DataSource.ListLines.Remove(toUpDate);//remove this line
                DataSource.ListLines.Add(line.Clone());//add the new line (up date) to the colletion of all lines 
            }
            else//if the line is not found
                throw new DO.BadLineCodeException(line.Code, "Not found");
        }
        /// <summary>
        /// delete line
        /// </summary>
        /// <param name="num">num of line to delete</param>
        /// <param name="code">runing code of line to delete</param>
        public void DeleteLine(int num, int code)
        {
            DO.Line toDel;
            toDel = DataSource.ListLines.FirstOrDefault(l => (l.LineNum == num && l.Code == code)); //find line that have this num line and runing code
            if (toDel == null) //if the line is not found
                throw new DO.BadLineCodeException(num, "Not found");
            toDel.Active = false;
        }

        #endregion

        #region LineStation
        /// <summary>
        /// add line station
        /// </summary>
        /// <param name="ls">line station to add</param>
        public void AddLineStation(DO.LineStation ls)
        {
            if (DataSource.ListLineStations.FirstOrDefault(s => s.Code == ls.Code && s.LineCode==ls.LineCode) != null) //Check if we already have such a line station in the collection of line stations 
                throw new DO.BadLineStationException(ls.Code,ls.LineCode, "Duplicate station Code");
            DataSource.ListLineStations.Add(ls.Clone());
        }
        /// <summary>
        /// return all lines station.
        /// </summary>
        /// <returns>a collection of all lines staton</returns>
        public IEnumerable<DO.LineStation> GetAllLinesStation()
        {
            return from ls in DataSource.ListLineStations
                   select ls.Clone();
        }
        /// <summary>
        /// return all lines station by line
        /// </summary>
        /// <param name="lineCode">runing code of the line</param>
        /// <returns>a collection of alll lines station by this line</returns>
        public IEnumerable<DO.LineStation>GetAllLinesStationByLine(int lineCode)
        {
            return from ls in DataSource.ListLineStations
                        where ls.LineCode == lineCode //if this line station associated with theis line
                        select ls.Clone();
            
        }
        /// <summary>
        /// up date line station 
        /// </summary>
        /// <param name="ls">line station to up date </param>
        public void UpdateLineStation(DO.LineStation ls)
        {
            DO.LineStation toUpDate = DataSource.ListLineStations.Find(s => s.Code == ls.Code && s.LineCode==ls.LineCode );//find line station with this station code
            if (toUpDate != null)//if line station is found
            {
                DataSource.ListLineStations.Remove(toUpDate);//remove this line station
                DataSource.ListLineStations.Add(ls.Clone());//add a new line station (up date) to the collection of all lines station
            }
            else//if the line station is not found
                throw new DO.BadLineStationException(ls.Code,ls.LineCode, "Not found");
        }
        /// <summary>
        /// delete line station
        /// </summary>
        /// <param name="lineCode">num of line</param>
        /// <param name="codeStation">code station to delete</param>
        public void DeleteLineStation(int lineCode, int codeStation)
        {
            DO.LineStation toDel;
            toDel = DataSource.ListLineStations.FirstOrDefault(s => s.Code == codeStation && s.LineCode == lineCode);//find line station with this code station and num line
            if (toDel == null)//if this line station is not found
                throw new DO.BadLineStationException(codeStation, "Not found in " + lineCode);
            DataSource.ListLineStations.Remove(toDel);//remove this line station
        }
        /// <summary>
        /// return line station
        /// </summary>
        /// <param name="lineCode">runing code of line</param>
        /// <param name="codeStation">code line station to return</param>
        /// <returns>line station</returns>
        public DO.LineStation GetLineStation(int lineCode, int codeStation)
        {
            DO.LineStation toGet = DataSource.ListLineStations.Find(s =>( s.Code == codeStation && s.LineCode== lineCode));//find this line station with this code station and code line
            //try
            //{
            //    Thread.Sleep(2000);
            //}
            //catch (ThreadInterruptedException ex) { }
            if (toGet != null)//if the line station is found
                return toGet.Clone();
            else //if the line station is not found
                throw new DO.BadLineStationException(codeStation, "Not found in "+ lineCode);
        }
        #endregion

        #region AdjacentStations
        /// <summary>
        /// return Adjacent Stations
        /// </summary>
        /// <param name="numS1">code of station 1</param>
        /// <param name="numS2">code of station 2</param>
        /// <returns></returns>
        public DO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2)
        {
            DO.AdjacentStetions toGet = DataSource.ListAdjStations.Find(adj => (adj.Station1 == numS1 && adj.Station2 == numS2)); //find Adjacent Stations with this stations in the collection of Adjacent Stations
            //try
            //{
            //    Thread.Sleep(2000);
            //}
            //catch (ThreadInterruptedException ex) { }
            if (toGet != null) //if the Adjacent Stations is found
                return toGet.Clone();
            else //if the Adjacent Stations not found
                throw new DO.BadAdjacentStetionsException(numS1,numS2, "Not found");
        }
        /// <summary>
        /// add Adjacent Stations
        /// </summary>
        /// <param name="adj">Adjacent Stations to add</param>
        public void AddAdjacentStetions(DO.AdjacentStetions adj)
        {
            if (DataSource.ListAdjStations.FirstOrDefault(a => a.Station1 == adj.Station1&& a.Station2 == adj.Station2) != null)//If we already have such Adjacent Stations in the list of Adjacent Stations
                throw new DO.BadLineStationException(adj.Station1,adj.Station2, "Duplicate AdjacentStetions");
            DataSource.ListAdjStations.Add(adj.Clone());//add Adjacent Stations to the collection of all Adjacent Stations
        }
        /// <summary>
        /// up date Adjacent Stations
        /// </summary>
        /// <param name="adj">Adjacent Stations to up date</param>
        public void UpdateAdjacentStetions(DO.AdjacentStetions adj)
        {
            DO.AdjacentStetions toUpDate = DataSource.ListAdjStations.Find(a => a.Station1 == adj.Station1 && a.Station2 == adj.Station2);//find if the Adjacent Stations is in the collection of Adjacent Stations
            if (toUpDate != null)//if the Adjacent Stations is found
            {
                DataSource.ListAdjStations.Remove(toUpDate);//remove this Adjacent Stations
                DataSource.ListAdjStations.Add(adj.Clone());//add a new Adjacent Stations (up date) to the collection of all Adjacent Stations
            }
            else//if the Adjacent Stations is not found
                throw new DO.BadAdjacentStetionsException(adj.Station1,adj.Station2, "Not found");
        }
        /// <summary>
        /// delete Adjacent Stations
        /// </summary>
        /// <param name="numS2">code of station 1</param>
        /// <param name="numS1">code of station 2</param>
        public void DeleteAdjacentStetions(int numS2, int numS1)
        {
            DO.AdjacentStetions toDel;
            toDel = DataSource.ListAdjStations.FirstOrDefault(a => a.Station1 == numS1 && a.Station2 == numS2);//find this Adjacent Stations with this stations
            if (toDel == null)//if the Adjacent Stations is not found
                throw new DO.BadLineStationException(numS1,numS2, "Not found");
            DataSource.ListAdjStations.Remove(toDel);//remove this Adjacent Stations
        }
        /// <summary>
        /// return all Adjacent Stations by this code station
        /// </summary>
        /// <param name="code">code of station</param>
        /// <returns>a collection of all Adjacent Stations with this code station</returns>
        public IEnumerable<DO.AdjacentStetions> GetALLAdjStetionsbycode(int code)
        {
            return from item in DataSource.ListAdjStations
                   where (item.Station1 == code || item.Station2 == code)//if one of the station have this code 
                   select item; 
        }

        #endregion
    }
}






