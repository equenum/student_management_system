using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<GroupModel> Groups { get; set; }
        public int CurrentCourseId { get; set; }
        public string CurrentCourseName { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
    }
}
