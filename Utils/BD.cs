using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using TP_1_DAI.Models;

namespace TP_1_DAI.Utils
{
    
    public static class BD
    {
        private static string _connectionString = "Persist Security Info=False;User ID=Pizzas;password=Pizzas;Initial Catalog=DAI-Pizzas;Data Source=.;";

        public static SqlConnection GetSqlConnection() {
            
            return new SqlConnection(_connectionString);

        }

    }
}

