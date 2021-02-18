using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using DLAPI;

using DO;
//using DO;

namespace DL
{
    sealed class DLXML : IDL    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string ListStationsPath = @"ListStationsXml.xml"; //XElement 

        string ListLinesPath = @"ListLinesXml.xml"; //XMLSerializer
        string ListLineStationsPath = @"ListLineStationsXml.xml"; //XMLSerializer
        string ListAdjStationsPath = @"ListAdjStationsXml.xml"; //XMLSerializer
        string ListLineTripsPath = @"ListLineTripsXml.xml";//Xelement

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
            List<AdjacentStetions> ListAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStetions>(ListAdjStationsPath);
            AdjacentStetions toGet = ListAdjStations.Find(adj => (adj.Station1 == numS1 && adj.Station2 == numS2&&adj.Active==true)); //find Adjacent Stations with this stations in the collection of Adjacent Stations
            if (toGet != null) //if the Adjacent Stations is found
                return toGet;
            else //if the Adjacent Stations not found
                throw new BadAdjacentStetionsException(numS1, numS2, "Not found");
        }
        /// <summary>
        /// add Adjacent Stations
        /// </summary>
        /// <param name="adj">Adjacent Stations to add</param>
        public void AddAdjacentStetions(DO.AdjacentStetions adj)
        {
            List<AdjacentStetions> ListAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStetions>(ListAdjStationsPath);
            if (ListAdjStations.FirstOrDefault(a => a.Station1 == adj.Station1 && a.Station2 == adj.Station2) != null)//If we already have such Adjacent Stations in the list of Adjacent Stations
                throw new BadLineStationException(adj.Station1, adj.Station2, "Duplicate AdjacentStetions");
            ListAdjStations.Add(adj);//add Adjacent Stations to the collection of all Adjacent Stations
            XMLTools.SaveListToXMLSerializer(ListAdjStations, ListAdjStationsPath);
        }
        /// <summary>
        /// up date Adjacent Stations
        /// </summary>
        /// <param name="adj">Adjacent Stations to up date</param>
        public void UpdateAdjacentStetions(DO.AdjacentStetions adj)
        {
            List<AdjacentStetions> ListAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStetions>(ListAdjStationsPath);
            AdjacentStetions toUpDate = ListAdjStations.Find(a => a.Station1 == adj.Station1 && a.Station2 == adj.Station2);//find if the Adjacent Stations is in the collection of Adjacent Stations
            if (toUpDate != null)//if the Adjacent Stations is found
            {
                ListAdjStations.Remove(toUpDate);//remove this Adjacent Stations
                ListAdjStations.Add(adj);//add a new Adjacent Stations (up date) to the collection of all Adjacent Stations
            }
            else//if the Adjacent Stations is not found
                throw new BadAdjacentStetionsException(adj.Station1, adj.Station2, "Not found");
            XMLTools.SaveListToXMLSerializer(ListAdjStations, ListAdjStationsPath);
        }
        /// <summary>
        /// delete Adjacent Stations
        /// </summary>
        /// <param name="numS2">code of station 1</param>
        /// <param name="numS1">code of station 2</param>
        public void DeleteAdjacentStetions(int numS2, int numS1)
        {
            List<AdjacentStetions> ListAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStetions>(ListAdjStationsPath);
            AdjacentStetions toDel;
            toDel = ListAdjStations.FirstOrDefault(a => a.Station1 == numS1 && a.Station2 == numS2 &&a.Active==true);//find this Adjacent Stations with this stations
            if (toDel == null)//if the Adjacent Stations is not found
                throw new BadLineStationException(numS1, numS2, "Not found");
            toDel.Active = false;//remove this Adjacent Stations
            XMLTools.SaveListToXMLSerializer(ListAdjStations, ListAdjStationsPath);
        }
        /// <summary>
        /// return all Adjacent Stations by this code station
        /// </summary>
        /// <param name="code">code of station</param>
        /// <returns>a collection of all Adjacent Stations with this code station</returns>
        public IEnumerable<DO.AdjacentStetions> GetALLAdjStetionsbycode(int code)
        {
            List<AdjacentStetions> ListAdjStations = XMLTools.LoadListFromXMLSerializer<AdjacentStetions>(ListAdjStationsPath);
            return from item in ListAdjStations
                   where (item.Station1 == code || item.Station2 == code)//if one of the station have this code 
                   select item;
        }

        #endregion

        #region LineStation
        /// <summary>
        /// add line station
        /// </summary>
        /// <param name="ls">line station to add</param>
        public void AddLineStation(DO.LineStation ls)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            if (ListLineStations.FirstOrDefault(s => s.Code == ls.Code && s.LineCode == ls.LineCode) != null) //Check if we already have such a line station in the collection of line stations 
                throw new DO.BadLineStationException(ls.Code, ls.LineCode, "Duplicate station Code");
            ListLineStations.Add(ls);
            XMLTools.SaveListToXMLSerializer(ListLineStations, ListLineStationsPath);
        }
        /// <summary>
        /// return all lines station.
        /// </summary>
        /// <returns>a collection of all lines staton</returns>
        public IEnumerable<DO.LineStation> GetAllLinesStation()
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            return from ls in ListLineStations
                   select ls;
        }
        /// <summary>
        /// return all lines station by line
        /// </summary>
        /// <param name="lineCode">runing code of the line</param>
        /// <returns>a collection of alll lines station by this line</returns>
        public IEnumerable<DO.LineStation> GetAllLinesStationByLine(int lineCode)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            return from ls in ListLineStations
                   where ls.LineCode == lineCode //if this line station associated with theis line
                   select ls;
        }
        /// <summary>
        /// up date line station 
        /// </summary>
        /// <param name="ls">line station to up date </param>
        public void UpdateLineStation(DO.LineStation ls)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            DO.LineStation toUpDate = ListLineStations.Find(s => s.Code == ls.Code && s.LineCode == ls.LineCode);//find line station with this station code
            if (toUpDate != null)//if line station is found
            {
                ListLineStations.Remove(toUpDate);//remove this line station
                ListLineStations.Add(ls);//add a new line station (up date) to the collection of all lines station
            }
            else//if the line station is not found
                throw new DO.BadLineStationException(ls.Code, ls.LineCode, "Not found");
            XMLTools.SaveListToXMLSerializer(ListLineStations, ListLineStationsPath);
        }
        /// <summary>
        /// delete line station
        /// </summary>
        /// <param name="lineCode">num of line</param>
        /// <param name="codeStation">code station to delete</param>
        public void DeleteLineStation(int lineCode, int codeStation)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            DO.LineStation toDel;
            toDel = ListLineStations.FirstOrDefault(s => s.Code == codeStation && s.LineCode == lineCode);//find line station with this code station and num line
            if (toDel == null)//if this line station is not found
                throw new DO.BadLineStationException(codeStation, "Not found in " + lineCode);
            ListLineStations.Remove(toDel);//remove this line station
            XMLTools.SaveListToXMLSerializer(ListLineStations, ListLineStationsPath);
        }
        /// <summary>
        /// return line station
        /// </summary>
        /// <param name="lineCode">runing code of line</param>
        /// <param name="codeStation">code line station to return</param>
        /// <returns>line station</returns>
        public DO.LineStation GetLineStation(int lineCode, int codeStation)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(ListLineStationsPath);
            DO.LineStation toGet = ListLineStations.Find(s => (s.Code == codeStation && s.LineCode == lineCode));//find this line station with this code station and code line
            if (toGet != null)//if the line station is found
                return toGet;
            else //if the line station is not found
                throw new DO.BadLineStationException(codeStation, "Not found in " + lineCode);
        }
        #endregion

        #region Line
        /// <summary>
        /// return all lines
        /// </summary>
        /// <returns>a collection of all lines</returns>
        public IEnumerable<DO.Line> GetAllLines()
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            return from Line in ListLines
                   select Line;
        }
        /// <summary>
        /// return all active lines
        /// </summary>
        /// <returns>a collection of all active lines</returns>
        public IEnumerable<DO.Line> GetAllActiveLines()
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            return from Line in ListLines
                   where Line.Active == true //if this line is active
                   select Line;
        }
        /// <summary>
        /// return line
        /// </summary>
        /// <param name="num">num of line</param>
        /// <param name="code">runing code of line</param>
        /// <returns>a line that have this code and num line</returns>
        public DO.Line GetLine(int num, int code)
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            DO.Line toGet = ListLines.Find(l => (l.LineNum == num && l.Code == code)); //find this line
            if (toGet != null) //if the line is found
                return toGet;
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
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            line.Code = DO.config.LineID++;
            ListLines.Add(line); //add line to collection of all lines
            XMLTools.SaveListToXMLSerializer(ListLines, ListLinesPath);
            return line.Code;
        }
        /// <summary>
        /// up date line
        /// </summary>
        /// <param name="line">line to up date</param>
        public void UpdateLine(DO.Line line)
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            DO.Line toUpDate = ListLines.Find(l => l.Code == line.Code);//find the line thet have this code line 
            if (toUpDate != null) //uf the line is found
            {
                ListLines.Remove(toUpDate);//remove this line
                ListLines.Add(line);//add the new line (up date) to the colletion of all lines 
            }
            else//if the line is not found
                throw new DO.BadLineCodeException(line.Code, "Not found");
            XMLTools.SaveListToXMLSerializer(ListLines, ListLinesPath);
        }
        /// <summary>
        /// delete line
        /// </summary>
        /// <param name="num">num of line to delete</param>
        /// <param name="code">runing code of line to delete</param>
        public void DeleteLine(int num, int code)
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(ListLinesPath);
            Line toDel;
            toDel = ListLines.FirstOrDefault(l => (l.LineNum == num && l.Code == code)); //find line that have this num line and runing code
            if (toDel == null) //if the line is not found
                throw new BadLineCodeException(num, "Not found");
            toDel.Active = false;
            XMLTools.SaveListToXMLSerializer(ListLines, ListLinesPath);
        }

        #endregion

        #region Station
        /// <summary>
        /// return all stations
        /// </summary>
        /// <returns>a collection of all stations</returns>
        public IEnumerable<DO.Station> GetAllStations()
        {
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);
            return (from station in stationRoot.Elements()
                   select fromXmlToStation(station)); 
        }
        /// <summary>
        /// return all active stations
        /// </summary>
        /// <returns>a collecion of all active stations</returns>
        public IEnumerable<DO.Station> GetAllActiveStations()
        {
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);
            return (from station in stationRoot.Elements()
                    let s =fromXmlToStation(station)
                    where s.Active == true
                    select s
               ) ;
        }
        /// <summary>
        /// return DO station
        /// </summary>
        /// <param name="num">code of station to return </param>
        /// <returns>station that have this code</returns>
        public DO.Station GetStation(int num)
        {
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);

                XElement station = (from s in stationRoot.Elements()
                                   where int.Parse(s.Element("Code").Value) == num
                                   select s).FirstOrDefault();

            if (station != null) //if the station found - cloning the station 
                return fromXmlToStation(station);
            else
                throw new DO.BadStationCodeException(num, "Not found"); //if the station not found
        }


        DO.Station fromXmlToStation(XElement element)
        {
            return new Station()
            {
                Code = Int32.Parse(element.Element("Code").Value),
                Name = element.Element("Name").Value,
                Longitude = double.Parse(element.Element("Longitude").Value),
                Lattitude = double.Parse(element.Element("Lattitude").Value),
                Include = (StationInclude)Enum.Parse(typeof(StationInclude), element.Element("Include").Value),
                Active = bool.Parse(element.Element("Active").Value)
            };
        }
        /// <summary>
        /// add station to collection stations
        /// </summary>
        /// <param name="station">station to add</param>
        public void AddStation(DO.Station station)
        {
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);

            XElement st = (from s in stationRoot.Elements()
                                where int.Parse(s.Element("Code").Value) == station.Code
                                select s).FirstOrDefault();

            if (st != null) //check if we have station with this code in collection of station
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code");
            XElement toAdd = new XElement("Station", new XElement("Code", station.Code),
                                      new XElement("Name", station.Name),
                                      new XElement("Longitude", station.Longitude.ToString()),
                                      new XElement("Lattitude", station.Lattitude.ToString()),
                                      new XElement("Include", station.Include.ToString()),
                                      new XElement("Active", station.Active.ToString()));
            stationRoot.Add(toAdd);
            XMLTools.SaveListToXMLElement(stationRoot, ListStationsPath);
        }
        /// <summary>
        /// up date station
        /// </summary>
        /// <param name="station">station to up date</param>
        public void UpdateStation(DO.Station station)
        {
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);


            XElement st = (from s in stationRoot.Elements()
                           where int.Parse(s.Element("Code").Value) == station.Code
                           select s).FirstOrDefault();


            if (st != null) //if the station found
            {
                st.Element("Code").Value = station.Code.ToString();
                st.Element("Name").Value = station.Name;
                st.Element("Longitude").Value = station.Longitude.ToString();

                st.Element("Lattitude").Value = station.Lattitude.ToString();
                st.Element("Include").Value = station.Include.ToString();
                st.Element("Active").Value = station.Active.ToString();
                XMLTools.SaveListToXMLElement(stationRoot, ListStationsPath);
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
            XElement stationRoot = XMLTools.LoadListFromXMLElement(ListStationsPath);


            XElement st = (from s in stationRoot.Elements()
                           where int.Parse(s.Element("Code").Value) == num
                           select s).FirstOrDefault();

            if (st == null) //if station not found
                throw new DO.BadStationCodeException(num, "Not found");
            if (bool.Parse(st.Element("Active").Value) == false)//if this station is not active
                throw new DO.BadStationCodeException(num, "the station is already canceled");
            st.Element("Active").Value = false.ToString();
            XMLTools.SaveListToXMLElement(stationRoot, ListStationsPath);
        }
        #endregion

        #region LineTrip
        public IEnumerable<DO.LineTrip> GetAllLineTripByCode(int code)
        {
            XElement TripRoot = XMLTools.LoadListFromXMLElement(ListLineTripsPath);
            IEnumerable<DO.LineTrip> toGet = (from lineTrip in TripRoot.Elements()
                    where int.Parse(lineTrip.Element("CodeLine").Value) == code
                    select fromXmlToLineTrip(lineTrip));
            if (toGet.Count() == 0)
                throw new DO.BadLineCodeException(code);
            return toGet;
        }
        public int AddLineTrip(DO.LineTrip lt)
        {
            XElement TripRoot = XMLTools.LoadListFromXMLElement(ListLineTripsPath);
            lt.CodeLineTrip = DO.config.LineTripID++;
            XElement find = (from l in TripRoot.Elements()
                              where int.Parse(l.Element("CodeLineTrip").Value) == lt.CodeLineTrip
                              select l).FirstOrDefault();

            if (find != null) //check if we have station with this code in collection of station
                throw new DO.BadLineTripException(lt.CodeLineTrip, "Duplicate station Code");

            XElement toAdd = new XElement("LineTrip", new XElement("CodeLineTrip", lt.CodeLineTrip),
                                      new XElement("StartAtTime", lt.StartAtTime.ToString()),
                                      new XElement("CodeLine", lt.CodeLine.ToString()),
                                      new XElement("Active", lt.Active.ToString()));
            TripRoot.Add(toAdd);
            XMLTools.SaveListToXMLElement(TripRoot, ListLineTripsPath);

            return lt.CodeLineTrip;

        }

        public DO.LineTrip GetLineTrip(int code)
        {
            XElement TripRoot = XMLTools.LoadListFromXMLElement(ListLineTripsPath);

            XElement lt = (from l in TripRoot.Elements()
                                where int.Parse(l.Element("CodeLineTrip").Value) == code
                                select l).FirstOrDefault();

            if (lt != null) //if the station found - cloning the station 
                return fromXmlToLineTrip(lt);
            else
                throw new DO.BadLineTripException(code, "Not found"); //if the station not found

        }

        public void UpdateLineTrip(DO.LineTrip lt)
        {
            XElement TripRoot = XMLTools.LoadListFromXMLElement(ListLineTripsPath);


            XElement toUpdate = (from l in TripRoot.Elements()
                           where int.Parse(l.Element("CodeLineTrip").Value) == lt.CodeLineTrip
                           select l).FirstOrDefault();


            if (toUpdate != null) //if the station found
            {
                toUpdate.Element("CodeLineTrip").Value = lt.CodeLineTrip.ToString();
                toUpdate.Element("CodeLine").Value = lt.CodeLine.ToString();
                toUpdate.Element("StartAtTime").Value = lt.StartAtTime.ToString();
                toUpdate.Element("Active").Value = lt.Active.ToString();
                XMLTools.SaveListToXMLElement(TripRoot, ListLineTripsPath);
            }
            else //if the station are not found
                throw new DO.BadLineTripException(lt.CodeLineTrip, "Not found");
      

        
        }
        public void DeleteLineTrip(int code)
        {
            XElement TripRoot = XMLTools.LoadListFromXMLElement(ListLineTripsPath);


            XElement lt = (from l in TripRoot.Elements()
                           where int.Parse(l.Element("CodeLineTrip").Value) == code
                           select l).FirstOrDefault();

            if (lt == null) //if station not found
                throw new DO.BadLineTripException(code, "Not found");
            if (bool.Parse(lt.Element("Active").Value) == false)//if this station is not active
                throw new DO.BadLineTripException(code, "the station is already canceled");
            lt.Element("Active").Value = false.ToString();
            XMLTools.SaveListToXMLElement(TripRoot, ListLineTripsPath);

        }
        DO.LineTrip fromXmlToLineTrip(XElement element)
        {
            return new LineTrip
            {
                CodeLineTrip = Int32.Parse(element.Element("CodeLineTrip").Value),
                CodeLine = Int32.Parse(element.Element("CodeLine").Value),
                Active = bool.Parse(element.Element("Active").Value),
                StartAtTime = XmlConvert.ToTimeSpan(element.Element("ToTimeSpan").Value),
            };
        }
        #endregion
    }
}
