using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n---Student Report---");
            Console.WriteLine("ID\tName\tMarks");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.StudentId}\t{student.StudentName}\t{student.Marks}");
            }
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            StudentRepository repo = new StudentRepository();
            ReportGenerator report = new ReportGenerator();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Ravi", Marks = 85 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Anu", Marks = 90 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Kiran", Marks = 78});

            List<Student> students = repo.GetAllStudents();
            report.GenerateReport(students);
            Console.ReadLine();
            
        }
    }
}




