using System;
using System.IO;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the root Directory path: ");
            string path = Console.ReadLine();

            try
            {
                DirectoryInfo root = new DirectoryInfo(path);

                if (root.Exists)
                {
                    DirectoryInfo[] subDirs = root.GetDirectories();
                    Console.WriteLine($"Analyzing: {root.FullName}");

                    Console.WriteLine("--------------------------------------");

                    Console.WriteLine("Folder Name\t\tFile Count");
                    Console.WriteLine("---------------------------------");

                    foreach (DirectoryInfo dir in subDirs)
                    {
                        try
                        {
                            FileInfo[] files = dir.GetFiles();
                            int fileCount = files.Length;
                            Console.WriteLine($"{dir.Name} \t\t{fileCount}");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine("\t\tAccess Denied");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Directory does not exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }       
    }
}

