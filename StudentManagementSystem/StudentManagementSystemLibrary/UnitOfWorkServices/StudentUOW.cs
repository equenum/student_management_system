using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public class StudentUOW : IStudentUOW
    {
        private IStudentRepository _repository;
        private IIdentityMap<StudentModel> _clean;
        private IIdentityMap<StudentModel> _dirty;
        private IIdentityMap<StudentModel> _removed;

        public StudentUOW(IDataConnection connection)
        {
            _repository = new StudentRepository(connection);
            _clean = new StudentIdentityMap();
            _dirty = new StudentIdentityMap();
            _removed = new StudentIdentityMap();
        }

        public void RegisterDirty(StudentModel student)
        {
            List<StudentModel> currRemoved = _removed.GetAll();

            if (student.StudentId != 0 && !currRemoved.Contains(student))
            {
                _clean.Remove(student);
                _dirty.Add(student);
            }
            else
            {
                throw new InvalidOperationException("Invalid student id.");
            }
        }

        public void RegisterRemoved(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            Update();
        }

        /// <summary>
        /// Updates all of the objects in the database, which were flagged as "dirty".
        /// </summary>
        private void Update()
        {
            List<StudentModel> currDirty = _dirty.GetAll();

            if (currDirty.Count > 0)
            {
                foreach (var student in currDirty)
                {
                    _repository.UpdateStudent(student.StudentId, student.FirstName, student.LastName);
                    _clean.Add(student);
                }

                _dirty.Clean();
            }
        }

        public bool LookupStudentById(int studentId)
        {
            StudentModel student = _clean.GetAll().Where(x => x.StudentId == studentId).First();

            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LookupStudentsByGroup(int groupId)
        {
            List<StudentModel> students = _clean.GetAll().Where(x => x.GroupId == groupId).ToList();

            if (students.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRegisterStudentById(int studentId)
        {
            StudentModel student = _repository.GetStudent_ById(studentId);

            if (student != null)
            {
                _clean.Add(student);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRegisterStudentsByGroup(int groudId)
        {
            List<StudentModel> students = _repository.GetStudents_ByGroup(groudId);

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    _clean.Add(student);
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        public StudentModel GetStudentById(int studentId)
        {
            return _clean.GetAll().Where(x => x.StudentId == studentId).First();
        }

        public List<StudentModel> GetStudentsByGroup(int groudId)
        {
            return _clean.GetAll().Where(x => x.GroupId == groudId).ToList();
        }
    }
}
