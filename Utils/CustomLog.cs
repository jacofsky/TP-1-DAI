using System;

namespace TP_1_DAI.Utils
{
    public static class CustomLog {
        public static void LogError (Exception ex) {
            LogError(ex.ToString(), null, null, null);
        }
        public static void LogError (string errorData) {

            LogError(errorData, null, null, null);


        }
        public static void LogError (Exception ex, string className, string contexto, object datos) {
            LogError(ex.ToString(), null, null, datos);
        }
        public static void LogError (string errorData, string className, string contexto, object datos) {

            string data, dataString = "";
            if(datos != null) {
                dataString = JsonConverter.Ser
            }

            data = string.Format("{0} {1}{2}{3}{4}", 
                    DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"),
                    errorData,
                    (className != null) ? $"\n\tClassName\t= {className}" : "",
                    (contexto != null) ? $"\n\tContexto\t= {contexto}" : "",
                    (datos != null) ? $"\n\tClassName\t= {datos}" : ""
            );
            

        }
    }
}

// FECHA VERSION .NET USER
// EXCEPTION
// TEXT
// TRACE