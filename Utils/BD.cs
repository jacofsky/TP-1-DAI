using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration; 

using TP_1_DAI.Helpers;
using TP_1_DAI.Models;

namespace TP_1_DAI.Utils
{
    
    public static class BD
    {
       private static string _connectionString = ConfigurationHelper.GetConfiguration().GetValue<string>("DatabaseSettings:ConnectionString");

        public static SqlConnection GetSqlConnection() {
            
            return new SqlConnection(_connectionString);

        }

    }
}

