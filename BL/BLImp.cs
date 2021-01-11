using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;

using System.Threading;


namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();


        public BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            stationDO.CopyPropertiesTo(stationBO);
            return stationBO;
        }

        #region Station

        public IEnumerable<BO.Station> GetAllStations()
        {
            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }



        public BO.Station GetStation(int num)
        {
            
              DO.Station stationDO;
              try
              {
                 stationDO = dl.GetStation(num);
              }
              catch (DO.BadStationCodeException ex)
              {
                  throw new BO.BadStationCodeException("Station Code does not exist", ex);
              }
              return stationDoBoAdapter(stationDO);
            
        }
        public void AddStation(BO.Station stationBO)
        {
            DO.Station stationDO=new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.AddStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Duplicate station Code", ex);
            }
            
        }
        public void UpdateStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }

        }

        public void DeleteStation(int num)//למחוק גם מתחנות קו ומתחנות עוקבות
        {
            try
            {
                dl.DeleteStation(num);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station Code does not exist", ex);
            }
        }
        #endregion
        //    BO.Student studentDoBoAdapter(DO.Student studentDO)
        //    {
        //        BO.Student studentBO = new BO.Student();
        //        DO.Person personDO;
        //        int id = studentDO.ID;
        //        try
        //        {
        //            personDO = dl.GetPerson(id);
        //        }
        //        catch (DO.BadPersonIdException ex)
        //        {
        //            throw new BO.BadStudentIdException("Student ID is illegal", ex);
        //        }
        //        personDO.CopyPropertiesTo(studentBO);
        //        //studentBO.ID = personDO.ID;
        //        //studentBO.BirthDate = personDO.BirthDate;
        //        //studentBO.City = personDO.City;
        //        //studentBO.Name = personDO.Name;
        //        //studentBO.HouseNumber = personDO.HouseNumber;
        //        //studentBO.Street = personDO.Street;
        //        //studentBO.PersonalStatus = (BO.PersonalStatus)(int)personDO.PersonalStatus;

        //        studentDO.CopyPropertiesTo(studentBO);
        //        //studentBO.StartYear = studentDO.StartYear;
        //        //studentBO.Status = (BO.StudentStatus)(int)studentDO.Status;
        //        //studentBO.Graduation = (BO.StudentGraduate)(int)studentDO.Graduation;

        //        studentBO.ListOfCourses = from sic in dl.GetStudentInCourseList(sic => sic.PersonId == id)
        //                                  let course = dl.GetCourse(sic.CourseId)
        //                                  select course.CopyToStudentCourse(sic);
        //        //new BO.StudentCourse()
        //        //{
        //        //    ID = course.ID,
        //        //    Number = course.Number,
        //        //    Name = course.Name,
        //        //    Year = course.Year,
        //        //    Semester = (BO.Semester)(int)course.Semester,
        //        //    Grade = sic.Grade
        //        //};

        //        return studentBO;
        //    }

        //    public BO.Student GetStudent(int id)
        //    {
        //        DO.Student studentDO;
        //        try
        //        {
        //            studentDO = dl.GetStudent(id);
        //        }
        //        catch (DO.BadPersonIdException ex)
        //        {
        //            throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
        //        }
        //        return studentDoBoAdapter(studentDO);
        //    }

        //    public IEnumerable<BO.Student> GetAllStudents()
        //    {
        //        //return from item in dl.GetStudentListWithSelectedFields( (stud) => { return GetStudent(stud.ID); } )
        //        //       let student = item as BO.Student
        //        //       orderby student.ID
        //        //       select student;
        //        return from item in dl.GetAllStudents()
        //               select studentDoBoAdapter(item);
        //    }
        //    public IEnumerable<BO.Student> GetStudentsBy(Predicate<BO.Student> predicate)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<BO.ListedPerson> GetStudentIDNameList()
        //    {
        //        return from item in dl.GetStudentListWithSelectedFields((Func<DO.Student, object>)((stud) =>
        //                {
        //                    try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
        //                    return new BO.ListedPerson() { ID = stud.ID, Name = dl.GetPerson(stud.ID).Name };
        //                }))
        //               let student = item as BO.ListedPerson
        //               //orderby student.ID
        //               select student;
        //    }








        public BO.Line LineDoBoAdapter(DO.Line LineDO)
        {
            BO.Line LineBO = new BO.Line();
            LineDO.CopyPropertiesTo(LineBO);
            return LineBO;
        }

        #region Line
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from item in dl.GetAllLines()
                   select LineDoBoAdapter(item);
        }
        public BO.Line GetLine(int numLine, int codeLine)
        {
            DO.Line LineDO;
            try
            {
                LineDO = dl.GetLine(numLine, codeLine);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
            return LineDoBoAdapter(LineDO);
        }
        public void AddLine(BO.Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            try
            {
                dl.AddLine(lineDO);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Duplicate Line Code", ex);
            }
        }
        public void UpdateLine(BO.Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
        }
        public void DeleteLine(int numLine, int codeLine)
        {
            try
            {
                dl.DeleteLine(numLine,codeLine);
            }
            catch (DO.BadLineCodeException ex)
            {
                throw new BO.BadLineCodeException("Line Code does not exist", ex);
            }
        }
        #endregion

    }
}
