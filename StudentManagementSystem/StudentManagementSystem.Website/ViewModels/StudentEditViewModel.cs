using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.ViewModels
{
    public class StudentEditViewModel
    {
        public int StudentId { get; set; }

        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Invalid input format.")]
        [Required(ErrorMessage = "Required field." ), MaxLength(30)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[_A-z]*((-)*[_A-z])*$", ErrorMessage = "Invalid input format.")]
        [Required(ErrorMessage = "Required field."), MaxLength(30)]
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
