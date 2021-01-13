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
                                select item.LineNum;
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
            DO.Station stationDO=new DO.Station();
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
        #endregion

        #region LineStation
        IEnumerable<BO.Line> GetAllLineStation()
        {

        }
        IEnumerable<DO.Line> GetAllActiveLinStations()
        {

        }
        IEnumerable<BO.LineStation> GetAllLinesStationByLine(int LineNum)
        {

        }
        BO.Line GetLineStation(int numLine, int codeLine)
        {

        }
        void AddLineStation(BO.Line line)
        {

        }
        void UpdateLineStation(BO.Line line)
        {

        }
        void DeleteLineStation(int numLine, int codeLine)
        {

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
            try
            {
                dl.AddLine(lineDO);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Error", ex);
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
        }
        public void DeleteLine(int numLine, int codeLine)
        {
            try
            {
                dl.DeleteLine(numLine,codeLine);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
        }
        #endregion

    }
}
