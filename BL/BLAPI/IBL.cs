using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLAPI
{
    public interface IBL
    {
        #region Station
        IEnumerable<BO.Station> GetAllStations();
        IEnumerable<BO.Station> GetAllActiveStations();
        BO.Station GetStation(int num);
        void AddStation(BO.Station station);
        void UpdateStation(BO.Station station);
        void MakeStationActive(int codeStation);
        void DeleteStation(int num);
        void ChekIfStationActive(int codeStation);
        #endregion


        #region Line
        IEnumerable<BO.Line> GetAllLines();
        IEnumerable<DO.Line> GetAllActiveLines();
        BO.Line GetLine(int numLine, int codeLine);
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        void DeleteLine(int numLine, int codeLine);
        #endregion


        #region LineStation
        IEnumerable<BO.Line> GetAllLineStation();
        IEnumerable<BO.LineStation> GetAllLinesStationByLine(int codeLine);
        BO.LineStation GetLineStation(int lineCode, int codeStation);
        void AddLineStation(BO.LineStation ls);
        void UpdateLineStation(BO.LineStation ls);
        void DeleteLineStation(int lineCode, int codeStation);
        #endregion


        #region AdjacentStations 
        BO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2);
        void AddAdjacentStetions(BO.Station s1, BO.Station s2);
        void UpdateAdjacentStetions(BO.AdjacentStetions adj);
        void DeleteAdjacentStations(int numS1, int numS2);
        #endregion
    }
}
