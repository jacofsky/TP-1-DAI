using System.Collections.Generic;
using System.Linq;
using System;

using TP_1_DAI.Models;
using TP_1_DAI.Services;
using TP_1_DAI.Utils;

using System.Reflection;


namespace TP_1_DAI.Helpers
{
    public static class SecurityHelper
    {

        public static bool IsValidToken(string token) {

            try
            {
                Usuario usuario = UsuarioServices.GetByToken(token);


                if(usuario != null) {

                    int compare = DateTime.Compare(usuario.TokenExpirationDate, DateTime.Now); 
                    
                    if(compare > 0 ) {
                        return true;
                    }

                    return false;
                }

                return false;
                
            }
            catch (Exception)
            {
                
                throw;
                
            }
        }

    }

}