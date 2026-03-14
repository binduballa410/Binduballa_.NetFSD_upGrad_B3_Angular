using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Student
    {
        public int CalculateAverage(int m1, int m2, int m3)
        {
            int avg = (m1 + m2 + m3) / 3;
            return avg;

        }
        public void DisplayGrade(double avg)
        {
            if (avg >= 80)
                Console.WriteLine("Grade : A");
            else if (avg >= 60)
                Console.WriteLine("Grade : B");
            else if (avg >= 50)
                Console.WriteLine("Grade : C");
            else
                Console.WriteLine("Grade : D");
        }
    }
    internal class FileName
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            Console.WriteLine("Enter marks 1 :");
            int m1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks 2:");
            int m2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks 3 :");
            int m3 = int.Parse(Console.ReadLine());

            int average = student.CalculateAverage(m1, m2, m3);

            Console.WriteLine("Average Marks :" + average);

            student.DisplayGrade(average);
        }
    }
}
