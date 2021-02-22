using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;

using System.Threading;
using System.Device.Location;

namespace BL
{
    /// <summary>
    /// The class that implements BL's interface
    /// </summary>
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();//singelton pattern


        #region Station
        /// <summary>
        /// copy from DO.Station to BO.Station
        /// </summary>
        /// <param name="stationDO">DO.Station to copy</param>
        /// <returns>The copy BO.Station</returns>
        public BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            stationDO.CopyPropertiesTo(stationBO);                     //copy the property from DO.Station to BO.Station
            stationBO.MyLines = from item in dl.GetAllLinesStation()      //finding the lines that travel through the station
                                where item.Code == stationBO.Code
                                select item.LineCode;
            return stationBO;
        }

        /// <summary>
        /// return all the station
        /// </summary>
        /// <returns>A collection of station</returns>
        public IEnumerable<BO.Station> GetAllStations()
        {
            return from item in dl.GetAllStations()//get all the station from the DL layer and copy it to BO.Station
                   orderby item.Code
                   select stationDoBoAdapter(item);
        }

        /// <summary>
        /// return one station by code
        /// </summary>
        /// <param name="num">the code of the station</param>
        /// <returns>the station</returns>
        public BO.Station GetStation(int num)
        {

            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(num);//get the station from the DL layer
            }
            catch (DO.BadStationCodeException ex)//if the station does not found
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
            return stationDoBoAdapter(stationDO);
        }


        /// <summary>
        ///  return all the Active station
        /// </summary>
        /// <returns>A collection of active station</returns>
        public IEnumerable<BO.Station> GetAllActiveStations()
        {
            return from item in dl.GetAllStations()//get all the active station from the DL layer
                   where item.Active == true
                   orderby item.Code
                   select stationDoBoAdapter(item);
        }


        /// <summary>
        /// add a station
        /// </summary>
        /// <param name="stationBO">station to add</param>
        public void AddStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.AddStation(stationDO);//add the station by sending to the DL station
            }
            catch (DO.BadStationCodeException ex)//when there is aready a station with the same code
            {
                throw new BO.BadStationCodeException("Duplicate station Code", ex);
            }
        }

        /// <summary>
        ///  up date one station
        /// </summary>
        /// <param name="stationBO">The updated station</param>
        public void UpdateStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);//up date the station by sending to the DL layer 
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
        }

        /// <summary>
        /// Delete a station by it's code
        /// </summary>
        /// <param name="num">the station's code</param>
        public void DeleteStation(int num)
        {
            try
            {
                dl.DeleteStation(num);//delete from the DL layer
            }
            catch (DO.BadStationCodeException ex)//if the station does not found
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
                
            }
            foreach (BO.AdjacentStetions adj in GetALLAdjStetionsbycode(num))//delete the station from all the Adjacent Stetions
            {
                try
                {
                    DeleteAdjacentStations(adj.Station1.Code, adj.Station2.Code);
                }
                catch(Exception ex) { }
            }
        }

        /// <summary>
        /// activtion of a station
        /// </summary>
        /// <param name="codeStation">the code of the station to activate</param>
        public void MakeStationActive(int codeStation)
        {
            BO.Station s = GetStation(codeStation);//get the station
            s.Active = true;
            UpdateStation(s);//up date the station
        }

        /// <summary>
        /// calculate whether the station should be not active 
        /// </summary>
        /// <param name="codeStation">the station code</param>
        public void ChekIfStationActive(int codeStation)
        {
            BO.Station s= GetStation(codeStation);//get the station
            if (s.MyLines.Count() == 0)
                DeleteStation(s.Code);//delete the station if there is no lines that travel through it
        }
        #endregion



        #region LineStation

        /// <summary>
        /// copy from DO.LineStation to BO.LineStation
        /// </summary>
        /// <param name="LineStationDO">the DO.LineStation</param>
        /// <returns>the BO.LineStation</returns>
        public BO.LineStation LineStationDoBoAdapter(DO.LineStation LineStationDO)
        {
            BO.LineStation LineStationBO = new BO.LineStation();
            DO.Station stationDO;
            int id = LineStationDO.Code;
            try 
            {
                stationDO = dl.GetStation(id);
            }
            catch(DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("afsdaff", ex);
            }

            stationDO.CopyPropertiesTo(LineStationBO);

            LineStationDO.CopyPropertiesTo(LineStationBO);

            return LineStationBO;
        }


        /// <summary>
        /// return all the line stations
        /// </summary>
        /// <returns>collection of line stations</returns>
        public IEnumerable<BO.LineStation> GetAllLineStation()
        {
            return from item in dl.GetAllLinesStation()//get all the line station from the DL layer
                   select LineStationDoBoAdapter(item);
        }

        /// <summary>
        /// return all the line stations by line code
        /// </summary>
        /// <param name="codeLine">the line's code</param>
        /// <returns>sortd collection of the line's stations</returns>
        public IEnumerable<BO.LineStation> GetAllLinesStationByLine(int codeLine)
        {
            return from item in dl.GetAllLinesStationByLine(codeLine)//get the line's station from the DL layer
                   orderby item.LineStationIndex //merge the line station by index
                   select LineStationDoBoAdapter(item);
        }

        /// <summary>
        /// return one line station
        /// </summary>
        /// <param name="lineCode">the line's code</param>
        /// <param name="codeStation">the station's code</param>
        /// <returns>the line station</returns>
        public BO.LineStation GetLineStation(int lineCode, int codeStation)
        {
            DO.LineStation LineStationDO;
            try
            {
                LineStationDO = dl.GetLineStation(lineCode,codeStation);//get the station from the DL layer
            }
            catch (DO.BadLineStationException ex)
            {
                throw new BO.BadLineStationException(codeStation,lineCode,"Line Station Code does not exist", ex);
            }
            return LineStationDoBoAdapter(LineStationDO);
        }


        public void deleteStationFromLine(int ls,BO.Line line)
        {
            int i= 1;
            foreach(BO.LineStation s in line.MyStations)
            {
                if(s.Code!=ls)
                {
                    s.LineStationIndex = i;
                    i++;
                    UpdateLineStation(s);
                }
                else
                {
                    DeleteLineStation(line.Code, ls);
                }
            }
            line.MyStations = GetAllLinesStationByLine(line.Code);
            UpdateLine(line);
        }

        public void  AddStationToLine(int ls, BO.Line line, int index)
        {
            BO.LineStation ToADD = new BO.LineStation();
            GetStation(ls).CopyPropertiesTo(ToADD);
            ToADD.LineCode = line.Code;
           ToADD.LineStationIndex = index;
            try
            { 
                AddLineStation(ToADD);
            }
            catch(Exception ex)
            {
                throw new BO.BadLineStationException(ToADD.Code, line.Code, "the station already exist on the line", ex);
            }

            int i = 1;
                foreach (BO.LineStation s in line.MyStations)
                {
                    if (index < s.LineStationIndex)
                    {
                        s.LineStationIndex = i;
                        UpdateLineStation(s);
                    }
                    if (i > index)
                    {
                        s.LineStationIndex = i;
                    }
                    i++;
                }
            
            line.MyStations = GetAllLinesStationByLine(line.Code);
            UpdateLine(line);
        }


        /// <summary>
        /// add a line station
        /// </summary>
        /// <param name="lsBO">the line station to add</param>
        public void AddLineStation(BO.LineStation lsBO)
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            lsBO.CopyPropertiesTo(LineStationDO);
            try
            {
                dl.AddLineStation(LineStationDO);//add the line station to the DL layer
            }
            catch (DO.BadLineStationException ex)//if there are same line station alredy
            {
                throw new BO.BadLineStationException(lsBO.Code,lsBO.LineCode,"Duplicate station Code", ex);
            }
            MakeStationActive(lsBO.Code);//make the station Active
        }


        /// <summary>
        ///  update a line station
        /// </summary>
        /// <param name="ls">the updated line station</param>
        public void UpdateLineStation(BO.LineStation ls)
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            ls.CopyPropertiesTo(LineStationDO);
            try
            {
                dl.UpdateLineStation(LineStationDO);//up date the station by the DL layer
            }
            catch (DO.BadLineStationException ex)// if the station does not found
            {
                throw new BO.BadLineStationException(ls.Code,ls.LineCode,"Station Code does not exist", ex);
            }
        }


        /// <summary>
        /// delete a line station
        /// </summary>
        /// <param name="lineCode">the line's code</param>
        /// <param name="codeStation">the station's code</param>
        public void DeleteLineStation(int lineCode, int codeStation)
        {
            try
            {
                dl.DeleteLineStation(lineCode,codeStation);//delete the line station from the DL layer
            }
            catch (DO.BadStationCodeException ex)// if the station does not found
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
            ChekIfStationActive(codeStation);//change the station's activity according to its condition
        }
        #endregion



        #region Line
        /// <summary>
        /// copy from DO.Line to BO.Line
        /// </summary>
        /// <param name="LineDO">the DO.Line to copy</param>
        /// <returns>the copy BO.station</returns>
        public BO.Line LineDoBoAdapter(DO.Line LineDO)
        {
            BO.Line LineBO = new BO.Line();
            LineDO.CopyPropertiesTo(LineBO);
            //LineDO.CopyPropertiesTo(LineBO.)
            LineBO.MyStations = from item in GetAllLinesStationByLine(LineBO.Code)//get  all the line's stations
                                orderby item.LineStationIndex
                                select item;
            return LineBO;
        }


        public TimeSpan TimeCalculation(BO.Station st, BO.Line line)
        {
            TimeSpan travelTime = new TimeSpan(0,0,0);
            for (int i=0; i < line.MyStations.Count(); i++)
            {
                if (line.MyStations.ToList()[i].Code == st.Code)
                {
                    return travelTime;
                }
                travelTime += timebetween(line.MyStations.ToList()[i].Code, line.MyStations.ToList()[i + 1].Code);
            }
            throw new BO.BadStationCodeException(st.Code,"The station is not in this line");
        }

        /// <summary>
        /// return all the lines
        /// </summary>
        /// <returns>collection of lines</returns>
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from item in dl.GetAllLines()//get all the lines from the DL layer
                   orderby item.LineNum
                   select LineDoBoAdapter(item);
        }

        /// <summary>
        ///  return a line by line number and code
        /// </summary>
        /// <param name="numLine">the line number</param>
        /// <param name="codeLine">the line code</param>
        /// <returns>the line</returns>
        public BO.Line GetLine(int codeLine)
        {
            DO.Line LineDO;
            try
            {
                LineDO = dl.GetLine(codeLine);//get the line from the DL layer
            }
            catch (DO.BadLineCodeException ex)//if the line does not found
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            return LineDoBoAdapter(LineDO);
        }

        /// <summary>
        /// add a line
        /// </summary>
        /// <param name="lineBO">the line to add<</param>
        public void AddLine(BO.Line lineBO,int firstCode,int lastCode)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            BO.LineStation firstStation =new BO.LineStation();
            BO.LineStation LastStation = new BO.LineStation();
            int lineCode;

            try
            {
                GetStation(firstCode).CopyPropertiesTo(firstStation);
                GetStation(lastCode).CopyPropertiesTo(LastStation);
                lineDO.FirstStation = firstCode;
                lineDO.LastStation = lastCode;
                lineCode = dl.AddLine(lineDO);// add to the DL layer and get it's code
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("ERROR", ex);
            }

            firstStation.LineCode = lineCode;
            firstStation.LineStationIndex = 1;
            AddLineStation(firstStation);
            LastStation.LineCode = lineCode;
            LastStation.LineStationIndex = 2;
            AddLineStation(LastStation);

                try
                {
                    AddAdjacentStetions(firstStation, LastStation);
                }
                catch (BO.BadAdjacentStetionsException ex) { }
            
        }

        /// <summary>
        /// up date a line
        /// </summary>
        /// <param name="lineBO">the updated line</param>
        public void UpdateLine(BO.Line lineBO)
        {
            
            DO.Line lineDO = new DO.Line();

            lineBO.CopyPropertiesTo(lineDO);
            lineDO.FirstStation = lineBO.MyStations.ToList().FirstOrDefault().Code;
            lineDO.LastStation = lineBO.MyStations.ToList().Last().Code;
            try
            {
                dl.UpdateLine(lineDO);//up date the line by the DL layer
            }
            catch (DO.BadLineCodeException ex)//if the line dose not found
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }

        }
        public IEnumerable<BO.Line> GetAllLineByArea(BO.Areas area)
        {
            DO.Areas a =(DO.Areas) area;
            return from item in dl.GetAllLineByArea(a)
                   orderby item.Area
                   select LineDoBoAdapter(item);
        }
        /// <summary>
        /// delete a line  by line number and code
        /// </summary>
        /// <param name="numLine">the line number</param>
        /// <param name="codeLine">the line code</param>
        public void DeleteLine(int numLine, int codeLine)
        {
            try
            {
                dl.DeleteLine(numLine, codeLine);//delete line from DL layer
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            foreach (BO.LineStation ls in GetAllLinesStationByLine(codeLine))//delete the line's stations
            {
                try
                {
                    DeleteLineStation(codeLine, ls.Code);
                }
                catch (BO.BadStationCodeException ex) { }
            }
        }


        /// <summary>
        /// return all the active lines
        /// </summary>
        /// <returns>collection of lines</returns>
        public IEnumerable<BO.Line> GetAllActiveLines()
        {
            return from item in dl.GetAllActiveLines()//get all the active lines from the DL layer
                   orderby item.LineNum
                   select LineDoBoAdapter(item);
        }
        #endregion


        #region AdjacentStations 

        private static Random r = new Random();

        /// <summary>
        /// Calculation of distance between 2 stations
        /// </summary>
        /// <param name="X1">Latitude of the first station</param>
        /// <param name="Y1">longitude of the first station</param>
        /// <param name="X2">Latitude of the second station<</param>
        /// <param name="Y2">longitude of the second station</param>
        /// <returns>the distance</returns>
        private static double distance(double X1, double Y1, double X2, double Y2)
        {
            var sCoord = new GeoCoordinate(X1, Y1);
            var eCoord = new GeoCoordinate(X2, Y2);

            return sCoord.GetDistanceTo(eCoord);
        }


        /// <summary>
        /// copy from DO.AdjacentStetions to BO.AdjacentStetions
        /// </summary>
        /// <param name="AdjacentStetionsDO">DO.AdjacentStetions to copy</param>
        /// <returns>the copy BO.AdjacentStetions</returns>
        public BO.AdjacentStetions AdjacentStetionsDoBoAdapter(DO.AdjacentStetions AdjacentStetionsDO)
        {
            BO.AdjacentStetions AdjacentStetionsBO = new BO.AdjacentStetions();
            AdjacentStetionsDO.CopyPropertiesTo(AdjacentStetionsBO);
            AdjacentStetionsBO.Station1 = GetStation(AdjacentStetionsDO.Station1);    //find the 2 stations
            AdjacentStetionsBO.Station2 = GetStation(AdjacentStetionsDO.Station2);
            return AdjacentStetionsBO;
        }


        /// <summary>
        /// return Adjacent Stetions by their codes
        /// </summary>
        /// <param name="numS1">the code of the first station</param>
        /// <param name="numS2">the code of the second station</param>
        /// <returns></returns>
        public BO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2)
        {
            DO.AdjacentStetions adjDO;
            try
            {
               adjDO= dl.GetAdjacentStetions(numS1, numS2);//get the Adjacent Stetions from the DL layer
            }
            catch(DO.BadAdjacentStetionsException ex)//if the station are not found 
            {
                throw new BO.BadAdjacentStetionsException(numS1, numS2,"not found");
            }
            return AdjacentStetionsDoBoAdapter(adjDO);

            
        }


        public TimeSpan timebetween(int station1, int station2)
        {
            DO.AdjacentStetions adjDO;
            try
            {
                adjDO = dl.GetAdjacentStetions(station1, station2);//get the Adjacent Stetions from the DL layer
            }
            catch (DO.BadAdjacentStetionsException ex)//if the station are not found 
            {
                throw new BO.BadAdjacentStetionsException(station1, station2, "not found");
            }
            return adjDO.Time;
        }

        /// <summary>
        /// add Adjacent Stetions
        /// </summary>
        /// <param name="s1">the first station</param>
        /// <param name="s2">the second station</param>
        public void AddAdjacentStetions(BO.LineStation s1, BO.LineStation s2)
        {
            BO.AdjacentStetions adjBO=new BO.AdjacentStetions();
            adjBO.Station1=(s1.CopyPropertiesToNew(typeof(BO.Station))as BO.Station);
            adjBO.Station2 =(s2.CopyPropertiesToNew(typeof(BO.Station)) as BO.Station);
            adjBO.Distance = distance(s1.Lattitude,s2.Lattitude,s1.Longitude,s2.Longitude);//Calculating the distance
            adjBO.Time = new TimeSpan(0, (int)(adjBO.Distance * r.NextDouble()), 0);//Calculating the traveling time
            DO.AdjacentStetions adjDO=new DO.AdjacentStetions();
            adjBO.CopyPropertiesTo(adjDO);
             adjDO.Station1 = adjBO.Station1.Code;
            adjDO.Station2 = adjBO.Station2.Code;
            adjDO.Active = true;
            try
            {
                dl.AddAdjacentStetions(adjDO);//add the Adjacent Stetions by DL layer  
            }
            catch (DO.BadAdjacentStetionsException ex)//if there are same Adjacent Stetions
            {
                //throw new BO.BadAdjacentStetionsException(s1.Code, s2.Code, "Duplicate Adjacent Stations");
            }
        }

        /// <summary>
        /// update Adjacent Stetions
        /// </summary>
        /// <param name="s1">the first station</param>
        /// <param name="s2">the second station</param>
        public void UpdateAdjacentStetions(BO.LineStation s1, BO.LineStation s2)
        {
            BO.AdjacentStetions adjBO = new BO.AdjacentStetions();
            adjBO.Distance = distance(s1.Lattitude, s2.Lattitude, s1.Longitude, s2.Longitude);//Calculating the distance
            adjBO.Time = new TimeSpan(0, (int)(adjBO.Distance * r.NextDouble()), 0);//Calculating the traveling time
            DO.AdjacentStetions adjDO = new DO.AdjacentStetions();
            adjBO.CopyPropertiesTo(adjDO);
            try
            {
                dl.UpdateAdjacentStetions(adjDO);//update the Adjacent Stetions by the DL layer
            }
            catch (DO.BadAdjacentStetionsException ex)//if the Adjacent Stetions are not found
            {
                throw new BO.BadAdjacentStetionsException(s1.Code, s2.Code, "not found");
            }
        }

        /// <summary>
        /// delete  Adjacent Stations
        /// </summary>
        /// <param name="numS1">the first station's code</param>
        /// <param name="numS2">the second station's code</param>
        public void DeleteAdjacentStations(int numS1, int numS2)
        {
            dl.DeleteAdjacentStetions(numS1, numS2);//delet the Adjacent Stations by DL layer
        }


        /// <summary>
        /// return all the Adjacent Stetions by code of one of the stations
        /// </summary>
        /// <param name="code">the code of the one of the stations</param>
        /// <returns>collection of AdjacentStetions</returns>
        public IEnumerable<BO.AdjacentStetions> GetALLAdjStetionsbycode(int code)
        {
            return from item in dl.GetALLAdjStetionsbycode(code)//get the Adjacent Stetions from the DL layer
                   select AdjacentStetionsDoBoAdapter(item);
        }
        #endregion


        #region LineTiming
        public IEnumerable<BO.LineTiming> GetAllTime(TimeSpan now, BO.Station s)
        {
            List<BO.LineTiming> lineTimings = new List<BO.LineTiming>();
            TimeSpan time;
            BO.Line line;
            foreach (int l in s.MyLines)
            {
                line = GetLine(l);
                time = TimeCalculation(s,line);
                foreach (BO.LineTrip lineTrip in GetAllLineTripByCode(l))
                {
                    if (lineTrip.StartAtTime < now && lineTrip.StartAtTime + time >= now)
                    {
                        BO.LineTiming lineTiming = new BO.LineTiming();
                        lineTiming.TripStart = lineTrip.StartAtTime;
                        lineTiming.LineCode = line.Code;
                        lineTiming.LineNum = line.LineNum;
                        lineTiming.LastStation = line.MyStations.ToList()[line.MyStations.Count() - 1].Name;

                        lineTiming.ExpectedTimeTillArrive =new TimeSpan((int)(lineTrip.StartAtTime + time - now).Hours,
                            (int)(lineTrip.StartAtTime + time - now).Minutes, (int)(lineTrip.StartAtTime + time - now).Seconds);
                        lineTimings.Add(lineTiming);
                    }
                }
            }
            return lineTimings;
        }
        #endregion


        #region LineTrip

        /// public IEnumerable<BO.LineTrip> GetAllLineTrips();
        public BO.LineTrip LineTripDoBoAdapter(DO.LineTrip LtDO)
        {
            BO.LineTrip LtBO = new BO.LineTrip();
            LtDO.CopyPropertiesTo(LtBO);
            //LineDO.CopyPropertiesTo(LineBO.)
            return LtBO;
        }
        public IEnumerable<BO.LineTrip> GetAllLineTripByCode(int code)
        {
            try
            {
                return from item in dl.GetAllLineTripByCode(code)
                            orderby item.StartAtTime
                            select LineTripDoBoAdapter(item);
            }
            catch(DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException(ex.Message,ex);
            }
        }
        public BO.LineTrip GetLineTrip(int codelp)
        {
            DO.LineTrip LtDO;
            try
            {
                LtDO = dl.GetLineTrip(codelp);//get the line from the DL layer
            }
            catch (DO.BadLineTripException ex)//if the line does not found
            {
                throw new BO.BadLineTripException(codelp, "Not Found");
            }
            return LineTripDoBoAdapter(LtDO);
        }

        public void AddLineTrip(BO.LineTrip ltBO)
        {
            DO.LineTrip ltDO = new DO.LineTrip();
            ltBO.CopyPropertiesTo(ltDO);
           
            try
            {

                dl.AddLineTrip(ltDO);// add to the DL layer and get it's code
            }
            catch (DO.BadLineTripException ex)
            {
                throw new BO.BadLineTripException("Existing lineTrip",ex);
            }

        }

        public void UpdateLineTrip(BO.LineTrip ltBO)
        {
            DO.LineTrip ltDO = new DO.LineTrip();
            ltBO.CopyPropertiesTo(ltDO);
            try
            {
                dl.UpdateLineTrip(ltDO);//up date the station by the DL layer
            }
            catch (DO.BadLineTripException ex)// if the station does not found
            {
                throw new BO.BadLineStationException(ltBO.CodeLineTrip, "Line Trip does not exist");
            }
        }

        public void DeleteLineTrip(int codelt)
        {
            try
            {
                dl.DeleteLineTrip(codelt);//delete from the DL layer
            }
            catch (DO.BadLineTripException ex)//if the station does not found
            {
                throw new BO.BadLineTripException("Line Trip does not exist", ex);

            }
        }

        #endregion



        #region User
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDO"></param>
        /// <returns></returns>
        public BO.User UserDoBoAdapter(DO.User userDO)
        {
            BO.User userBO = new BO.User();
            userDO.CopyPropertiesTo(userBO);
            return userBO;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public BO.User GetUser(string name,string code)
        {
            DO.User userDO;
            try
            {
                userDO = dl.GetUser(name,code);//get the station from the DL layer
            }
            catch (DO.BadUserException ex)//if the station does not found
            {
                throw new BO.BadUserException(name, "User Name does not exist");
            }
            return UserDoBoAdapter(userDO);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public void DeleteUser(string name, string password)
        {
            try
            {
                dl.DeleteUser(name,password);//delete from the DL layer
            }
            catch (DO.BadUserException ex)//if the station does not found
            {
                throw new BO.BadUserException(name, "User Name does not exist");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(BO.User userBO)
        {
            DO.User userDO = new DO.User();
            userBO.CopyPropertiesTo(userDO);
            try
            {
                dl.UpdateUser(userDO);//up date the station by sending to the DL layer 
            }
            catch (DO.BadUserException ex)
            {
                throw new BO.BadUserException(userBO.UserName, "User Name does not exist");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(BO.User userBO)
        {
            DO.User userDO = new DO.User();
            userBO.CopyPropertiesTo(userDO);
            try
            {
                dl.AddUser(userDO);//add the station by sending to the DL station
            }
            catch (DO.BadUserException ex)//when there is aready a station with the same code
            {
                throw new BO.BadUserException(userBO.UserName, "Duplicate User Name");
            }
        }
        #endregion
    }
}
