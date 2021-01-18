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
        /// Represents a configuration for GetAppSettingsFile().
        /// </summary>
        private static IConfiguration _configuration;
        /// <summary>
        /// Represents current global SqlRepository.
        /// </summary>
        public static IDataConnection Connection;

        /// <summary>
        /// Initializes the database connection.
        /// </summary>
        public static void InitializeConnections()
        {
            Connection = new SqlServerRepository();
        }

        /// <summary>
        /// Gets an actual connection string line for a given appsettings.json connection string name.
        /// </summary>
        /// <param name="name">Appsettings.json connection string name.</param>
        /// <returns>An actual connection string line.</returns>
        public static string GetConnString(string name)
        {
            return _configuration.GetConnectionString(name);
        }

        /// <summary>
        /// Loads appsettings.json file contents.
        /// </summary>
        public static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }
    }
}
