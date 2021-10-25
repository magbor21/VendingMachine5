using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Products
{
    public class Snack : Product
    {
        private int weight;
        public int Weight
        {
            get { return weight; }

            set
            {
                if (value < 0)
                    throw new ArgumentException("No helium snacks allowed!");
                else
                    weight = value;
            }
        }

        public bool ContainsNuts { get; set; }

        public Snack(string name, string details, string usage, int price, int stock, int weight, bool containsNuts):base(name,details,usage,price,stock)
        {
            Weight = weight;
            ContainsNuts = containsNuts;
        }

        public new string Examine()
        {
            return base.Examine() + $" \nWeight: {Weight} grams \nContains Nuts: {ContainsNuts}";
        }

    }
}
