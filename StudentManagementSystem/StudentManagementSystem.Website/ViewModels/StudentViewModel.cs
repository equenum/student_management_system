using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<StudentModel> Students { get; set; }
        public string CurrentGroupName { get; set; }
        public int CurrentGroupId { get; set; }
    }
}
