using System;
using VendingMachine5.Model;
using VendingMachine5.Products;

namespace VendingMachine5
{
    class Program
    {
        static void Main(string[] args)  // Test code
        {
            Console.WriteLine("Hello World!");
            {

                Beverage beverage = new Beverage("Cola Zero", "Carbonated soda with cola flavor", "Open the can and drink it", 16, 5, 33, true);
                Product product = beverage as Product;

                string strang = "bu";
                if (product is Beverage)
                    strang = (product as Beverage).Examine();

                Console.WriteLine(strang);
                VendingMachine vendingMachine = new VendingMachine();

                vendingMachine.Restock();
                vendingMachine.AddBeverage("Cola Zero", "Carbonated soda with cola flavor", "Open the can and drink it", 16, 5, 33, true);



            }
        }
    }
}
