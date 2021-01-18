using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class GroupEditViewModel
    {
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Required field."), MaxLength(20)]
        public string GroupName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
