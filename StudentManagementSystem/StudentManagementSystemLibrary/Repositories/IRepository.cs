using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Repositories
{
    /// <summary>
    /// Represents a repository which is responsible for handling the database connection.
    /// </summary>
    public interface IRepository
    {
        public List<T> GetData_All<T>(string sql);
        public List<T> GetListData_ById<T>(string sql);
        public T GetSingleData_ById<T>(string sql);
        public void UpdateData<T>(string sql);
        public void DeleteData<T>(string sql);
    }
}
