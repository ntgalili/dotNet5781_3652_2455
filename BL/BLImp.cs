using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;

using System.Threading;


namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();


        #region Station
        public BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            stationDO.CopyPropertiesTo(stationBO);
            stationBO.MyLines = from item in dl.GetAllLinesStation()
                                where item.StationCode == stationBO.Code
                                select item.LineCode;
            return stationBO;
        }
        public IEnumerable<BO.Station> GetAllStations()
        {
            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }
        public BO.Station GetStation(int num)
        {

            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(num);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
            return stationDoBoAdapter(stationDO);
        }
        public IEnumerable<BO.Station> GetAllActiveStations()
        {
            return from item in dl.GetAllStations()
                   where item.Active == true
                   select stationDoBoAdapter(item);
        }
        public void AddStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.AddStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Duplicate station Code", ex);
            }
        }
        public void UpdateStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
        }
        public void DeleteStation(int num)//למחוק גם מתחנות קו ומתחנות עוקבות
        {
            try
            {
                dl.DeleteStation(num);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
        }
        public void MakeStationActive(int codeStation)
        {
            BO.Station s = GetStation(codeStation);
            s.Active = true;
            UpdateStation(s);
        }
        void ChekIfStationActive(int codeStation)
        {
            BO.Station s= GetStation(codeStation);
            if (s.MyLines.Count() == 0)
                DeleteStation(s.Code);
        }
        #endregion



        #region LineStation
        public BO.LineStation LineStationDoBoAdapter(DO.LineStation LineStationDO)
        {
            BO.LineStation LineStationBO = new BO.LineStation();
            LineStationDO.CopyPropertiesTo(LineStationBO);
            return LineStationBO;
        }
        IEnumerable<BO.LineStation> GetAllLineStation()
        {
            return from item in dl.GetAllLinesStation()
                   select LineStationDoBoAdapter(item);
        }
        IEnumerable<BO.LineStation> GetAllLinesStationByLine(int codeLine)
        {
            return from item in dl.GetAllLinesStationByLine(codeLine)
                   select LineStationDoBoAdapter(item);
        }
        BO.LineStation GetLineStation(int lineCode, int codeStation)
        {
            DO.LineStation LineStationDO;
            try
            {
                LineStationDO = dl.GetLineStation(lineCode,codeStation);
            }
            catch (DO.BadLineStationException ex)
            {
                throw new BO.BadLineStationException(codeStation,lineCode,"Line Station Code does not exist", ex);
            }
            return LineStationDoBoAdapter(LineStationDO);
        }
        void AddLineStation(BO.LineStation lsBO)
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            lsBO.CopyPropertiesTo(LineStationDO);
            try
            {
                dl.AddLineStation(LineStationDO);
            }
            catch (DO.BadLineStationException ex)
            {
                throw new BO.BadLineStationException(lsBO.Code,lsBO.LineCode,"Duplicate station Code", ex);
            }
            MakeStationActive(lsBO.Code);
        }
        void UpdateLineStation(BO.LineStation ls)
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            ls.CopyPropertiesTo(LineStationDO);
            try
            {
                dl.UpdateLineStation(LineStationDO);
            }
            catch (DO.BadLineStationException ex)
            {
                throw new BO.BadLineStationException(ls.Code,ls.LineCode,"Station Code does not exist", ex);
            }
        }
        void DeleteLineStation(int lineCode, int codeStation)
        {
            try
            {
                dl.DeleteLineStation(lineCode,codeStation);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
            ChekIfStationActive(codeStation);
        }
        #endregion



        #region Line

        public BO.Line LineDoBoAdapter(DO.Line LineDO)
        {
            BO.Line LineBO = new BO.Line();
            LineDO.CopyPropertiesTo(LineBO);
            LineBO.MyStations = from item in GetAllLinesStationByLine(LineBO.LineNum)
                                orderby item.LineStationIndex
                                select item;
            return LineBO;
        }
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from item in dl.GetAllLines()
                   select LineDoBoAdapter(item);
        }
        public BO.Line GetLine(int numLine, int codeLine)
        {
            DO.Line LineDO;
            try
            {
                LineDO = dl.GetLine(numLine, codeLine);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            return LineDoBoAdapter(LineDO);
        }
        public void AddLine(BO.Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            int lineCode;
            int index = 0;
            try
            {
                lineCode = dl.AddLine(lineDO);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Error", ex);
            }
            foreach (BO.LineStation ls in lineBO.MyStations)
            {
                index++;
                ls.LineCode = lineCode;
                ls.LineStationIndex = index;
                AddLineStation(ls);
            }
            for (int i = 1; i < index - 1; i++)
            {
                try
                {
                    AddAdjacentStetions((lineBO.MyStations.ToList())[i], (lineBO.MyStations.ToList())[i + 1]);
                }
                catch (BO.BadAdjacentStetionsException ex) { }
            }
        }
        public void UpdateLine(BO.Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            foreach (BO.LineStation ls in GetAllLinesStationByLine(lineBO.Code))
            {
                DeleteLineStation(ls.LineCode, ls.Code);
            }
            int index = 0;
            foreach (BO.LineStation ls in lineBO.MyStations)
            {
                index++;
                ls.LineCode = lineBO.Code;
                ls.LineStationIndex = index;
                AddLineStation(ls);
            }
            for (int i = 1; i < index - 1; i++)
            {
                try
                {
                    AddAdjacentStetions((lineBO.MyStations.ToList())[i], (lineBO.MyStations.ToList())[i + 1]);
                }
                catch (BO.BadAdjacentStetionsException ex) { }
            }
        }
        public void DeleteLine(int numLine, int codeLine)
        {
            try
            {
                dl.DeleteLine(numLine, codeLine);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            foreach (BO.LineStation ls in GetAllLinesStationByLine(codeLine))
            {
                try
                {
                    DeleteLineStation(codeLine, ls.Code);
                }
                catch (BO.BadStationCodeException ex) { }
            }
        }
        #endregion



        //#region AdjacentStations 
        //private static Random r = new Random();
        //private static double distance(double X1, double Y1, double X2, double Y2)
        //{
        //    var sCoord = new GeoCoordinate(X1, Y1);
        //    var eCoord = new GeoCoordinate(X1, Y1);

        //    return sCoord.GetDistanceTo(eCoord);
        //}
        //BO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2)
        //{

        //}
        //void AddAdjacentStetions(BO.LineStation s1, BO.LineStation s2)
        //{
        //adj.Distance = distance(35.001165, 31.715411, 34.989861, 31.715411);
        //adj.Time = new TimeSpan(0, (int)(distance(35.001165, 31.715411, 34.989861, 31.715411) * r.NextDouble()), 0);
        //}
        //void UpdateAdjacentStetions(BO.AdjacentStetions adj)
        //{

        //}
        //void DeleteAdjacentStations(int numS1, int numS2)
        //{

        //}
        //#endregion

    }
}
