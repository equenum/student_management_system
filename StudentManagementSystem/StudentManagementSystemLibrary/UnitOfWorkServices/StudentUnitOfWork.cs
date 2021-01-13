using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public class StudentUnitOfWork : IUnitOfWork<StudentModel>
    {
        private IRepository _database;

        private readonly List<StudentModel> newStudents = new List<StudentModel>();
        private readonly List<StudentModel> removedStudents = new List<StudentModel>();
        private readonly List<StudentModel> dirtyStudents = new List<StudentModel>();

        public StudentUnitOfWork(IRepository repository)
        {
            _database = repository;
        }

        public void RegisterNew(StudentModel student)
        {
            if (student.StudentId == 0 && !newStudents.Contains(student) && !removedStudents.Contains(student) && !dirtyStudents.Contains(student))
            {
                newStudents.Add(student);
            }
            else
            {
                throw new InvalidOperationException("Invalid student id.");
            }
        }

        public void RegisterDirty(StudentModel student)
        {
            if (student.StudentId != 0 && !newStudents.Contains(student) && !removedStudents.Contains(student) && !dirtyStudents.Contains(student))
            {
                dirtyStudents.Add(student);
            }
            else
            {
                throw new InvalidOperationException("Invalid student id.");
            }
        }

        public void RegisterRemoved(StudentModel student)
        {
            bool removedFromNew = newStudents.Remove(student);
            
            if (!removedFromNew)
            {
                dirtyStudents.Remove(student);

                if (student.StudentId != 0 && !removedStudents.Contains(student))
                {
                    removedStudents.Add(student);
                }
                else
                {
                    throw new InvalidOperationException("Invalid student id.");
                }
            }
        } 

        public void Commit()
        {
            InsertNew();
            UpdateDirty();
            DeleteRemoved();
        }

        /// <summary>
        /// Inserts all of the objects which, were flagged as "new", to the database.
        /// </summary>
        private void InsertNew()
        {
            if (newStudents.Count > 0)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates all of the objects which, were flagged as "dirty", in the database.
        /// </summary>
        private void UpdateDirty() 
        {
            if (dirtyStudents.Count > 0)
            {
                foreach (var student in dirtyStudents)
                {
                    UpdateStudent(student.StudentId, student.FirstName, student.LastName);
                }

                dirtyStudents.Clear();
            }
        }

        /// <summary>
        /// Deletes all of the objects which, were flagged as "removed", from the database.
        /// </summary>
        private void DeleteRemoved()
        {
            if (removedStudents.Count > 0)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates first and second names for the student specified by id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <param name="updatedFirstName">Updated (new) first name for the student.</param>
        /// <param name="updatedLastName">Updated (new) last name for the student.</param>
        private void UpdateStudent(int studentId, string updatedFirstName, string updatedLastName)
        {
            string sql = "exec dbo.spStudent_UpdateNameById " +
                "@StudentId = STUDENT_ID, " +
                "@UpdatedFirstName = UPDATED_FIRST_NAME, " +
                "@UpdatedLastName = UPDATED_LAST_NAME ;";

            sql = sql.Replace("STUDENT_ID", $"{ studentId }");
            sql = sql.Replace("UPDATED_FIRST_NAME", $"'{ updatedFirstName }'");
            sql = sql.Replace("UPDATED_LAST_NAME", $"'{ updatedLastName }'");

            _database.UpdateData<StudentModel>(sql);
        }
    }
}
