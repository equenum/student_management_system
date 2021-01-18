using StudentManagementSystemLibrary.IdentityMapServices;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public class GroupUOW : IGroupUOW
    {
        private IGroupRepository _repository;
        private IIdentityMap<GroupModel> _clean;
        private IIdentityMap<GroupModel> _dirty;
        private IIdentityMap<GroupModel> _removed;

        public GroupUOW(IDataConnection connection)
        {
            _repository = new GroupRepository(connection);
            _clean = new GroupIdentityMap();
            _dirty = new GroupIdentityMap();
            _removed = new GroupIdentityMap();
        }

        public void RegisterDirty(GroupModel group)
        {
            List<GroupModel> currRemoved = _removed.GetAll();

            if (group.GroupId != 0 && !currRemoved.Contains(group))
            {
                _clean.Remove(group);
                _dirty.Add(group);
            }
            else
            {
                throw new InvalidOperationException("Invalid group id.");
            }
        }

        public void RegisterRemoved(GroupModel group)
        {
            List<GroupModel> currDirty = _dirty.GetAll();

            if (currDirty.Contains(group))
            {
                _dirty.Remove(group);
            }

            if (group.GroupId != 0)
            {
                _removed.Add(group);
            }
            else
            {
                throw new InvalidOperationException("Invalid group id.");
            }
        }

        public void Commit()
        {
            Update();
            Delete();
        }

        /// <summary>
        /// Updates all of the objects in the database, which were flagged as "dirty".
        /// </summary>
        private void Update()
        {
            List<GroupModel> currDirty = _dirty.GetAll();

            if (currDirty.Count > 0)
            {
                foreach (var group in currDirty)
                {
                    _repository.UpdateGroupName(group.GroupId, group.Name);
                    _clean.Add(group);
                }

                _dirty.Clean();
            }
        }

        /// <summary>
        /// Deleted all of the object from the database, which were flagged as "removed".
        /// </summary>
        private void Delete()
        {
            List<GroupModel> currRemoved = _removed.GetAll();

            if (currRemoved.Count > 0)
            {
                foreach (var group in currRemoved)
                {
                    _repository.DeleteGroup(group.GroupId);
                    _clean.Remove(group);
                }

                _removed.Clean();
            }
        }

        public bool LookupGroupById(int groupId)
        {
            GroupModel group = _clean.GetAll().Where(x => x.GroupId == groupId).First();

            if (group == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LookupGroupsByCourse(int courseId)
        {
            List<GroupModel> groups = _clean.GetAll().Where(x => x.CourseId == courseId).ToList();

            if (groups.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRegisterGroupsByCourse(int courseId)
        {
            List<GroupModel> groups = _repository.GetGroups_ByCourse(courseId);

            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    if (UOWManager.StudentUOW.LookupStudentsByGroup(group.GroupId) == false)
                    {
                        if (UOWManager.StudentUOW.TryRegisterStudentsByGroup(group.GroupId) == false)
                        {
                            return false;
                        }
                    }

                    group.Students = UOWManager.StudentUOW.GetStudentsByGroup(group.GroupId);
                    _clean.Add(group);
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        public List<GroupModel> GetGroupsByCourse(int courseId)
        {
            return _clean.GetAll().Where(x => x.CourseId == courseId).ToList();
        }
    }
}
