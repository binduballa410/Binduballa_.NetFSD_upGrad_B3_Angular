using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name= name;
            Price = price;
        }
        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }
    class Electronics : Product
    {
        public Electronics(string name, double price) : base(name, price)
        {
            Name = name;
        }
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }
    class Clothing : Product
    {
        public Clothing(string name, double price) : base(name, price)
        {
            Name = name;
        }
        public override double CalculateDiscount()
        {
            return base.CalculateDiscount();
        }
    }


    internal class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Electronics Price: ");
            double Price = double.Parse(Console.ReadLine());

            Product item = new Electronics("Laptop", Price);

            Console.WriteLine("Final Price after 5% discount = " + item.CalculateDiscount());
      

        }

    }
}





