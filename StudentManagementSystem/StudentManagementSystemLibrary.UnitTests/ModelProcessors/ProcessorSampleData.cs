using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitTests.ModelProcessors
{
    public class ProcessorSampleData
    {
        public List<CourseModel> GetSampleCources()
        {
            var output = new List<CourseModel>
            {
                new CourseModel { CourseId = 1, Name = "CourseOne", Description = "TestDescriptionOne" },
                new CourseModel { CourseId = 2, Name = "CourseTwo", Description = "TestDescriptionTwo" }
            };

            return output;
        }

        public List<GroupModel> GetSampleGroups()
        {
            List<GroupModel> output = new List<GroupModel>
            {
                new GroupModel { GroupId = 1, CourseId = 1, Name = "GroupOne" },
                new GroupModel { GroupId = 2, CourseId = 2, Name = "GroupTwo" }
            };

            return output;
        }

        public List<StudentModel> GetSampleStudents()
        {
            List<StudentModel> output = new List<StudentModel>
            {
                new StudentModel { FirstName = "Bob", LastName = "Smith", GroupId = 1, StudentId = 1 },
                new StudentModel { FirstName = "Alex", LastName = "White", GroupId = 2, StudentId = 2 },
            };

            return output;
        }

        public StudentModel GetSampleStudent()
        {
            return new StudentModel { FirstName = "Bob", LastName = "Smith", GroupId = 1, StudentId = 1 };
        }
    }
}
