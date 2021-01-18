using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public class CourseUOW : ICourseUOW
    {
        private ICourseRepository _repository;
        private IIdentityMap<CourseModel> _clean;
        private IIdentityMap<CourseModel> _dirty;
        private IIdentityMap<CourseModel> _removed;

        public CourseUOW(IDataConnection connection)
        {
            _repository = new CourseRepository(connection);
            _clean = new CourseIdentityMap();
            _dirty = new CourseIdentityMap();
            _removed = new CourseIdentityMap();
        }

        public void RegisterDirty(CourseModel course)
        {
            throw new NotImplementedException();
        }

        public void RegisterRemoved(CourseModel course)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            Update();
            Delete();
        }

        /// <summary>
        /// Updates all of the objects in the database, which were flagged as "dirty".
        /// </summary>
        private void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleted all of the object from the database, which were flagged as "removed".
        /// </summary>
        private void Delete()
        {
            throw new NotImplementedException();
        }

        public bool LookupCourseById(int courseId)
        {
            CourseModel course = _clean.GetAll().Where(X => X.CourseId == courseId).First();

            if (course == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LookupCourses()
        {
            List<CourseModel> courses = _clean.GetAll();

            if (courses.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRegisterCoursesAll()
        {
            List<CourseModel> courses = _repository.GetCourses_All();

            if (courses.Count > 0)
            {
                foreach (var course in courses)
                {
                    if (UOWManager.GroupUOW.LookupGroupsByCourse(course.CourseId) == false)
                    {
                        if (UOWManager.GroupUOW.TryRegisterGroupsByCourse(course.CourseId) == false)
                        {
                            return false;
                        }
                    }

                    course.Groups = UOWManager.GroupUOW.GetGroupsByCourse(course.CourseId);
                    _clean.Add(course);
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        public List<CourseModel> GetCoursesAll()
        {
            return _clean.GetAll();
        }
    }
}
