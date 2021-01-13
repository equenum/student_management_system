using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using StudentManagementSystemLibrary.UnitOfWorkServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitTests.UnitsOfWork
{
    [TestClass]
    public class Test_StudentUnitOfWork
    {
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

                StudentUnitOfWork suof = mock.Create<StudentUnitOfWork>();
                suof.RegisterDirty(new StudentModel() { FirstName = updatedFirstName, LastName = updatedLastName, GroupId = 1, StudentId = 1 });
                suof.Commit();

                mock.Mock<IRepository>().Verify(x => x.UpdateData<StudentModel>(sql), Times.Exactly(1));
            }
        }
    }
}
