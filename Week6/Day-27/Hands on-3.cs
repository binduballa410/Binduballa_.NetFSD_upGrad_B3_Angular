using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
  abstract class Shape
    {
        public abstract double CalculateArea();
    }
    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double CalculateArea()
        {
            return Length * Width;
        }
    }
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
  
 
    class Program
    {

        static void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }

        static void Main(string[] args) 
        {
            Shape rect = new Rectangle(5, 4);
            Shape circle = new Circle(3);
            PrintArea(rect);
            PrintArea(circle);  
        }
    }
}




