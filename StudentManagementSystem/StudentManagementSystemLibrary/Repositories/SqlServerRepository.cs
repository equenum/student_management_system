using Dapper;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.Repositories
{
    public class SqlServerRepository : IRepository
    {
        private readonly string connStringName = "SqlServer";

        /// <summary>
        /// Gets all course information from the database.
        /// </summary>
        /// <returns>A list of course information.</returns>
        public List<CourseModel> GetCourses_All()
        {
            List<CourseModel> output;

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                output = connection.Query<CourseModel>("dbo.spCourses_GetAll").ToList();

                foreach (var course in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@CourseId", course.CourseId);

                    course.Groups = connection.Query<GroupModel>("dbo.spGroups_GetByCourse", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (var group in course.Groups)
                    {
                        p = new DynamicParameters();
                        p.Add("@GroupId", group.GroupId);

                        group.Students = connection.Query<StudentModel>("dbo.spStudents_GetByGroup", p, commandType: CommandType.StoredProcedure).ToList();
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Gets all group information from the database.
        /// </summary>
        /// <returns>A list of group information.</returns>
        public List<GroupModel> GetGroups_All()
        {
            List<GroupModel> output;

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                output = connection.Query<GroupModel>("dbo.spGroups_GetAll").ToList();

                foreach (var group in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@GroupId", group.GroupId);

                    group.Students = connection.Query<StudentModel>("dbo.spStudents_GetByGroup", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }

        /// <summary>
        /// Gets all student information from the database.
        /// </summary>
        /// <returns>A list of student information.</returns>
        public List<StudentModel> GetStudents_All()
        {
            List<StudentModel> output;

            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                output = connection.Query<StudentModel>("dbo.spStudents_GetAll").ToList();
            }

            return output;
        }

        /// <summary>
        /// Updates name for the group specified by id.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="updatedName">Updated (new) name for the group.</param>
        public void UpdateGroupName(int groupId, string updatedName)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var p = new DynamicParameters();
                p.Add("@GroupId", groupId);
                p.Add("@UpdatedName", updatedName);

                connection.Query<GroupModel>("dbo.spGroup_UpdateNameById", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Updates first and second names for the student specified by id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <param name="updatedFirstName">Updated (new) first name for the student.</param>
        /// <param name="updatedLastName">Updated (new) last name for the student.</param>
        public void UpdateStudentName(int studentId, string updatedFirstName, string updatedLastName)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var p = new DynamicParameters();
                p.Add("@StudentId", studentId);
                p.Add("@UpdatedFirstName", updatedFirstName);
                p.Add("@UpdatedLastName", updatedLastName);

                connection.Query<StudentModel>("dbo.spStudent_UpdateNameById", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Deletes the group specified by id.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        public void DeleteGroup(int groupId)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var p = new DynamicParameters();
                p.Add("@GroupId", groupId);

                connection.Query<GroupModel>("dbo.spGroup_DeleteById", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
