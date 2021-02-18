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
        /// <summary>
        /// return all lines
        /// </summary>
        /// <returns> a collection of lines </returns>
        IEnumerable<DO.Line> GetAllLines();

        /// <summary>
        /// return all active lines
        /// </summary>
        /// <returns> a collection of active lines</returns>
        IEnumerable<DO.Line> GetAllActiveLines();

        /// <summary>
        /// return line
        /// </summary>
        /// <param name="num">the number of lines</param>
        /// <param name="code">the runing code line</param>
        /// <returns>a line with thus code and num line</returns>
        DO.Line GetLine(int num, int code);

        /// <summary>
        /// add line 
        /// </summary>
        /// <param name="line">line to add</param>
        /// <returns>a runing code of the new line</returns>
        int AddLine(DO.Line line);

        /// <summary>
        /// up date line
        /// </summary>
        /// <param name="line">line to up date</param>
        void UpdateLine(DO.Line line);

        /// <summary>
        /// delete line
        /// </summary>
        /// <param name="num">num of line</param>
        /// <param name="code">runing code of line</param>
        void DeleteLine(int num, int code);

        #endregion

        #region Station
        /// <summary>
        /// return all stations
        /// </summary>
        /// <returns>a collection of stations</returns>
        IEnumerable<DO.Station> GetAllStations();

        /// <summary>
        /// return all active stations
        /// </summary>
        /// <returns> a collection of all active stations</returns>
        IEnumerable<DO.Station> GetAllActiveStations();

        /// <summary>
        /// return station that have this code
        /// </summary>
        /// <param name="num">code of station</param>
        /// <returns></returns>
        DO.Station GetStation(int num);

        /// <summary>
        /// add station
        /// </summary>
        /// <param name="station"> station to add</param>
        void AddStation(DO.Station station);
        
        /// <summary>
        /// up date station
        /// </summary>
        /// <param name="station">station to up date</param>
        void UpdateStation(DO.Station station);

        /// <summary>
        /// delete station
        /// </summary>
        /// <param name="num">code of station to delete</param>
        void DeleteStation(int num);
        #endregion

        #region LineStation
        /// <summary>
        /// return line station
        /// </summary>
        /// <param name="codeLine">A code of a line passing through a particular station</param>
        /// <param name="codeStation">code of station</param>
        /// <returns>line station that have this code station and the line goes through it</returns>
        DO.LineStation GetLineStation(int codeLine, int codeStation);

        /// <summary>
        /// add line station of line
        /// </summary>
        /// <param name="ls">line station to add</param>
        void AddLineStation(DO.LineStation ls);

        /// <summary>
        /// return all lines station
        /// </summary>
        /// <returns>a  collection of all lines station</returns>
        IEnumerable<DO.LineStation> GetAllLinesStation();

        /// <summary>
        /// return all lines station by line
        /// </summary>
        /// <param name="LineNum">A line number that you want to return to the list of all the stations it passes through</param>
        /// <returns>a collection of lines station</returns>
        IEnumerable<DO.LineStation> GetAllLinesStationByLine(int LineNum);

        /// <summary>
        /// up date lines station
        /// </summary>
        /// <param name="ls">line station to up date</param>
        void UpdateLineStation(DO.LineStation ls);

        /// <summary>
        /// delete lines station
        /// </summary>
        /// <param name="lineCode">Code of a line from which you want to delete a particular station</param>
        /// <param name="codeStation">code of station to delete</param>
        void DeleteLineStation(int lineCode, int codeStation);

        #endregion

        #region AdjacentStations 
        /// <summary>
        /// return adjecent stations
        /// </summary>
        /// <param name="numS1">code of station 1</param>
        /// <param name="numS2">code of station 2</param>
        /// <returns>Adjacent Stetions of station 1 and station 2</returns>
        DO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2);

        /// <summary>
        /// add Adjacent Stetions 
        /// </summary>
        /// <param name="adj">Adjacent Stetions to add</param>
        void AddAdjacentStetions(DO.AdjacentStetions adj);

        /// <summary>
        /// up date Adjacent Stetions
        /// </summary>
        /// <param name="adj">Adjacent Stetions to up date</param>
        void UpdateAdjacentStetions(DO.AdjacentStetions adj);

        /// <summary>
        /// delete Adjacent Stetions
        /// </summary>
        /// <param name="numS1">code of station 1</param>
        /// <param name="numS2">code of station 2</param>
        void DeleteAdjacentStetions(int numS1, int numS2);

        /// <summary>
        /// return all Adjacent Stetions by code
        /// </summary>
        /// <param name="code">code of line</param>
        /// <returns>a collection of all successive stations of a particular line</returns>
        IEnumerable<DO.AdjacentStetions> GetALLAdjStetionsbycode(int code);
        #endregion

        #region LineTrip
        int AddLineTrip(DO.LineTrip lt);
        DO.LineTrip GetLineTrip(int code);
        IEnumerable<DO.LineTrip> GetAllLineTripByCode(int code);
        void UpdateLineTrip(DO.LineTrip lt);
        void DeleteLineTrip(int code);
        #endregion

        //#region User
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //IEnumerable<DO.User> GetALLUser();
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="password"></param>
        //void DeleteUser(string name, int password);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="user"></param>
        //void UpdateUser(DO.User user);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="user"></param>
        //void AddUser(DO.User user);
        //#endregion



    }
}
