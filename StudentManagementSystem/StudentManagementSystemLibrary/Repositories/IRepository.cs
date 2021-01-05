using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Repositories
{
    /// <summary>
    /// Represents a repository which is responsible for handling the database connection.
    /// </summary>
    public interface IRepository
    {
        List<StudentModel> GetStudents_All();
        List<GroupModel> GetGroups_All();
        List<CourseModel> GetCourses_All();
        List<GroupModel> GetGroups_ByCourse(int courseId);
        List<StudentModel> GetStudents_ByGroup(int groupId);
        void UpdateStudentName(int studentId, string updatedFirstName, string updatedLastName);
        void UpdateGroupName(int groupId, string updatedName);
        void DeleteGroup(int groupId);
    }
}
