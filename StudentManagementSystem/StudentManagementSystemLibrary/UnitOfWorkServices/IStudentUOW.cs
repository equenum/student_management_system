using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    /// <summary>
    /// Represents a student unit of work. 
    /// </summary>
    public interface IStudentUOW : IUnitOfWork<StudentModel>
    {
        /// <summary>
        /// Gets student information by student id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <returns>Student information.</returns>
        StudentModel GetStudentById(int studentId);
        /// <summary>
        /// Gets student information by group id.
        /// </summary>
        /// <param name="groudId">Geoup id.</param>
        /// <returns>A list of group information.</returns>
        List<StudentModel> GetStudentsByGroup(int groudId);
        /// <summary>
        /// Looks up by student id if the student information was 
        /// already pulled out of the database.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        bool LookupStudentById(int studentId);
        /// <summary>
        /// Looks up by group id if the studebt information was
        /// already pulled out of the database.
        /// </summary>
        /// <param name="groupId"></param>
        bool LookupStudentsByGroup(int groupId);
        /// <summary>
        /// Tries to register (pull out of the database) student information by student id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        bool TryRegisterStudentById(int studentId);
        /// <summary>
        /// Tries to register (pull out of the database) student informatioin by group id.
        /// </summary>
        /// <param name="groudId"></param>
        /// <returns></returns>
        bool TryRegisterStudentsByGroup(int groudId);
    }
}