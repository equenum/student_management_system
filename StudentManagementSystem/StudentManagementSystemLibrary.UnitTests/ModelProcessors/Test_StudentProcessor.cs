using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitTests.ModelProcessors
{
    [TestClass]
    public class Test_StudentProcessor
    {
        [DataRow("exec dbo.spStudents_GetAll;")]
        [DataTestMethod]
        public void GetStudents_All_ValidCall(string sql)
        {
            var sampleStudents = new ProcessorSampleData().GetSampleStudents();
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetData_All<StudentModel>(sql))
                    .Returns(sampleStudents);

                var studentProcessor = mock.Create<StudentProcessor>();

                var expected = sampleStudents;

                var actual = studentProcessor.GetStudents_All();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].FirstName, actual[i].FirstName);
                    Assert.AreEqual(expected[i].LastName, actual[i].LastName);
                }
            }
        }

        [DataRow(
            "exec dbo.spStudent_UpdateNameById @StudentId = 1, @UpdatedFirstName = 'TestFirstName', @UpdatedLastName = 'TestLastName' ;", 
            1, "TestFirstName", 
            "TestLastName")]
        [DataTestMethod]
        public void UpdateStudentName_ValidCall(string sql, int studentId, string updatedFirstName, string updatedLastName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>().Setup(x => x.UpdateData<StudentModel>(sql));

                var studentProcessor = mock.Create<StudentProcessor>();

                studentProcessor.UpdateStudent(studentId, updatedFirstName, updatedLastName);

                mock.Mock<IRepository>().Verify(x => x.UpdateData<StudentModel>(sql), Times.Exactly(1));
            }
        }

        [DataRow("exec dbo.spStudent_GetById @StudentId = 1 ;", 1)]
        [DataTestMethod]
        public void GetStudent_ById_ValidCall(string sql, int studentId)
        {
            var sampleStudent = new ProcessorSampleData().GetSampleStudent();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetSingleData_ById<StudentModel>(sql))
                    .Returns(sampleStudent);

                var studentProcessor = mock.Create<StudentProcessor>();

                var expected = sampleStudent;
                var actual = studentProcessor.GetStudent_ById(studentId);

                Assert.IsTrue(actual != null);

                Assert.AreEqual(expected.FirstName, actual.FirstName);
                Assert.AreEqual(expected.LastName, actual.LastName);
                Assert.AreEqual(expected.GroupId, actual.GroupId);
                Assert.AreEqual(expected.StudentId, actual.StudentId);
            }
        }
    }
}
