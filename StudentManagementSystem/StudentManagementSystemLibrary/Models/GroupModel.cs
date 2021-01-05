using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Models
{
    /// <summary>
    /// Represents a group, including a list of its students.
    /// </summary>
    public class GroupModel
    {
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
