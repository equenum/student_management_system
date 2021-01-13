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
        void AddItem(T model);
        /// <summary>
        /// Get item from the identity map by id.
        /// </summary>
        /// <param name="itemId">Item id.</param>
        /// <returns>Item object.</returns>
        T GetItem(int itemId);
        /// <summary>
        /// Looks up if the item entity specified by id already present in the identity map.
        /// </summary>
        /// <param name="itemId">Item id.</param>
        /// <returns>Item object.</returns>
        bool LookupItemById(int itemId);
    }
}