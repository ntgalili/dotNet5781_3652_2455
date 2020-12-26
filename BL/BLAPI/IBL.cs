using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public interface IBL                                     //************העתקתי מהמורה לבדוק אם זה טוב ***************
    {
        //Add Person to Course
        //get all courses for student
        //etc...
        BO.Student GetStudent(int id);
        IEnumerable<BO.Student> GetAllStudents();
        IEnumerable<BO.ListedPerson> GetStudentIDs();

        IEnumerable<BO.Student> GetStudentsBy(Predicate<BO.Student> predicate);
    }
}
