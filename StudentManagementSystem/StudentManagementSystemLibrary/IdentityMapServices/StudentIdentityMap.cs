using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class StudentIdentityMap : IIdentityMap<StudentModel>
    {
        private readonly object _poolLock = new object();
        private Dictionary<int, StudentModel> _pool = new Dictionary<int, StudentModel>();

        public void Add(StudentModel student)
        {
            lock (_poolLock)
            {
                _pool.Add(student.StudentId, student);
            }
        }

        public void Remove(StudentModel student)
        {
            lock (_poolLock)
            {
                if (_pool.ContainsKey(student.StudentId))
                {
                    _pool.Remove(student.StudentId);
                }
            }
        }

        public void Clean()
        {
            lock (_poolLock)
            {
                _pool.Clear();
            }
        }

        public List<StudentModel> GetAll()
        {
            lock (_poolLock)
            {
                return _pool.Select(x => x.Value).ToList();
            }
        }
    }
}
