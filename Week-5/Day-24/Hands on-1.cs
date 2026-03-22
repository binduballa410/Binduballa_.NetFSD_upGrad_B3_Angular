using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Folder Path: ");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path");
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(path);

            FileInfo[] files = dir.GetFiles();

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in the directory.");
            }
            else
            {
                Console.WriteLine("\nFile Details: \n");

                foreach (FileInfo file in files)
                {
                    Console.WriteLine("Name: " + file.Name);
                    Console.WriteLine("Size: " + file.Length);
                    Console.WriteLine("Created On: " + file.CreationTime.ToString());

                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Total number of files: " + files.Length);
                }

                Console.ReadLine();
            }


        }
    }
}

