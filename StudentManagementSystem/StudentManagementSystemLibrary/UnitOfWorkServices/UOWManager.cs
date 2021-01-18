using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.UnitOfWorkServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary
{
    /// <summary>
    /// Represents globally accessible cache that holds and manages Units Of Work as well as student, 
    /// group and course information.
    /// </summary>
    public static class UOWManager
    {
        public static IStudentUOW StudentUOW = new StudentUOW(GlobalConfig.Connection);
        public static IGroupUOW GroupUOW = new GroupUOW(GlobalConfig.Connection);
        public static ICourseUOW CourseUOW = new CourseUOW(GlobalConfig.Connection);
    }
}
