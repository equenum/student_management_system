using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    public class CourseProcessor
    {
        private IRepository _database;

        public CourseProcessor(IRepository repository)
        {
            _database = repository;
        }

        /// <summary>
        /// Gets all course information from the database.
        /// </summary>
        /// <returns>A list of course information.</returns>
        public List<CourseModel> GetCourses_All()
        {
            string sql = "exec dbo.spCourses_GetAll ;";

            var output = _database.GetData_All<CourseModel>(sql);

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

            foreach (var course in output)
            {
                CacheManager.CourseIdentityMap.AddItem(course);
            }

            return output;
        }

        /// <summary>
        /// Gets all group information by course from the database.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        /// <returns>A list of group information by courses.</returns>
        public List<GroupModel> GetGroups_ByCourse(int courseId)
        {
            var sql = "exec dbo.spGroups_GetByCourse @CourseId = COURSE_ID ;";

            sql = sql.Replace("COURSE_ID", $"{ courseId }");

            return _database.GetListData_ById<GroupModel>(sql);
        }

        /// <summary>
        /// Gets all student information by group from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <returns>A list of student information by groups.</returns>
        public List<StudentModel> GetStudents_ByGroup(int groupId)
        {
            var sql = "exec dbo.spStudents_GetByGroup @GroupId = GROUP_ID ;";

            sql = sql.Replace("GROUP_ID", $"{ groupId }");

            return _database.GetListData_ById<StudentModel>(sql);
        }
    }
}
