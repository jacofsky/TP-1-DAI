using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using TP_1_DAI.Models;

namespace TP_1_DAI.Utils
{
    
    public static class BD
    {
        private static string _connectionString = @"Server=DESKTOP-0TBIL3L\SQLEXPRESS;DataBase=DAI-Pizzas;Trusted_Connection=True";

        private static List<Pizza> _Pizzas = new List<Pizza>();

        public static List<Pizza> GetAllPizzas() {

            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "SELECT * FROM Pizzas";
                _Pizzas = db.Query<Pizza>(query).ToList();
            };

            return _Pizzas;
        }
    }
}

