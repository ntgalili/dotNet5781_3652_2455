using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLAPI
{
    /// <summary>
    /// The interface of the layer BL
    /// </summary>
    public interface IBL
    {
        #region Station
        /// <summary>
        /// return all the station
        /// </summary>
        /// <returns>A collection of station</returns>
        IEnumerable<BO.Station> GetAllStations();

        /// <summary>
        /// return all the Active station
        /// </summary>
        /// <returns>A collection of active station</returns>
        IEnumerable<BO.Station> GetAllActiveStations();

        /// <summary>
        /// return one station by code
        /// </summary>
        /// <param name="num">the code of the station</param>
        /// <returns>the station</returns>
        BO.Station GetStation(int num);

        /// <summary>
        /// add a station
        /// </summary>
        /// <param name="station">station to add</param>
        void AddStation(BO.Station station);

        /// <summary>
        /// up date one station
        /// </summary>
        /// <param name="station">The updated station</param>
        void UpdateStation(BO.Station station);

        /// <summary>
        /// activtion of a station
        /// </summary>
        /// <param name="codeStation">the code of the station to activate</param>
        void MakeStationActive(int codeStation);

        /// <summary>
        /// delete a station
        /// </summary>
        /// <param name="num">the code of the station to delete</param>
        void DeleteStation(int num);

        /// <summary>
        /// calculate whether the station should be not active  
        /// </summary>
        /// <param name="codeStation">the station code</param>
        void ChekIfStationActive(int codeStation);
        #endregion


        #region Line
        /// <summary>
        /// return all the lines
        /// </summary>
        /// <returns>collection of lines</returns>
        IEnumerable<BO.Line> GetAllLines();

        /// <summary>
        /// return all the active lines
        /// </summary>
        /// <returns>collection of lines</returns>
        IEnumerable<BO.Line> GetAllActiveLines();

        /// <summary>
        /// return a line by line number and code
        /// </summary>
        /// <param name="numLine">the line number</param>
        /// <param name="codeLine">the line code</param>
        /// <returns>the line</returns>
        BO.Line GetLine(int codeLine);

        /// <summary>
        /// add a line
        /// </summary>
        /// <param name="line">the line to add</param>
        void AddLine(BO.Line lineBO, int firstCode, int lastCode);

        /// <summary>
        /// up date a line
        /// </summary>
        /// <param name="line">the updated line</param>
        void UpdateLine(BO.Line line);

        /// <summary>
        /// delete a line  by line number and code
        /// </summary>
        /// <param name="numLine">the line number</param>
        /// <param name="codeLine">the line code</param>
        void DeleteLine(int numLine, int codeLine);

        TimeSpan TimeCalculation(BO.Station st, BO.Line line);

        #endregion


        #region LineStation
        /// <summary>
        /// return all the line stations
        /// </summary>
        /// <returns>collection of line stations </returns>
        IEnumerable<BO.LineStation> GetAllLineStation();

        /// <summary>
        /// return all the line stations by line code
        /// </summary>
        /// <param name="codeLine">line number</param>
        /// <returns>sortd collection of line stations</returns>
        IEnumerable<BO.LineStation> GetAllLinesStationByLine(int codeLine);

        /// <summary>
        /// return one line station
        /// </summary>
        /// <param name="lineCode">the line's code</param>
        /// <param name="codeStation">the station's code </param>
        /// <returns>the line station</returns>
        BO.LineStation GetLineStation(int lineCode, int codeStation);

        /// <summary>
        /// add a line station
        /// </summary>
        /// <param name="ls">the line station to add</param>
        void AddLineStation(BO.LineStation ls);

        /// <summary>
        /// update a line station
        /// </summary>
        /// <param name="ls">the updated line station</param>
        void UpdateLineStation(BO.LineStation ls);

        /// <summary>
        /// delete a line station
        /// </summary>
        /// <param name="lineCode">the line's code</param>
        /// <param name="codeStation">the station's code</param>
        void DeleteLineStation(int lineCode, int codeStation);

        void AddStationToLine(int ls, BO.Line line, int index);
        void deleteStationFromLine(int ls, BO.Line line);


        #endregion


        #region AdjacentStations 

        /// <summary>
        /// return Adjacent Stetions by their codes
        /// </summary>
        /// <param name="numS1">the code of the first station</param>
        /// <param name="numS2">the code of the second station</param>
        /// <returns>the Adjacent Stetions</returns>
        BO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2);

        /// <summary>
        /// add Adjacent Stetions
        /// </summary>
        /// <param name="s1">the first station</param>
        /// <param name="s2">the second station</param>
        void AddAdjacentStetions(BO.LineStation s1, BO.LineStation s2);

        /// <summary>
        /// update Adjacent Stetions
        /// </summary>
        /// <param name="s1">the first station</param>
        /// <param name="s2">the second station</param>
        void UpdateAdjacentStetions(BO.LineStation s1, BO.LineStation s2);

        /// <summary>
        /// delete  AdjacentStations
        /// </summary>
        /// <param name="numS1">the first station</param>
        /// <param name="numS2">the second station</param>
        void DeleteAdjacentStations(int numS1, int numS2);


        /// <summary>
        /// return all the Adjacent Stetions by code of one of the stations
        /// </summary>
        /// <param name="code">the code of the one of the stations</param>
        /// <returns>collection of AdjacentStetions</returns>
        IEnumerable<BO.AdjacentStetions> GetALLAdjStetionsbycode(int code);



        #endregion



        #region LineTrip

       // IEnumerable<BO.LineTrip> GetAllLineTrips();

        BO.LineTrip GetLineTrip(int codelp);
        IEnumerable<BO.LineTrip> GetAllLineTripByCode(int code);
        void AddLineTrip(BO.LineTrip lt);

        void UpdateLineTrip(BO.LineTrip lt);

        void DeleteLineTrip(int codelt);
        #endregion


        #region LineTiming
        IEnumerable<BO.LineTiming> GetAllTime(TimeSpan now, BO.Station s);
        #endregion

    }
}
