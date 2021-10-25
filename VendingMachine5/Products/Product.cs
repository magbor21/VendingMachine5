using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Products
{
    public abstract class Product
    {
        private string name;
        private string details;
        private string usage;
        private int price;
        private int stock;

        public string Details
        {
            get { return details; }
            set
            {
                if (value.Length > 0)
                    details = value;
                else
                    throw new ArgumentException("Details are empty");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 0)
                    name = value;
                else
                    throw new ArgumentException("Name is empty");
            }
        }

        public string Usage
        {
            get
            {
                if (Bought == true)
                    return usage;
                else
                    return "You must buy it before you can use it";
            }

            set
            {
                if (value.Length > 0)
                    usage = value;
                else
                    throw new ArgumentException("Usage is empty");
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price is too cheap");
                else
                    price = value;
            }
        }

        public int Stock // Number of items left in the machine
        {
            get { return stock; }
            set
            {
                if (value > 0)
                    stock = Math.Min(value, 20); // No more than 20 items per product
                else
                    stock = 0;
            }
                
        } 
        public bool Bought { get; set; }

        public Product(string name, string details, string usage, int price, int stock)
        {
            Name = name;
            Details = details;
            Usage = usage;
            Price = price;
            Stock = stock;
            Bought = false;
        }

        public string Examine()
        {
            return $"Name: {Name} \n" +
                $"Price: {Price} kr \n" +
                $"Stock: {Stock} \n" +
                $"Details: {Details}";
        }



        public string Use()
        {
            return "Usage: " + usage;

        }

        public string NamePrice()
        {
            return $"{Name}, {Price} kr";
        }
    }
}
