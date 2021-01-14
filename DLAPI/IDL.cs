using System;
using System.Collections.Generic;

namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {

        #region Line
        IEnumerable<DO.Line> GetAllLines();
        IEnumerable<DO.Line> GetAllActiveLines();
        DO.Line GetLine(int num, int code);
        int AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void DeleteLine(int num, int code);

        #endregion

        #region Station
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllActiveStations();
        DO.Station GetStation(int num);
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station);
        void DeleteStation(int num);
        #endregion

        #region LineStation
        DO.LineStation GetLineStation(int codeLine, int codeStation);
        void AddLineStation(DO.LineStation ls);
        IEnumerable<DO.LineStation> GetAllLinesStation();
        IEnumerable<DO.LineStation> GetAllLinesStationByLine(int LineNum);
        void UpdateLineStation(DO.LineStation ls);
        void DeleteLineStation(int lineCode, int codeStation);

        #endregion

        #region AdjacentStations 
        DO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2);
        void AddAdjacentStetions(DO.AdjacentStetions adj);
        void UpdateAdjacentStetions(DO.AdjacentStetions adj);
        void DeleteAdjacentStetions(int numS1, int numS2);
        IEnumerable<DO.AdjacentStetions> GetALLAdjStetionsbycode(int code);
        #endregion

    }
}
