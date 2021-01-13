using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class CourseIdentityMap : IIdentityMap<CourseModel>
    {
        private Dictionary<int, CourseModel> _pool = new Dictionary<int, CourseModel>();

        public void AddItem(CourseModel course)
        {
            if (_pool.ContainsKey(course.CourseId) == false)
            {
                _pool.Add(course.CourseId, course);
            }
        }

        public CourseModel GetItem(int courseId)
        {
            if (_pool.ContainsKey(courseId))
            {
                return _pool[courseId];
            }
            else
            {
                throw new InvalidOperationException("Invalid course id.");
            }
        }

        public bool LookupItemById(int courseId)
        {
            if (_pool.ContainsKey(courseId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNotEmpty()
        {
            if (_pool.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
