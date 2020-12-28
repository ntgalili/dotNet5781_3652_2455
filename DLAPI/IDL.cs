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
        //IEnumerable<DO.Line> GetAllLines();
        //IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int num);
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void DeleteLine(int num);
        //void UpdateLine(int num, Action<DO.Line> update); //method that knows to updt specific fields in Line

        #endregion

        #region AdjacentStetions
        DO.AdjacentStetions GetAdjStations(int code1, int code2);
        //IEnumerable<DO.AdjacentStetions> GetAllStudents();
        //IEnumerable<object> GetStudentListWithSelectedFields(Func<DO.Student, object> generate);
        void AddAdjStations(DO.AdjacentStetions adjStations);
        void UpdateAdjStations(DO.AdjacentStetions adjStations);
       // void UpdateAdjStations(int id, Action<DO.Student> update); //method that knows to updt specific fields in Student
        void DeleteAdjStations(int code1,int code2); // removes only Student, does not remove the appropriate Person...
        #endregion

    }
}
