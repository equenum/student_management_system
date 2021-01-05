using Microsoft.Extensions.Configuration;
using StudentManagementSystemLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentManagementSystemLibrary
{
    /// <summary>
    /// Represents a globally accessible class, which contains  settings, information and methods related to database connection.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Represents current repository.
        /// </summary>
        public static IRepository Repository { get; private set; }
        /// <summary>
        /// Represent current configurations. This property is used to get a database connection string.
        /// </summary>
        private static IConfiguration _configuration;

        /// <summary>
        /// Initializes current repository according to the provided repository type. 
        /// This method should be called in order to use this library.
        /// </summary>
        /// <param name="repositoryType">Current repository type.</param>
        public static void InitializeConnections(RepositoryTypes repositoryType)
        {
            if (repositoryType == RepositoryTypes.SqlServerRepository)
            {
                var sql = new SqlServerRepository();
                Repository = sql;
            }
            // Add new conditions in case of new repositories.
        }

        public static string GetConnString(string name) // TODO - Comment this if it is still used.
        {
            return _configuration.GetConnectionString(name);
        }

        public static void GetAppSettingsFile() // TODO - Comment this if it is still used as well.
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }
    }
}
