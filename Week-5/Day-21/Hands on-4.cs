using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Vehicle
    {
        public string Brand { get; set; }
        public int RentalRatePerDay { get; set; }

        public Vehicle(string Brand, int RentalRatePerDay)
        {
            this.Brand = Brand;
            this.RentalRatePerDay = RentalRatePerDay;
        }
        public virtual int CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }
    class Car : Vehicle
    {
        public Car(string Brand, int RentalRatePerDay) : base(Brand, RentalRatePerDay)
        {
            Brand = Brand;
        }
        public override int CalculateRental(int days)
        {
            int total = base.CalculateRental(days);
            return total + 500;

        }
    }
    class Bike : Vehicle
    {
        public Bike(string Brand, int RentalRatePerDay) : base(Brand, RentalRatePerDay)
        {
            Brand = Brand;
        }
        public override int CalculateRental(int days)
        {
            int total = base.CalculateRental(days);
            double discount = total * 0.05;
            return (int)(total - discount);
        }
    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Car Brand:");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter RentalRatePerDay: ");
            int rate = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter days: ");
            int days = int.Parse(Console.ReadLine());

            Vehicle car = new Car(brand, rate);
            int carRent = car.CalculateRental(days);

            Console.WriteLine("Total Rental = " + carRent);

            Console.ReadLine();
        }
    }
}

