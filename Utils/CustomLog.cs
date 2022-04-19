using System;
using Newtonsoft.Json;
using TP_1_DAI.Helpers;
using System.IO;


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
                dataString = JsonConvert.SerializeObject(datos);
            }

            data = string.Format("{0} {1}{2}{3}{4}", 
                    DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"),
                    errorData,
                    (className != null) ? $"\n\tClassName\t= {className}" : "",
                    (contexto != null) ? $"\n\tContexto\t= {contexto}" : "",
                    (datos != null) ? $"\n\tClassName\t= {datos}" : ""
            );

            try
            {
                string path = ConfigurationHelper.GetConfiguration()["CustomLog:LogFolder"];
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fullFileName = ConfigurationHelper.GetConfiguration()["CustomLog:LogFolder"] + @"\log.txt";
                IOHelper.AppendInFile(fullFileName, data);

            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

        }
    }
}

// FECHA VERSION .NET USER
// EXCEPTION
// TEXT
// TRACE