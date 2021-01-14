using System;
using System.Collections.Generic;

//using DO;

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
        //IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int num, int code);
        int AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void DeleteLine(int num, int code);
        //void UpdateLine(int num, Action<DO.Line> update); //method that knows to updt specific fields in Line

        #endregion

        // #region AdjacentStetions
        // DO.AdjacentStetions GetAdjStations(int code1, int code2);
        // //IEnumerable<DO.AdjacentStetions> GetAllStudents();
        // //IEnumerable<object> GetStudentListWithSelectedFields(Func<DO.Student, object> generate);
        // void AddAdjStations(DO.AdjacentStetions adjStations);
        // void UpdateAdjStations(DO.AdjacentStetions adjStations);
        //// void UpdateAdjStations(int id, Action<DO.Student> update); //method that knows to updt specific fields in Student
        // void DeleteAdjStations(int code1,int code2); // removes only Student, does not remove the appropriate Person...
        // #endregion


        #region Station
        //IEnumerable<DO.Station> GetAllUpdateStations();
        //IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate);
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllActiveStations();
        DO.Station GetStation(int num);
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station);
        void DeleteStation(int num);
        //void UpdateStation(int num, Action<DO.Station> update); //method that knows to updt specific fields in Line

        #endregion



        #region LineStation
        //IEnumerable<DO.LineStation> GetAllLineStations();
        //IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.Line> predicate);
        DO.LineStation GetLineStation(int codeLine, int codeStation);
        void AddLineStation(DO.LineStation ls);
        IEnumerable<DO.LineStation> GetAllLinesStation();
        IEnumerable<DO.LineStation> GetAllLinesStationByLine(int LineNum);
        void UpdateLineStation(DO.LineStation ls);
        void DeleteLineStation(int lineCode, int codeStation);
        //void UpdateLine(int num, Action<DO.LineStation> update); //method that knows to updt specific fields in Line

        #endregion


        #region AdjacentStations 
        //IEnumerable<BO.AdjacentStetions> GetAllAdjacentStetions();
        //IEnumerable<DO.AdjacentStetions> GetAllActiveAdjacentStetions();
        DO.AdjacentStetions GetAdjacentStetions(int numS1, int numS2);
        void AddAdjacentStetions(DO.AdjacentStetions adj);
        void UpdateAdjacentStetions(DO.AdjacentStetions adj);
        void DeleteAdjacentStetions(int numS2, int numS1);
        #endregion
    }
}
