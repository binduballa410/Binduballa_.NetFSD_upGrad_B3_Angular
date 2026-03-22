using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dirName = "Logs";
            try
            {
                if (Directory.Exists(dirName) == false)
                {
                    Directory.CreateDirectory(dirName);
                }

                string logFilePath = Path.Combine(dirName, "activity_log.txt");

                while (true)
                {
                    Console.WriteLine("Enter message (type 'exit' to stop): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                    {
                        Console.WriteLine("Program ended.");
                        break;
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(logFilePath, true))
                        {
                            sw.WriteLine(message);
                        }
                        Console.WriteLine("Content written on to the file successfully");
                    }
                    Console.WriteLine("Current File Content:");
                    Console.WriteLine(File.ReadAllText(logFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
      
        }

    }
}

