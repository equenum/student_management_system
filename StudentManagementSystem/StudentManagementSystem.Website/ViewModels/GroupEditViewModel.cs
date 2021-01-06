using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class GroupEditViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
