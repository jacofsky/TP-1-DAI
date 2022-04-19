using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TP_1_DAI.Helpers
{
    public static class IOHelper 
    {
        public static bool AppendInFile(string fullFileName, string data) {
            
            try
            {    
                using (StreamWriter sw = File.AppendText(fullFileName))
                {
                    sw.WriteLine(data);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
        
    }

}