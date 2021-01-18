using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystemLibrary.Repositories
{
    /// <summary>
    /// Represents a generic data connectioin which is responsible for handling the database connection.
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// Gets all data from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A list of all data from the database according to SQL-query provided.</returns>
        public List<T> GetData_All<T>(string sql);
        /// <summary>
        /// Gets data by id from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A list of data by id from the database according to SQL-query provided.</returns>
        public List<T> GetListData_ById<T>(string sql);
        /// <summary>
        /// Gets a single data record by id from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A single data record by id from the database according to SQL-query provided.</returns>
        public T GetSingleData_ById<T>(string sql);
        /// <summary>
        /// Updates data in the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        public void UpdateData<T>(string sql);
        /// <summary>
        /// Deletes data from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        public void DeleteData<T>(string sql);
    }
}
