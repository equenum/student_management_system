using StudentManagementSystemLibrary.Models;
using System.Collections.Generic;

namespace StudentManagementSystemLibrary.IdentityMapServices
{
    public interface IIdentityMap<T>
    {
        void AddItem(T model);
        T GetItem(int itemId);
        bool LookupItemById(int itemId);
    }
}