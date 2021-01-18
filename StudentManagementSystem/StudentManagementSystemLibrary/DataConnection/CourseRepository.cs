using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    public class CourseRepository : ICourseRepository
    {
        private IDataConnection _connection;

        public CourseRepository(IDataConnection connection)
        {
            _connection = connection;
        }
        
        public List<CourseModel> GetCourses_All()
        {
            string sql = "exec dbo.spCourses_GetAll ;";

            var output = _connection.GetData_All<CourseModel>(sql);

            foreach (var course in output)
            {
                course.Groups = GetGroups_ByCourse(course.CourseId);

                if (course.Groups != null)
                {
                    foreach (var group in course.Groups)
                    {
                        group.Students = GetStudents_ByGroup(group.GroupId);
                    }
                }
            }

            return output;
        }
        
        public List<GroupModel> GetGroups_ByCourse(int courseId)
        {
            var sql = "exec dbo.spGroups_GetByCourse @CourseId = COURSE_ID ;";

            sql = sql.Replace("COURSE_ID", $"{ courseId }");

            return _connection.GetListData_ById<GroupModel>(sql);
        }
        
        public List<StudentModel> GetStudents_ByGroup(int groupId)
        {
            var sql = "exec dbo.spStudents_GetByGroup @GroupId = GROUP_ID ;";

            sql = sql.Replace("GROUP_ID", $"{ groupId }");

            return _connection.GetListData_ById<StudentModel>(sql);
        }
    }
}
