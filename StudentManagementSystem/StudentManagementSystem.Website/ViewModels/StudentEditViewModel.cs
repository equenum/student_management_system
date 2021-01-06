using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class StudentEditViewModel
    {
        public int StudentId { get; set; } // delete all about group if not works
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
