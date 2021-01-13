using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    /// <summary>
    /// Represents a group identity map.
    /// </summary>
    public interface IGroupIdentityMap : IIdentityMap<GroupModel>
    {
        /// <summary>
        /// Looks up if the group entities from a given course already present in the identity map.
        /// </summary>
        /// <param name="courseId">Course id.</param>
        /// <returns></returns>
        public bool LookupGroupByCourse(int courseId);
    }
}
