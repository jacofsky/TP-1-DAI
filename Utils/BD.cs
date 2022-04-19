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
       private static string _connectionString = ConfigurationHelper.GetConfiguration()["DatabaseSettings:ConnectionString"];

        public static SqlConnection GetSqlConnection() {

            try
            {
                return new SqlConnection(_connectionString);
                
            }
            catch (System.Exception)
            {
                throw;
            }
            

        }

    }
}

