using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    /// <summary>
    /// Represents a generic identity map.
    /// </summary>
    /// <typeparam name="T">Identity map class.</typeparam>
    public interface IIdentityMap<T>
    {
        /// <summary>
        /// Add item to the identity map.
        /// </summary>
        /// <param name="model">Item class.</param>
        public void Add(T model);
        /// <summary>
        /// Removes the specified item from identity map.
        /// </summary>
        /// <param name="model">Item class object.</param>
        public void Remove(T model);
        /// <summary>
        /// Removes all items from the identity map.
        /// </summary>
        public void Clean();
        /// <summary>
        /// Gets all items from the identity map.
        /// </summary>
        /// <returns>All item objects.</returns>
        public List<T> GetAll();
    }
}