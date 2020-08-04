using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DVDWebApi.Models
{
    public class Settings
    {
        private static string _repoName;
        private static string _connectionString;

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repoName))
                _repoName = ConfigurationManager.AppSettings["Mode"].ToString();

            return _repoName;
        }
        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.AppSettings["Mode"].ToString();

            return _connectionString;
        }


    }
}