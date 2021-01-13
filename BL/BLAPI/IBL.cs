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
        void DeleteStation(int num);
        #endregion

        //#region StudentInCourse
        //void AddStudentInCourse(int perID, int courseID, float grade = 0);
        //void UpdateStudentGradeInCourse(int perID, int courseID, float grade);
        //void DeleteStudentInCourse(int perID, int courseID);

        //#endregion

        //#region Course
        //IEnumerable<BO.Course> GetAllCourses();
        //#endregion

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
        IEnumerable<DO.Line> GetAllActiveLinStations();
        IEnumerable<BO.LineStation> GetAllLinesStationByLine(int LineNum);
        BO.Line GetLineStation(int numLine, int codeLine);
        void AddLineStation(BO.Line line);
        void UpdateLineStation(BO.Line line);
        void DeleteLineStation(int numLine, int codeLine);
        #endregion
    }
}
