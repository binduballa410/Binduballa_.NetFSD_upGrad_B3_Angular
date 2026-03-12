using System;

namespace ConsoleApp2
{
    internal class program
    {
        static void Main(string[] args)
        {
            string studName;
            int Marks;
            string Grade;


            Console.WriteLine("Enter Student Name : ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter Marks : ");
            int marks = int.Parse(Console.ReadLine());

            string grade = "";

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks! Please enter marks between 0 and 100.");
            }
            else
            {

                if (marks >= 90)
                    grade = "A";
                else if (marks >= 75)
                    grade = "B";
                else if (marks >= 60)
                    grade = "C";
                else if (marks >= 50)
                    grade = "D";
                else
                    grade = "Fail";
            }

            Console.WriteLine("Student Name :" + studentName);
            Console.WriteLine("Grade:" + grade);





        }
    }
}

