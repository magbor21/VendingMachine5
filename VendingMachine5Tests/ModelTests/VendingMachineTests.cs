using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Model;
using VendingMachine5.Products;

namespace VendingMachine5Tests.ModelTests
{
    public class VendingMachineTests
    {
        [Fact]
        public void ShowAll()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Restock();
            string[] result = vendingMachine.ShowAll();
            Assert.Equal(6, result.Length);

            Assert.Equal("Milk, 19 kr", result[1]);
        }

        [Fact]
        public void PurchaseAndUse()
        {
            VendingMachine vendingMachine = new VendingMachine(); //Setting up the machine
            vendingMachine.Restock();
            vendingMachine.InsertMoney(1000);

            vendingMachine.Purchase(4);
            string result = vendingMachine.Use(4);
            Assert.Equal("Open the bag and eat them",result);
            result = vendingMachine.Use(2);
            Assert.Equal("You must buy it before you can use it", result);

            vendingMachine.Purchase("Snickers");
            result = vendingMachine.Use("Snickers");
            Assert.Equal("Open the wrapper and eat it", result);
        }

        [Fact]
        public void CashManagement()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.Restock();
            vendingMachine.InsertMoney(100);
            vendingMachine.Purchase(4);
            string[] result = vendingMachine.EndTransaction();
            Assert.Equal(6, result.Length);

            Assert.Equal("Total returned amount: 63 kr",result[5]);

            string result2 = vendingMachine.EndOfDay();
            Assert.Equal("Todays sales adds up to 37 kr",result2);

        }

        [Fact]
        public void Examine()
        {
            VendingMachine vendingMachine = new VendingMachine(); //Setting up the machine
            vendingMachine.Restock();
            vendingMachine.InsertMoney(1000);

            string result = vendingMachine.Examine(1);
            Assert.Equal("Name: Milk \nPrice: 19 kr \nStock: 9 \nDetails: Small carton of 1.5% milk \nVolume: 20 cl \nCarbonated: False", result);

            result = vendingMachine.Examine("Small car");
            Assert.Equal("Name: Small car \nPrice: 24 kr \nStock: 8 \nDetails: A small toy car \nColor: Blue \nRequires batteries: False", result);
                
        }

    }

    
}
