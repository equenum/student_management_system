using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class GroupIdentityMap : IIdentityMap<GroupModel>
    {
        private Dictionary<int, GroupModel> _pool = new Dictionary<int, GroupModel>();

        public void AddItem(GroupModel group)
        {
            if (_pool.ContainsKey(group.GroupId) == false)
            {
                _pool.Add(group.GroupId, group);
            }
        }

        public GroupModel GetItem(int groupId)
        {
            return _pool[groupId];
        }

        public bool LookupGroupByCourse(int courseId)
        {
            if (_pool.Any(x => x.Value.CourseId == courseId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LookupItemById(int groupId)
        {
            if (_pool.ContainsKey(groupId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
