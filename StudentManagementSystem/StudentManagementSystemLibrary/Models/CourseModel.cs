using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Models
{
    /// <summary>
    /// Represents a group, including a list of its groups.
    /// </summary>
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GroupModel> Groups { get; set; }
    }
}
