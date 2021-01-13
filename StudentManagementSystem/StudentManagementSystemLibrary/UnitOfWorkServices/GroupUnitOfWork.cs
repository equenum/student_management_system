using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public class GroupUnitOfWork : IUnitOfWork<GroupModel>
    {
        private IRepository _database;

        private readonly List<GroupModel> newGroups = new List<GroupModel>();
        private readonly List<GroupModel> removedGroups = new List<GroupModel>();
        private readonly List<GroupModel> dirtyGroups = new List<GroupModel>();

        public GroupUnitOfWork(IRepository repository)
        {
            _database = repository;
        }

        public void RegisterNew(GroupModel group)
        {
            if (group.GroupId == 0 && !newGroups.Contains(group) && !newGroups.Contains(group) && !newGroups.Contains(group))
            {
                newGroups.Add(group);
            }
            else
            {
                throw new InvalidOperationException("Invalid group id.");
            }
        }

        public void RegisterDirty(GroupModel group)
        {
            if (group.GroupId != 0 && !newGroups.Contains(group) && !newGroups.Contains(group) && !newGroups.Contains(group))
            {
                dirtyGroups.Add(group);
            }
            else
            {
                throw new InvalidOperationException("Invalid group id.");
            }
        }

        public void RegisterRemoved(GroupModel group)
        {
            bool removedFromNew = newGroups.Remove(group);

            if (!removedFromNew)
            {
                dirtyGroups.Remove(group);

                if (group.GroupId != 0 && !removedGroups.Contains(group))
                {
                    removedGroups.Add(group);
                }
                else
                {
                    throw new InvalidOperationException("Invalid group id.");
                }
            }
        }

        public void Commit()
        {
            InsertNew();
            UpdateDirty();
            DeleteRemoved();
        }

        /// <summary>
        /// Inserts all of the objects which, were flagged as "new", to the database.
        /// </summary>
        private void InsertNew()
        {
            if (newGroups.Count > 0)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Updates all of the objects which, were flagged as "dirty", in the database.
        /// </summary>
        private void UpdateDirty()
        {
            if (dirtyGroups.Count > 0)
            {
                foreach (var group in dirtyGroups)
                {
                    UpdateGroup(group.GroupId, group.Name);
                }

                dirtyGroups.Clear();
            }
        }

        /// <summary>
        /// Deletes all of the objects which, were flagged as "removed", from the database.
        /// </summary>
        private void DeleteRemoved()
        {
            if (removedGroups.Count > 0)
            {
                foreach (var group in removedGroups)
                {
                    DeleteGroup(group.GroupId);
                }
            }

            removedGroups.Clear();
        }

        /// <summary>
        /// Updates name for the group specified by id.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="updatedName">Updated (new) name for the group.</param>
        private void UpdateGroup(int groupId, string updatedName)
        {
            string sql = "exec dbo.spGroup_UpdateNameById @GroupId = GROUP_ID, @UpdatedName = UPDATED_NAME ; ";

            sql = sql.Replace("GROUP_ID", $"{ groupId }");
            sql = sql.Replace("UPDATED_NAME", $"'{ updatedName }'");

            _database.UpdateData<GroupModel>(sql);
        }

        /// <summary>
        /// Deletes the group specified by id from the database.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        private void DeleteGroup(int groupId)
        {
            string sql = "exec dbo.spGroup_DeleteById @GroupId = GROUD_ID ;";

            sql = sql.Replace("GROUD_ID", $"{ groupId }");

            _database.DeleteData<GroupModel>(sql);
        }
    }
}
