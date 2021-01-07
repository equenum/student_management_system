﻿using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitTests.ModelProcessors
{
    [TestClass]
    public class Test_CourseProcessor
    {
        [DataRow("exec dbo.spCourses_GetAll ;")]
        [DataTestMethod]
        public void GetCourses_All_ValidCall(string sql)
        {
            var sampleCourses = new ProcessorSampleData().GetSampleCources();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetData_All<CourseModel>(sql))
                    .Returns(sampleCourses);

                var courseProcessor = mock.Create<CourseProcessor>();

                var expected = sampleCourses;

                var actual = courseProcessor.GetCourses_All();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].CourseId, actual[i].CourseId);
                    Assert.AreEqual(expected[i].Name, actual[i].Name);
                    Assert.AreEqual(expected[i].Description, actual[i].Description);
                }
            }
        }

        [DataRow("exec dbo.spGroups_GetByCourse @CourseId = 1 ;", 1)]
        [DataTestMethod]
        public void GetGroups_ByCourse_ValidCall(string sql, int courseId)
        {
            var sampleGroups = new ProcessorSampleData().GetSampleGroups();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetListData_ById<GroupModel>(sql))
                    .Returns(sampleGroups);

                var courseProcessor = mock.Create<CourseProcessor>();

                var expected = sampleGroups;

                var actual = courseProcessor.GetGroups_ByCourse(courseId);

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].GroupId, actual[i].GroupId);
                    Assert.AreEqual(expected[i].CourseId, actual[i].CourseId);
                    Assert.AreEqual(expected[i].Name, actual[i].Name);
                }
            }
        }

        [DataRow("exec dbo.spStudents_GetByGroup @GroupId = 1 ;", 1)]
        [DataTestMethod]
        public void GetStudents_ByGroup_ValidCall(string sql, int groupId)
        {
            var sampleStudents = new ProcessorSampleData().GetSampleStudents();

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepository>()
                    .Setup(x => x.GetListData_ById<StudentModel>(sql))
                    .Returns(sampleStudents);

                var courseProcessor = mock.Create<CourseProcessor>();

                var expected = sampleStudents;
                var actual = courseProcessor.GetStudents_ByGroup(groupId);

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].FirstName, actual[i].FirstName);
                    Assert.AreEqual(expected[i].LastName, actual[i].LastName);
                    Assert.AreEqual(expected[i].GroupId, actual[i].GroupId);
                    Assert.AreEqual(expected[i].StudentId, actual[i].StudentId);
                }
            }
        }
    }
}
