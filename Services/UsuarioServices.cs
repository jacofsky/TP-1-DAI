using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using TP_1_DAI.Models;
using TP_1_DAI.Utils;

namespace TP_1_DAI.Services
{

    public static class UsuarioServices
    {
        
        public static Usuario Login(string userName, string password) {

            Usuario usuario = null;

            using(SqlConnection db = BD.GetSqlConnection()) {
                string query = "SELECT * FROM Usuarios WHERE UserName = @userName AND Password = @password";
                usuario = db.QueryFirstOrDefault<Usuario>(query, new {userName, password});
            }

            if(usuario != null) {
                RefreshToken(usuario.Id);
                
            }

            return usuario;
        }

        private static string RefreshToken(int id) {

            string nuevoId = System.Guid.NewGuid().ToString(); 
            int count = 0;



            using(SqlConnection db = BD.GetSqlConnection()) {
                string query = "UPDATE Usuarios  VALUES Token = @nuevoId, TokenExpirationDate = DateAdd(MINUTE, 15, GetDate())";
                count = db.Execute(query, new {nuevoId});
            }

            return null;

        }

    }

}