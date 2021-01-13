using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.UnitOfWorkServices
{
    public interface IUnitOfWork<T>
    {
        public void RegisterNew(T model);
        public void RegisterDirty(T model); 
        public void RegisterRemoved(T model);
        public void Commit();
    }
}
