using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine5.Products;

namespace VendingMachine5.Model
{
    public class VendingMachine : IVending
    {
        private List<Product> inventory = new List<Product>(0); // where all the products are stored

        public string[] ShowAll() // Returns name and price of all Items
        {
            string[] allItems = new string[0];
            foreach (Product product in inventory)
            {
                Array.Resize(ref allItems, allItems.Length + 1);
                allItems[allItems.Length - 1] = product.NamePrice();
            }

            return allItems;

        }

        public bool Purchase(int index) // Purchase by Index
        {
            if (index >= inventory.Count)
                throw new IndexOutOfRangeException("No such item in the machine");

            if (CashBox.Buy(inventory[index].Price))
            {
                if (inventory[index].Stock > 0)
                {
                    inventory[index].Bought = true;
                    inventory[index].Stock--;
                    return true;
                }
                else
                {
                    CashBox.InsertMoney(inventory[index].Price); // Returns the money since Item is out of stock
                    return false;
                }
            }
            return false;

        }


        public bool Purchase(string name) // Purchase by name
        {
            foreach (Product product in inventory)
            {
                if (product.Name == name)
                {
                    if (CashBox.Buy(product.Price))
                    {
                        if (product.Stock > 0)
                        {
                            product.Bought = true;
                            product.Stock--;
                            return true;
                        }
                        else
                        {
                            CashBox.InsertMoney(product.Price); // Returns the money since Item is out of stock
                            return false;
                        }
                    }
                    return false;
                }
            }

            throw new IndexOutOfRangeException("No such item in the machine");

        }

        public string Use(int index) // Use item by Index
        {
            if (index >= inventory.Count)
                throw new IndexOutOfRangeException("No such item in the machine");

            return inventory[index].Usage; //Error message is returned in the same string
            
        }

        public string Use(string name) // Use by name
        {
            foreach (Product product in inventory)
            {
                if (product.Name == name)
                {
                    return product.Usage;                  
                }
                
            }
            
            throw new IndexOutOfRangeException("No such item in the machine");

        }

        public string Examine(int index) //Examine a product based on index
        {
            if (index >= inventory.Count)
                throw new IndexOutOfRangeException("No such item in the machine");

            if (inventory[index] is Beverage)
                return (inventory[index] as Beverage).Examine();
            if (inventory[index] is Toy)
                return (inventory[index] as Toy).Examine();
            if (inventory[index] is Snack)
                return (inventory[index] as Snack).Examine();

            return inventory[index].Examine();
        }

        public string Examine(string name) //Examine a product based on name
        {
            foreach (Product product in inventory)
            {
                if (product.Name == name)
                {
                    if (product is Beverage)
                        return (product as Beverage).Examine();
                    if (product is Toy)
                        return (product as Toy).Examine();
                    if (product is Snack)
                        return (product as Snack).Examine();
                }
            }

            return new string("");

        }


        public int InsertMoney(int amount) //Add money to cash pool
        {
            return CashBox.InsertMoney(amount);
        }

        public string[] EndTransaction() 
        {
            foreach (Product product in inventory)
                product.Bought = false; // stops the next customer from using products before they are bought

            return CashBox.EndTransaction();

        }

        public string EndOfDay()
        {
            return CashBox.EndOfDay();
        }

        public bool Restock() // Adds some products so I don't have to add them manually every time
        {
            inventory.Clear();
            inventory.Add((new Beverage("Fanta Zero", "Carbonated soda with orange flavor", "Open the can and drink it", 16, 2, 33, true) as Product));
            inventory.Add((new Beverage("Milk", "Small carton of 1.5% milk", "Open the carton and drink it", 19, 9, 20, false) as Product));
            inventory.Add((new Toy("Small car", "A small toy car", "Pull it back and it goes forward", 24, 8, "Blue", false) as Product));
            inventory.Add((new Toy("Neck Massager", "Mommys favourite toy", "Put some batteries in it and start massaging", 75, 3, "Pink", true) as Product));
            inventory.Add((new Snack("Salted chips", "Estrella chips, lightly salted", "Open the bag and eat them", 37, 14, 175, false) as Product));
            inventory.Add((new Snack("Snickers", "Peanut and chocolate bar", "Open the wrapper and eat it", 14, 20, 55, true) as Product));

            return true;
        }

        public bool AddBeverage(string name, string details, string usage, int price, int stock, int volume, bool carbonated) //Add a beverage
        {
            Beverage beverage = new Beverage(name, details, usage, price, stock, volume, carbonated);
            inventory.Add(beverage as Product);
            return true;
        }
        public bool AddSnack(string name, string details, string usage, int price, int stock, int weight, bool containsNuts) //Add a snack
        {
            Snack snack = new Snack(name, details, usage, price, stock, weight, containsNuts);
            inventory.Add(snack as Product);
            return true;
        }
        public bool AddToy(string name, string details, string usage, int price, int stock, string color, bool requiresBatteries) // Add a toy
        {
            Toy toy = new Toy(name, details, usage, price, stock, color, requiresBatteries);
            inventory.Add(toy as Product);
            return true;
        }

    }
}
