using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    public class GroupRepository : IGroupRepository
    {
        private IDataConnection _connection;

        public GroupRepository(IDataConnection connection)
        {
            _connection = connection;
        }
        
        public void DeleteGroup(int groupId)
        {
            string sql = "exec dbo.spGroup_DeleteById @GroupId = GROUD_ID ;";

            sql = sql.Replace("GROUD_ID", $"{ groupId }");

            _connection.DeleteData<GroupModel>(sql);
        }
        
        public List<GroupModel> GetGroups_All()
        {
            string sql = "exec dbo.spGroups_GetAll ;";

            var output = _connection.GetData_All<GroupModel>(sql);

            foreach (var group in output)
            {
                group.Students = GetStudents_ByGroup(group.GroupId);
            }

            return output;
        }
        
        public List<StudentModel> GetStudents_ByGroup(int groupId)
        {
            string sql = "exec dbo.spStudents_GetByGroup @GroupId = GROUP_ID ;";
            sql = sql.Replace("GROUP_ID", $"{ groupId }");

            return _connection.GetListData_ById<StudentModel>(sql);
        }
        
        public List<GroupModel> GetGroups_ByCourse(int courseId)
        {
            var sql = "exec dbo.spGroups_GetByCourse @CourseId = COURSE_ID ;";

            sql = sql.Replace("COURSE_ID", $"{ courseId }");

            List<GroupModel> output = _connection.GetListData_ById<GroupModel>(sql);
            
            return _connection.GetListData_ById<GroupModel>(sql);
        }
        
        public void UpdateGroupName(int groupId, string updatedName)
        {
            string sql = "exec dbo.spGroup_UpdateNameById @GroupId = GROUP_ID, @UpdatedName = UPDATED_NAME ; ";

            sql = sql.Replace("GROUP_ID", $"{ groupId }");
            sql = sql.Replace("UPDATED_NAME", $"'{ updatedName }'");

            _connection.UpdateData<GroupModel>(sql);
        }
    }
}
