using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Models
{
    /// <summary>
    /// Represents a student.
    /// </summary>
    public class StudentModel
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
