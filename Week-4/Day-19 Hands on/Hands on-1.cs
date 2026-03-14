using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Products
    {
        private int _productId;
        private string _productName;
        private int _unitPrice;
        private int _qty;

        public Products(int productId)
        {
            _productId = productId;
        }
        public int productId
        {
            get { return _productId; }
        }
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public int unitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public int qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        public void ShowDetails()
        {
            int total = _unitPrice * _qty;

            Console.WriteLine("Product Id :" + _productId);
            Console.WriteLine("Product Name :" + _productName);
            Console.WriteLine("Unit Price :" + _unitPrice);
            Console.WriteLine("Quantity :" + _qty);
            Console.WriteLine("Total Amount :" + total);
        }

    }

    internal class Class1
    {
        static void Main(string[] args)
        {
            Products p = new Products(101);
            p.productName = "Laptop";
            p.unitPrice = 30000;
            p.qty = 2;

            p.ShowDetails();
        }
    }
}

