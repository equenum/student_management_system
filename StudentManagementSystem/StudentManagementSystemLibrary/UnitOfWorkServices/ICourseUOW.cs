using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    /// <summary>
    /// Represents a student unit of work.
    /// </summary>
    public interface ICourseUOW : IUnitOfWork<CourseModel>
    {
        /// <summary>
        /// Gets all course information.
        /// </summary>
        /// <returns>A list of sourse information.</returns>
        List<CourseModel> GetCoursesAll();
        /// <summary>
        /// Looks up by course id if the course information was
        /// already pulled out from the database.
        /// </summary>
        /// <param name="courseId"></param>
        bool LookupCourseById(int courseId);
        /// <summary>
        /// Looks up if course information was
        /// already pulled out of the database.
        /// </summary>
        bool LookupCourses();
        /// <summary>
        /// Tries to register (pull out of the database) all course information.
        /// </summary>
        bool TryRegisterCoursesAll();
    }
}