using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    /// <summary>
    /// Represents a course identity map.
    /// </summary>
    public interface ICourseIdentityMap : IIdentityMap<CourseModel>
    {
        /// <summary>
        /// Checks if the course identity map pool is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsNotEmpty();
    }
}
