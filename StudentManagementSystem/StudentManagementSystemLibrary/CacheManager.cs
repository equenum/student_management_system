using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary
{
    public static class CacheManager
    {
        public static List<StudentModel> StudentCache = new List<StudentModel>();
        public static List<GroupModel> GroupCache = new List<GroupModel>();
        public static List<CourseModel> CourseCache = new List<CourseModel>();

        public static StudentIdentityMap StudentIdentityMap = new StudentIdentityMap();
        public static GroupIdentityMap GroupIdentityMap = new GroupIdentityMap();
        
    }
}
