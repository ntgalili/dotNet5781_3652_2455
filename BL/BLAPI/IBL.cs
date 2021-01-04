﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLAPI
{
    public interface IBL
    {
        #region Station
        IEnumerable<BL.BO.Station> GetAllStations();
        BL.BO.Station GetStation(int num);
        void AddStation(BL.BO.Station station);
        void UpdateStation(BL.BO.Station station);
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
    }
}
