using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    /// <summary>
    /// Represents a course repository.
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Gets all course information from the database.
        /// </summary>
        /// <returns>A list of course information.</returns>
        List<CourseModel> GetCourses_All();
        /// <summary>
        /// Gets all group information by course from the database.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        /// <returns>A list of group information by courses.</returns>
        List<GroupModel> GetGroups_ByCourse(int courseId);
        /// <summary>
        /// Gets all student information by group from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <returns>A list of student information by groups.</returns>
        List<StudentModel> GetStudents_ByGroup(int groupId);
    }
}