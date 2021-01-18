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
    public class SqlServerRepository : IDataConnection
    {
        public readonly string connStringName = "SqlServer";
        
        public List<T> GetData_All<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var output = connection.Query<T>(sql, new DynamicParameters());

                return output.ToList();
            }
        }
       
        public List<T> GetListData_ById<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                var output = connection.Query<T>(sql, new DynamicParameters());

                return output.ToList();
            }
        }
        
        public void UpdateData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                connection.Execute(sql);
            }
        }
        
        public void DeleteData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.GetConnString(connStringName)))
            {
                connection.Execute(sql);
            }
        }
        
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
