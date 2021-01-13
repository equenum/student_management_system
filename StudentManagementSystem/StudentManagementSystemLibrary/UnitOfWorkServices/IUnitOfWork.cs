using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    /// <summary>
    /// Represents a generic item unit of work.
    /// </summary>
    /// <typeparam name="T">Item class.</typeparam>
    public interface IUnitOfWork<T>
    {
        /// <summary>
        /// Registers a newly added item.
        /// </summary>
        /// <param name="model">Item class.</param>
        public void RegisterNew(T model);
        /// <summary>
        /// Registers a new updated item.
        /// </summary>
        /// <param name="model">Item class.</param>
        public void RegisterDirty(T model); 
        /// <summary>
        /// Registers a new removed item.
        /// </summary>
        /// <param name="model">Item class.</param>
        public void RegisterRemoved(T model);
        /// <summary>
        /// Commits all of the pending changes to the database.
        /// </summary>
        public void Commit();
    }
}
