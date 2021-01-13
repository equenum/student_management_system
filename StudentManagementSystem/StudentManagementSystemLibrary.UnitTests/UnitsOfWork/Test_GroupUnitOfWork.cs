using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using StudentManagementSystemLibrary.UnitOfWorkServices;
using StudentManagementSystemLibrary.UnitTests.ModelProcessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitTests.UnitsOfWork
{
    [TestClass]
    public class Test_GroupUnitOfWork
    {
        [DataRow("exec dbo.spGroup_UpdateNameById @GroupId = 1, @UpdatedName = 'TestName' ; ", 1, "TestName")]
        [DataTestMethod]
        public void Commit_UpdateGroup_ValidCall(string sql, int groupId, string updatedGroupName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>().Setup(x => x.UpdateData<GroupModel>(sql));
                
                GroupUnitOfWork guof = mock.Create<GroupUnitOfWork>();

                guof.RegisterDirty(new GroupModel() { CourseId = 1, GroupId = groupId, Name = updatedGroupName, Students = new ProcessorSampleData().GetSampleStudents() });
                guof.Commit();

                mock.Mock<IRepository>().Verify(x => x.UpdateData<GroupModel>(sql), Times.Exactly(1));
            }
        }

        [DataRow("exec dbo.spGroup_DeleteById @GroupId = 1 ;")]
        [DataTestMethod]
        public void Commit_DeleteGroup_ValidCall(string sql)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>().Setup(x => x.DeleteData<GroupModel>(sql));

                GroupUnitOfWork guof = mock.Create<GroupUnitOfWork>();

                guof.RegisterRemoved(new GroupModel() { CourseId = 1, GroupId = 1, Name = "TestName", Students = new ProcessorSampleData().GetSampleStudents() });
                guof.Commit();

                mock.Mock<IRepository>().Verify(x => x.DeleteData<GroupModel>(sql), Times.Exactly(1));
            }
        }
    }
}
