using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    /// <summary>
    /// Represents a student identity map.
    /// </summary>
    public interface IStudentIdentityMap : IIdentityMap<StudentModel>
    {
        /// <summary>
        /// Looks up if the student entities from a given group already present in the identity map. 
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <returns></returns>
        public bool LookupStudentByGroup(int groupId);
    }
}
