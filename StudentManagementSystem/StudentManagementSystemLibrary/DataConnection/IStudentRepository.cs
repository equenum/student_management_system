using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    /// <summary>
    /// Represents a student repository.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Gets all student information from the database.
        /// </summary>
        /// <returns>A list of student information.</returns>
        List<StudentModel> GetStudents_All();
        /// <summary>
        /// Gets all student information by group from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <returns>A list of student information by groups.</returns>
        List<StudentModel> GetStudents_ByGroup(int groupId);
        /// <summary>
        /// Gets student info from the database by id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <returns>Student info from the database by id.</returns>
        StudentModel GetStudent_ById(int studentId);
        /// <summary>
        /// Updates first and second names for the student specified by id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <param name="updatedFirstName">Updated (new) first name for the student.</param>
        /// <param name="updatedLastName">Updated (new) last name for the student.</param>
        void UpdateStudent(int studentId, string updatedFirstName, string updatedLastName);
    }
}