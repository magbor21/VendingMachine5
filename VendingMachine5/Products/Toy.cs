using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Products
{
    public class Toy : Product
    {
        private string color;
        public string Color
        { 
            get { return color; }
            set
            {
                if (value.Length == 0)
                    color = "Probably blue";
                else
                    color = value;
            }
        }    
            
            
        public bool RequiresBatteries { get; set; }

        public Toy(string name, string details, string usage, int price, int stock, string color, bool requiresBatteries) :base(name, details, usage, price, stock)
        {
            Color = color;
            RequiresBatteries = requiresBatteries;
        }

        public new string Examine()
        {
            return base.Examine() + $" \nColor: {Color} \nRequires batteries: {RequiresBatteries}";
        }


    }
}
