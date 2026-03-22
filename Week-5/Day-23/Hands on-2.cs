using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
        internal class Product
        {
            public int ProCode { get; set; }

            public string ProName { get; set; }

            public string ProCategory { get; set; }

            public double ProMrp { get; set; }

            public List<Product> GetProducts()
            {
                return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                 new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                 new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                 new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                 new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                 new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                 new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                 new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                 new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                 new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                 new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };

            }
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            var products = product.GetProducts();

            //1.Write a LINQ query to search and display all products with category “FMCG”.//

            var categoryFMCG = from p in products
                               where p.ProCategory == "FMCG"
                               select p;
            foreach ( var p in categoryFMCG)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName} {p.ProCategory} {p.ProMrp}");
            }
            Console.WriteLine("-----------------------------------");
            //2.Write a LINQ query to search and display all products with category “Grain”.

            var categoryGrain = from p in products
                                where p.ProCategory == "Grain"
                                select p;
            foreach (var p in categoryGrain)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName} {p.ProCategory} {p.ProMrp}");
            }
            Console.WriteLine("-----------------------------------");
            //3.Write a LINQ query to sort products in ascending order by product code.

            var sortByCode = from p in products
                             orderby p.ProCode ascending
                             select p;
            foreach (var p in sortByCode)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName}");
            }
            Console.WriteLine("-----------------------------------");
            //4.Write a LINQ query to sort products in ascending order by product Category.

            var sortByCategory = from p in products
                                 orderby p.ProCategory ascending
                                 select p;
            foreach (var p in sortByCategory)
            {
                Console.WriteLine($"{p.ProCategory} {p.ProName}");
            }
            Console.WriteLine("-----------------------------------");
            //5.Write a LINQ query to sort products in ascending order by product Mrp.

            var sortByMrp = from p in products
                            orderby p.ProMrp ascending
                            select p;
            foreach (var p in sortByMrp)
            {
                Console.WriteLine($"{p.ProName} {p.ProMrp}");
            }
            Console.WriteLine("-----------------------------------");
            //6.Write a LINQ query to sort products in descending order by product Mrp

            var sortByMrpDesc = from p in products
                                orderby p.ProMrp descending
                                select p;
            foreach (var p in sortByMrpDesc)
            {
                Console.WriteLine($"{p.ProName} {p.ProMrp}");
            }
            Console.WriteLine("-----------------------------------");
            //7. Write a LINQ query to display products group by product Category.
            var groupByCategory = from p in products
                                  group p by p.ProCategory;
            foreach (var group in groupByCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var p in group)
                {
                    Console.WriteLine($"    {p.ProName}");
                }
            }
            Console.WriteLine("-----------------------------------");
            // 8. Write a LINQ query to display products group by product Mrp.

            var groupByMrp = from p in products
                             group p by p.ProMrp;
            foreach (var group in groupByMrp)
            {
                Console.WriteLine($"MRP: {group.Key}");
                foreach (var p in group)
                {
                    Console.WriteLine($"    {p.ProName}");
                }
            }
            Console.WriteLine("-----------------------------------");

            // 9. Write a LINQ query to display product detail with highest price in FMCG category

            var highestFMCG = (from  p in products where p.ProCategory == "FMCG"
                               orderby p.ProMrp descending
                               select p).FirstOrDefault();
            Console.WriteLine("Highest FMCG Product: ");
            Console.WriteLine($"{highestFMCG.ProName} {highestFMCG.ProMrp}");

            Console.WriteLine("-----------------------------------");
            // 10.Write a LINQ query to display count of total products.

            int totalCount = products.Count();
            Console.WriteLine("Total Products: " + totalCount);

            Console.WriteLine("-----------------------------------");

            //11. Write a LINQ query to display count of total products with category FMCG

            int fmcgCount = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine("FMCG Products Count: " + fmcgCount);

            Console.WriteLine("-----------------------------------");
            //12.Write a LINQ query to display Max price

            double maxPrice = products.Max(p => p.ProMrp);
            Console.WriteLine("Maximun Price: " + maxPrice);

            Console.WriteLine("-----------------------------------");

            //13.Write a LINQ query to display Min price

            double minPrice = products.Min(p => p.ProMrp);
            Console.WriteLine("Minimun Price: " + minPrice);

            Console.WriteLine("-----------------------------------");

            //14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.

            bool allBelow30 = products.All(p => p.ProMrp < 30);
            Console.WriteLine("All products below 30: " + allBelow30);

            Console.WriteLine("-----------------------------------");

            //15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.

            bool anyBelow30 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine("Any product below 30: " +  anyBelow30);



        }
    }
}

