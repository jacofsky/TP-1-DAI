using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using TP_1_DAI.Models;
using TP_1_DAI.Utils;
using TP_1_DAI.Services;
using TP_1_DAI.Helpers;

namespace TP_1_DAI.Services
{

    public static class PizzaServices
    {
        
        public static List<Pizza> GetAllPizzas() {

            List<Pizza> _Pizzas = new List<Pizza>();
            using(SqlConnection db = BD.GetSqlConnection()){
                string query = "SELECT * FROM Pizzas";
                _Pizzas = db.Query<Pizza>(query).ToList();
            };

            return _Pizzas;
        }

        public static Pizza GetPizzaById(int ID) {
            
            Pizza pizza = null;

            using(SqlConnection db = BD.GetSqlConnection()){
                string query = "SELECT * FROM Pizzas WHERE Id = @ID";
                pizza = db.QueryFirstOrDefault<Pizza>(query, new {ID});
            };

            return pizza;
        }

        public static int CreatePizza(Pizza pizza, string token) {
            
            int count = 0;
            int id = -2;

            bool validToken = SecurityHelper.IsValidToken(token);

            if(validToken == true){

                using(SqlConnection db = BD.GetSqlConnection()){
                    string query = "INSERT INTO Pizzas VALUES (@Nombre, @LibreDeGluten, @Importe, @Descripcion) SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    count = db.Execute(query, new {Nombre = pizza.Nombre, LibreDeGluten = pizza.LibreDeGluten, Importe = pizza.Importe, Descripcion = pizza.Descripcion});
                    id = db.QuerySingle<int>(query, new {Nombre = pizza.Nombre, LibreDeGluten = pizza.LibreDeGluten, Importe = pizza.Importe, Descripcion = pizza.Descripcion});
                };

                return id;
            }

            return -1;

        }

        public static int UpdatePizza(int ID, Pizza pizza, string token) {
            
            int count = 0;

            bool validToken = SecurityHelper.IsValidToken(token);

            if(validToken == true){
                
                using(SqlConnection db = BD.GetSqlConnection()){
                string query = "UPDATE Pizzas SET Nombre = @Nombre, LibreGluten = @LibreDeGluten, Importe = @Importe, Descripcion = @Descripcion WHERE id = @ID";
                count = db.Execute(query, new {Nombre = pizza.Nombre, LibreDeGluten = pizza.LibreDeGluten, Importe = pizza.Importe, Descripcion = pizza.Descripcion, ID});
                };

                return count;
                
            }

            return -1;
            
        }

        public static int DeletePizza(int ID, string token) {
            
            int count = 0;

            bool validToken = SecurityHelper.IsValidToken(token);


            if(validToken == true) {
                using(SqlConnection db = BD.GetSqlConnection()){
                    string query = "DELETE FROM Pizzas WHERE Id = @ID";
                    count = db.Execute(query, new {ID});
                }
                return count;
            }

            return -2;
            
        }

    }

}