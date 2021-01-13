using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.UnitOfWorkServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult GroupList(int courseId, string courseName)
        {
            var groupViewModel = new GroupViewModel();

            if (CacheManager.GroupIdentityMap.LookupGroupByCourse(courseId) == false)
            {
                List<GroupModel> tempList = new GroupProcessor(GlobalConfig.SqlRepository).GetGroups_ByCourse(courseId);

                foreach (var group in tempList)
                {
                    CacheManager.GroupCache.Add(group);
                }
            }

            groupViewModel.Groups = CacheManager.GroupCache.Where(x => x.CourseId == courseId).ToList();
            
            groupViewModel.CurrentCourseName = courseName;
            groupViewModel.CurrentCourseId = courseId;

            foreach (var group in groupViewModel.Groups)
            {
                if (CacheManager.StudentIdentityMap.LookupStudentByGroup(group.GroupId) == false)
                {
                    List<StudentModel> tempList = new StudentProcessor(GlobalConfig.SqlRepository).GetStudents_ByGroup(group.GroupId);

                    foreach (var student in tempList)
                    {
                        CacheManager.StudentCache.Add(student);
                    }
                }

                group.Students = CacheManager.StudentCache.Where(x => x.GroupId == group.GroupId).ToList();
            }

            return View(groupViewModel);
        }

        public IActionResult GroupEdit(int groupId, string groupName, int courseId, string courseName) 
        {
            var groupEditViewModel = new GroupEditViewModel();
            groupEditViewModel.GroupId = groupId;
            groupEditViewModel.GroupName = groupName;
            groupEditViewModel.CourseId = courseId;
            groupEditViewModel.CourseName = courseName;

            return View(groupEditViewModel);
        }

        [HttpPost]
        public IActionResult GroupEdit(GroupEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var groupUpdated = new GroupModel() { GroupId = model.GroupId, Name = model.GroupName };
               
                var guow = new GroupUnitOfWork(GlobalConfig.SqlRepository);
                guow.RegisterDirty(groupUpdated);
                guow.Commit();

                CacheManager.GroupCache.Where(x => x.GroupId == groupUpdated.GroupId).First().Name = groupUpdated.Name;
                
                return RedirectToAction("GroupList", new { courseId = model.CourseId, courseName = model.CourseName });
            }

            return View(model);
        }

        public IActionResult GroupDelete(int groupId, int courseId, string courseName)
        {
            List<StudentModel> group = CacheManager.StudentCache.Where(x => x.GroupId == groupId).ToList();

            if (group.Count == 0)
            {
                var groupRemoved = new GroupModel() { GroupId = groupId };
                
                var guow = new GroupUnitOfWork(GlobalConfig.SqlRepository);
                guow.RegisterRemoved(groupRemoved);
                guow.Commit();

                var tempRemovedGroup = CacheManager.GroupCache.Where(x => x.GroupId == groupRemoved.GroupId).First();
                CacheManager.GroupCache.Remove(tempRemovedGroup);

                return RedirectToAction("GroupList", new { courseId = courseId, courseName = courseName });
            }

            return RedirectToAction("GroupList", new { courseId, courseName });
        }
    }
}
