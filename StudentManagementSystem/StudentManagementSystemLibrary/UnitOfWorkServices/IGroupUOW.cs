using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    /// <summary>
    /// Represents a group unit of work.
    /// </summary>
    public interface IGroupUOW : IUnitOfWork<GroupModel>
    {
        /// <summary>
        /// Gets groups information by course id.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        /// <returns>A list of group information.</returns>
        List<GroupModel> GetGroupsByCourse(int courseId);
        /// <summary>
        /// Looks up by group id if the group information was
        /// already pulled out from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        bool LookupGroupById(int groupId);
        /// <summary>
        /// Looks up by course id if the group information was
        /// already pulled out from the database.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        bool LookupGroupsByCourse(int courseId);
        /// <summary>
        /// Tries to register (pull out of the database) group information by course id.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        bool TryRegisterGroupsByCourse(int courseId);
    }
}