using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    /// <summary>
    /// Represents a group repository.
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        /// Deletes the group specified by id from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        void DeleteGroup(int groupId);
        /// <summary>
        /// Gets all group information from the database.
        /// </summary>
        /// <returns>A list of group information.</returns>
        List<GroupModel> GetGroups_All();
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
        /// <summary>
        /// Updates name for the group specified by id.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="updatedName">Updated (new) name for the group.</param>
        void UpdateGroupName(int groupId, string updatedName);
    }
}