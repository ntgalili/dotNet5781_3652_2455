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
        BO.Line GetLine(int numLine, int codeLine);
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        void DeleteLine(int numLine, int codeLine);
        #endregion
    }
}
