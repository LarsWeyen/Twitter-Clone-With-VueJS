using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Settings
{
    public static class Settings
    {
        public static class Database
        {
            private static string server = @"server=DESKTOP-IH6LRCE\SQLEXPRESS";
            private static string projectDb = "Database=Twitter_Clone";        
            private static string security = "Integrated security = true";
            private static string projConnString = $"{server};{projectDb};{security}";      
            public static string Server => server;
            public static string ProjectDatabase => projectDb;
            public static string IndividualDatabase => projectDb;
            public static string Security => security;
            public static string ProjectConnectionstring => projConnString;           
        }
    }
}
