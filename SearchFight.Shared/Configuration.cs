using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SearchFight.Shared
{
    public class Configuration
    {
        public static String ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading settings");
            }

            return String.Empty;
        }
    }
}
