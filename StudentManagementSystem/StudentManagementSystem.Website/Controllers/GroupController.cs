using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.Models;
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
            groupViewModel.Groups = GlobalConfig.Repository.GetGroups_ByCourse(courseId);
            groupViewModel.CurrentCourseName = courseName;
            groupViewModel.CurrentCourseId = courseId;
            

            foreach (var group in groupViewModel.Groups)
            {
                group.Students = GlobalConfig.Repository.GetStudents_ByGroup(group.GroupId);
            }

            return View(groupViewModel);
        }

        public IActionResult GroupEdit(int groupId, string groupName, int courseId, string courseName) // Create Post version of this method
        {
            var groupEditViewModel = new GroupEditViewModel();
            groupEditViewModel.GroupId = groupId;
            groupEditViewModel.GroupName = groupName;
            groupEditViewModel.CourseId = courseId;
            groupEditViewModel.CourseName = courseName;

            return View(groupEditViewModel);
        }

        [HttpPost]
        public IActionResult GroupEdit(GroupEditViewModel model) // Try catch maybe?
        {
            GlobalConfig.Repository.UpdateGroupName(model.GroupId, model.GroupName);

            return RedirectToAction("GroupList", new { courseId = model.CourseId, courseName = model.CourseName });
        }

        public IActionResult GroupDelete(int groupId, int courseId, string courseName)
        {
            GlobalConfig.Repository.DeleteGroup(groupId);

            return RedirectToAction("GroupList", new { courseId = courseId, courseName = courseName });
        }
    }
}
