using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary
{
    /// <summary>
    /// Represents globally accessible cache that holds student, 
    /// group and course information pulled from a database as well as corresponding identity maps.
    /// </summary>
    public static class CacheManager
    {
        public static List<StudentModel> StudentCache = new List<StudentModel>();
        public static List<GroupModel> GroupCache = new List<GroupModel>();
        public static List<CourseModel> CourseCache = new List<CourseModel>();

        public static IStudentIdentityMap StudentIdentityMap = new StudentIdentityMap();
        public static IGroupIdentityMap GroupIdentityMap = new GroupIdentityMap();
        public static ICourseIdentityMap CourseIdentityMap = new CourseIdentityMap();
    }
}
