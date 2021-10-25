using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Products;

namespace VendingMachine5Tests.ProductTests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor()
        {
            Beverage beverage = new Beverage("Cola Zero", "Carbonated soda with cola flavor", "Open the can and drink it", 16, 5, 33, true);
            Product product = beverage as Product;
            string result = product.Examine();
            Assert.Equal("Name: Cola Zero \nPrice: 16 kr \nStock: 5 \nDetails: Carbonated soda with cola flavor", result); //Product result on a Beverage

            Beverage fanta = new Beverage("Fanta Zero", "Carbonated soda with orange flavor", "Open the can and drink it", 16, -45, 33, true); //Negative stock = 0
            Assert.Equal(0, fanta.Stock);
            Beverage fantaLemon = new Beverage("Fanta Lemon Zero", "Carbonated soda with Lemon flavor", "Open the can and drink it", 16, 100, 33, true); //Overstock = 20
            Assert.Equal(20, fantaLemon.Stock);


        }
    }
}
