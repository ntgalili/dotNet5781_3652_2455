using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            AdjacentStetions toGet = ListAdjStations.Find(adj => (adj.Station1 == numS1 && adj.Station2 == numS2)); //find Adjacent Stations with this stations in the collection of Adjacent Stations
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
            toDel = ListAdjStations.FirstOrDefault(a => a.Station1 == numS1 && a.Station2 == numS2);//find this Adjacent Stations with this stations
            if (toDel == null)//if the Adjacent Stations is not found
                throw new BadLineStationException(numS1, numS2, "Not found");
            ListAdjStations.Remove(toDel);//remove this Adjacent Stations
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



        //#region Person
        //public DO.Person GetPerson(int id)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    Person p = (from per in personsRootElem.Elements()
        //                where int.Parse(per.Element("ID").Value) == id
        //                select new Person()
        //                {
        //                    ID = Int32.Parse(per.Element("ID").Value),
        //                    Name = per.Element("Name").Value,
        //                    Street = per.Element("Street").Value,
        //                    HouseNumber = Int32.Parse(per.Element("HouseNumber").Value),
        //                    City = per.Element("City").Value,
        //                    BirthDate = DateTime.Parse(per.Element("BirthDate").Value),
        //                    PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), per.Element("PersonalStatus").Value),
        //                    Duration = TimeSpan.ParseExact(per.Element("Duration").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
        //                }
        //                ).FirstOrDefault();

        //    if (p == null)
        //        throw new DO.BadPersonIdException(id, $"bad person id: {id}");

        //    return p;
        //}
        //public IEnumerable<DO.Person> GetAllPersons()
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    return (from p in personsRootElem.Elements()
        //            select new Person()
        //            {
        //                ID = Int32.Parse(p.Element("ID").Value),
        //                Name = p.Element("Name").Value,
        //                Street = p.Element("Street").Value,
        //                HouseNumber = Int32.Parse(p.Element("HouseNumber").Value),
        //                City = p.Element("City").Value,
        //                BirthDate = DateTime.Parse(p.Element("BirthDate").Value),
        //                PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), p.Element("PersonalStatus").Value),
        //                Duration = TimeSpan.ParseExact(p.Element("Duration").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
        //            }
        //           );
        //}
        //public IEnumerable<DO.Person> GetAllPersonsBy(Predicate<DO.Person> predicate)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    return from p in personsRootElem.Elements()
        //           let p1 = new Person()
        //           {
        //               ID = Int32.Parse(p.Element("ID").Value),
        //               Name = p.Element("Name").Value,
        //               Street = p.Element("Street").Value,
        //               HouseNumber = Int32.Parse(p.Element("HouseNumber").Value),
        //               City = p.Element("City").Value,
        //               BirthDate = DateTime.Parse(p.Element("BirthDate").Value),
        //               PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), p.Element("PersonalStatus").Value),
        //               Duration = TimeSpan.ParseExact(p.Element("Duration").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
        //           }
        //           where predicate(p1)
        //           select p1;
        //}
        //public void AddPerson(DO.Person person)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per1 = (from p in personsRootElem.Elements()
        //                     where int.Parse(p.Element("ID").Value) == person.ID
        //                     select p).FirstOrDefault();

        //    if (per1 != null)
        //        throw new DO.BadPersonIdException(person.ID, "Duplicate person ID");

        //    XElement personElem = new XElement("Person", new XElement("ID", person.ID),
        //                          new XElement("Name", person.Name),
        //                          new XElement("Street", person.Street),
        //                          new XElement("HouseNumber", person.HouseNumber.ToString()),
        //                          new XElement("City", person.City),
        //                          new XElement("BirthDate", person.BirthDate),
        //                          new XElement("PersonalStatus", person.PersonalStatus.ToString()),
        //                          new XElement("Duration", person.Duration.ToString()));

        //    personsRootElem.Add(personElem);

        //    XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //}

        //public void DeletePerson(int id)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("ID").Value) == id
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Remove(); //<==>   Remove per from personsRootElem

        //        XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(id, $"bad person id: {id}");
        //}

        //public void UpdatePerson(DO.Person person)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("ID").Value) == person.ID
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Element("ID").Value = person.ID.ToString();
        //        per.Element("Name").Value = person.Name;
        //        per.Element("Street").Value = person.Street;
        //        per.Element("HouseNumber").Value = person.HouseNumber.ToString();
        //        per.Element("City").Value = person.City;
        //        per.Element("BirthDate").Value = person.BirthDate.ToString();
        //        per.Element("PersonalStatus").Value = person.PersonalStatus.ToString();
        //        per.Element("Duration").Value = person.Duration.ToString();

        //        XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(person.ID, $"bad person id: {person.ID}");
        //}

        //public void UpdatePerson(int id, Action<DO.Person> update)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion Person

    }
}
