using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Products
{
    public class Beverage : Product
    {
        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Volume can't be 0 or less");
                else
                    volume = value;
            }
        }

        public bool Carbonated { get; set; }

        public Beverage(string name, string details, string usage, int price, int stock, int volume, bool carbonated) : base(name, details, usage, price, stock)
        {
            Volume = volume;
            Carbonated = carbonated;
        }

        public new string Examine()
        {
            return base.Examine() + $" \nVolume: {Volume} cl \nCarbonated: {Carbonated}";
        }
    }
}
