using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class CourseIdentityMap : IIdentityMap<CourseModel>
    {
        private readonly object _poolLock = new object();
        private Dictionary<int, CourseModel> _pool = new Dictionary<int, CourseModel>();

        public void Add(CourseModel course)
        {
            lock (_poolLock)
            {
                _pool.Add(course.CourseId, course);
            }
        }

        public void Remove(CourseModel course)
        {
            lock (_poolLock)
            {
                if (_pool.ContainsKey(course.CourseId))
                {
                    _pool.Remove(course.CourseId);
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

        public List<CourseModel> GetAll()
        {
            lock (_poolLock)
            {
                return _pool.Select(x => x.Value).ToList();
            }
        }
    }
}
