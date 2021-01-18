using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.ModelProcessors
{
    public class StudentRepository : IStudentRepository
    {
        private IDataConnection _connection;

        public StudentRepository(IDataConnection connection)
        {
            _connection = connection;
        }
        
        public List<StudentModel> GetStudents_All()
        {
            string sql = "exec dbo.spStudents_GetAll;";

            var output = _connection.GetData_All<StudentModel>(sql);

            return output;
        }

        public void UpdateStudent(int studentId, string updatedFirstName, string updatedLastName)
        {
            string sql = "exec dbo.spStudent_UpdateNameById " +
                "@StudentId = STUDENT_ID, " +
                "@UpdatedFirstName = UPDATED_FIRST_NAME, " +
                "@UpdatedLastName = UPDATED_LAST_NAME ;";

            sql = sql.Replace("STUDENT_ID", $"{ studentId }");
            sql = sql.Replace("UPDATED_FIRST_NAME", $"'{ updatedFirstName }'");
            sql = sql.Replace("UPDATED_LAST_NAME", $"'{ updatedLastName }'");

            _connection.UpdateData<StudentModel>(sql);
        }

        public StudentModel GetStudent_ById(int studentId)
        {
            string sql = "exec dbo.spStudent_GetById @StudentId = STUDENT_ID ;";

            sql = sql.Replace("STUDENT_ID", $"{ studentId }");

            return _connection.GetSingleData_ById<StudentModel>(sql);
        }
        
        public List<StudentModel> GetStudents_ByGroup(int groupId)
        {
            string sql = "exec dbo.spStudents_GetByGroup @GroupId = GROUP_ID ;";
            sql = sql.Replace("GROUP_ID", $"{ groupId }");

            return _connection.GetListData_ById<StudentModel>(sql);
        }
    }
}
