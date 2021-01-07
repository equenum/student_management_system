using Dapper;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentManagementSystemLibrary.Repositories
{
    public class SqlServerRepository : IRepository
    {
        private readonly string connStringName = "SqlServer";

        /// <summary>
        /// Gets all data from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A list of all data from the database according to SQL-query provided.</returns>
        public List<T> GetData_All<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var output = connection.Query<T>(sql, new DynamicParameters());

                return output.ToList();
            }
        }

        /// <summary>
        /// Gets data by id from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A list of data by id from the database according to SQL-query provided.</returns>
        public List<T> GetListData_ById<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var output = connection.Query<T>(sql, new DynamicParameters());

                return output.ToList();
            }
        }

        /// <summary>
        /// Updates data in the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        public void UpdateData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                connection.Execute(sql);
            }
        }

        /// <summary>
        /// Deletes data from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        public void DeleteData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                connection.Execute(sql);
            }
        }

        /// <summary>
        /// Gets a single data record by id from the database according to SQL-query provided.
        /// </summary>
        /// <typeparam name="T">Object of interest class.</typeparam>
        /// <param name="sql">SQL-query.</param>
        /// <returns>A single data record by id from the database according to SQL-query provided.</returns>
        public T GetSingleData_ById<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var output = connection.Query<T>(sql, new DynamicParameters());

                return output.First();
            }
        }
    }
}
