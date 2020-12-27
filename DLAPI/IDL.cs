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
        IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int num);
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void UpdateLine(int num, Action<DO.Line> update); //method that knows to updt specific fields in Line
        void DeleteLine(int num);
        #endregion

        #region Student
        DO.Student GetStudent(int id);
        IEnumerable<DO.Student> GetAllStudents();
        IEnumerable<object> GetStudentListWithSelectedFields(Func<DO.Student, object> generate);
        void AddStudent(DO.Student student);
        void UpdateStudent(DO.Student student);
        void UpdateStudent(int id, Action<DO.Student> update); //method that knows to updt specific fields in Student
        void DeleteStudent(int id); // removes only Student, does not remove the appropriate Person...
        #endregion

        #region StudentInCourse
        IEnumerable<DO.StudentInCourse> GetStudentInCourseList(Predicate<DO.StudentInCourse> predicate);
        #endregion

        #region Course
        DO.Course GetCourse(int id);
        #endregion
    }
}
