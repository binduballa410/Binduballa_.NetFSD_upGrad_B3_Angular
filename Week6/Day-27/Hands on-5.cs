using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    class ConfigurationManager
    {
        private static ConfigurationManager instance;
        private static readonly object lockObj = new object();

        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }

        private ConfigurationManager()
        {
            ApplicationName = "Inventory Management System";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=Localhost;Database=InventoryDB;";
        }

        public static ConfigurationManager GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
            }
            return instance;
        }
    }
    
        
    class Program
    {
        static void Main(string[] args) 
        {
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            PrintConfig(config1);

            ConfigurationManager config2 = ConfigurationManager.GetInstance();
            PrintConfig(config2);

            if (config1 == config2)
            {
                Console.WriteLine("\nSame instance confirmed (Singleton working)");
            }
            else
            {
                Console.WriteLine("\nDifferent instances (Error)");
            }
        }
        static void PrintConfig(ConfigurationManager config)
        {
            Console.WriteLine("Application Name: " + config.ApplicationName);
            Console.WriteLine("Version: " + config.Version);
            Console.WriteLine("DB Connection: " + config.DatabaseConnectionString);
            Console.WriteLine("--------------------------------------------");

        }
    }
}




