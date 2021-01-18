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

            if (UOWManager.GroupUOW.LookupGroupsByCourse(courseId) == false)
            {
                if (UOWManager.GroupUOW.TryRegisterGroupsByCourse(courseId) == false)
                {
                    Response.StatusCode = 404;
                    return View("NotFound");
                }
            }

            groupViewModel.Groups = UOWManager.GroupUOW.GetGroupsByCourse(courseId);
            groupViewModel.CurrentCourseName = courseName;
            groupViewModel.CurrentCourseId = courseId;
          
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
                var groupUpdated = new GroupModel()
                {
                    GroupId = model.GroupId,
                    Name = model.GroupName,
                    CourseId = model.CourseId,
                    Students = UOWManager.StudentUOW.GetStudentsByGroup(model.GroupId)
                };

                UOWManager.GroupUOW.RegisterDirty(groupUpdated);
                UOWManager.GroupUOW.Commit();

                return RedirectToAction("GroupList", new { courseId = model.CourseId, courseName = model.CourseName });
            }

            return View(model);
        }

        public IActionResult GroupDelete(int groupId, int courseId, string courseName)
        {
            List<StudentModel> group = UOWManager.StudentUOW.GetStudentsByGroup(groupId);

            if (group.Count == 0)
            {
                var groupRemoved = new GroupModel() { GroupId = groupId };

                UOWManager.GroupUOW.RegisterRemoved(groupRemoved);
                UOWManager.GroupUOW.Commit();

                return RedirectToAction("GroupList", new { courseId = courseId, courseName = courseName });
            }

            return RedirectToAction("GroupList", new { courseId, courseName });
        }
    }
}
