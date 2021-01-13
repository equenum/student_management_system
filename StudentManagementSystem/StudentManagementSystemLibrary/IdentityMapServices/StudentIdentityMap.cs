using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class StudentIdentityMap : IIdentityMap<StudentModel> // TODO - Decide should i make interfaces
    {
        private Dictionary<int, StudentModel> _pool = new Dictionary<int, StudentModel>();

        public void AddItem(StudentModel student)
        {
            if (_pool.ContainsKey(student.StudentId) == false)
            {
                _pool.Add(student.StudentId, student);
            }
        }

        public bool LookupItemById(int studentId) // Do i need this lookup?
        {
            if (_pool.ContainsKey(studentId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LookupStudentByGroup(int groupId)
        {
            if (_pool.Any(x => x.Value.GroupId == groupId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public StudentModel GetItem(int studentId)
        {
            return _pool[studentId];
        }
    }
}
