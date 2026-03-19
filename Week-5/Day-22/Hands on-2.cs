using System;
namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;

    class Student
    {
        public int RollNo;
        public string Name;
        public string Course;
        public int Marks;
    }

    class Class1
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            int choice;

            do
            {
                Console.WriteLine("\n--- Student Record Menu ---");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Choice: ");

                choice = int.Parse(Console.ReadLine()); // simple input

                switch (choice)
                {
                    case 1:
                        AddStudents(students);
                        break;

                    case 2:
                        DisplayStudents(students);
                        break;

                    case 3:
                        SearchStudents(students);
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4);
        }

        static void AddStudents(List<Student> students)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Student s = new Student();

                Console.Write("Enter Roll No: ");
                s.RollNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                s.Name = Console.ReadLine();

                Console.Write("Enter Course: ");
                s.Course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                s.Marks = int.Parse(Console.ReadLine());

                students.Add(s);
            }
        }

        static void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No records found!");
                return;
            }

            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        static void SearchStudents(List<Student> students)
        {
            Console.Write("Enter Roll No to search: ");
            int roll = int.Parse(Console.ReadLine());

            foreach (var s in students)
            {
                if (s.RollNo == roll)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    return;
                }
            }

            Console.WriteLine("Student not found!");
        }
    }
}