using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    public class GroupProcessor
    {
        private IRepository _database;

        public GroupProcessor(IRepository repository)
        {
            _database = repository;
        }

        /// <summary>
        /// Deletes the group specified by id from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        public void DeleteGroup(int groupId)
        {
            string sql = "exec dbo.spGroup_DeleteById @GroupId = GROUD_ID ;";

            sql = sql.Replace("GROUD_ID", $"{ groupId }");

            _database.DeleteData<GroupModel>(sql);
        }

        /// <summary>
        /// Gets all group information from the database.
        /// </summary>
        /// <returns>A list of group information.</returns>
        public List<GroupModel> GetGroups_All()
        {
            string sql = "exec dbo.spGroups_GetAll ;";

            var output = _database.GetData_All<GroupModel>(sql);

            foreach (var group in output)
            {
                group.Students = GetStudents_ByGroup(group.GroupId);
            }

            return output;
        }

        /// <summary>
        /// Gets all student information by group from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <returns>A list of student information by groups.</returns>
        public List<StudentModel> GetStudents_ByGroup(int groupId)
        {
            string sql = "exec dbo.spStudents_GetByGroup @GroupId = GROUP_ID ;";
            sql = sql.Replace("GROUP_ID", $"{ groupId }");

            return _database.GetListData_ById<StudentModel>(sql);
        }

        /// <summary>
        /// Updates name for the group specified by id.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="updatedName">Updated (new) name for the group.</param>
        public void UpdateGroupName(int groupId, string updatedName)
        {
            string sql = "exec dbo.spGroup_UpdateNameById @GroupId = GROUP_ID, @UpdatedName = UPDATED_NAME ; ";

            sql = sql.Replace("GROUP_ID", $"{ groupId }");
            sql = sql.Replace("UPDATED_NAME", $"'{ updatedName }'");

            _database.UpdateData<GroupModel>(sql);
        }
    }
}
