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
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("Drive Name\tType\tTotal Size(GB)\tFree Space(GB)\tStatus");
            Console.WriteLine("----------------------------------------------------------------");

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    double totalSize = drive.TotalSize / (1024.0 * 1024 * 1024);
                    double freeSpace = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
                    double freePercent = (freeSpace / totalSize) * 100;
                    string status = freePercent < 15 ? "Low Space" : "OK";

                    Console.WriteLine($"{drive.Name}\t{drive.DriveType}\t{totalSize:F2}\t\t{freeSpace:F2}\t\t{status}");
                }
                else
                {
                    Console.WriteLine($"{drive.Name}\tNot Ready");
                }
            }
            Console.ReadLine();

        }
    }
}

