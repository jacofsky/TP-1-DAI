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

        public static List<Pizza> GetAllPizzas() {

            List<Pizza> _Pizzas = new List<Pizza>();
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "SELECT * FROM Pizzas";
                _Pizzas = db.Query<Pizza>(query).ToList();
            };

            return _Pizzas;
        }

        public static Pizza GetPizzaById(int ID) {
            
            Pizza pizza = null;

            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "SELECT * FROM Pizzas WHERE Id = @ID";
                pizza = db.QueryFirstOrDefault<Pizza>(query, new {ID});
            };

            return pizza;
        }

        public static int CreatePizza(Pizza pizza) {
            
            int count = 0;

            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "INSERT INTO Pizzas VALUES (@Nombre, @LibreDeGluten, @Importe, @Descripcion)";
                count = db.Execute(query, new {Nombre = pizza.Nombre, LibreDeGluten = pizza.LibreDeGluten, Importe = pizza.Importe, Descripcion = pizza.Descripcion});
            };

            return count;
        }

        public static int UpdatePizza(int ID, Pizza pizza) {
            
            int count = 0;

            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "UPDATE Pizzas SET Nombre = @Nombre, LibreGluten = @LibreDeGluten, Importe = @Importe, Descripcion = @Descripcion WHERE id = @ID";
                count = db.Execute(query, new {Nombre = pizza.Nombre, LibreDeGluten = pizza.LibreDeGluten, Importe = pizza.Importe, Descripcion = pizza.Descripcion, ID});
            };

            return count;
        }

        public static int DeletePizza(int ID) {
            
            int count = 0;

            using(SqlConnection db = new SqlConnection(_connectionString)){
                string query = "DELETE FROM Pizzas WHERE Id = @ID";
                count = db.Execute(query, new {ID});
            }
            return count;
        }
    }
}

