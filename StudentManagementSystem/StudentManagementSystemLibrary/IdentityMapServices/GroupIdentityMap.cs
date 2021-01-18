using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public class GroupIdentityMap : IIdentityMap<GroupModel>
    {
        private readonly object _poolLock = new object();
        private Dictionary<int, GroupModel> _pool = new Dictionary<int, GroupModel>();

        public void Add(GroupModel group)
        {
            lock (_poolLock)
            {
                _pool.Add(group.GroupId, group);
            }
        }

        public void Remove(GroupModel group)
        {
            lock (_poolLock)
            {
                if (_pool.ContainsKey(group.GroupId))
                {
                    _pool.Remove(group.GroupId);
                }
            }
        }

        public void Clean()
        {
            lock (_poolLock)
            {
                _pool.Clear();
            }
        }

        public List<GroupModel> GetAll()
        {
            lock (_poolLock)
            {
                return _pool.Select(x => x.Value).ToList();
            }
        }
    }
}
