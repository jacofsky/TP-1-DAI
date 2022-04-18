using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TP_1_DAI.Helpers
{
    public static class IOHelper 
    {
        public static bool AppendInFile(string fullFileName, string data) {
            
            bool returnValue = false;
            
            
            using (StreamWriter sw = File.AppendText(fullFileName))
            {
                sw.WriteLine(data);
                returnValue = true;
            }

            return returnValue;

        }
    }

}