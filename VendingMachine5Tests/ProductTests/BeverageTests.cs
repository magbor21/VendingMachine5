using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Products;

namespace VendingMachine5Tests.ProductTests
{
    public class BeverageTests
    {
        [Fact]
        public void Constructor()
        {
            Beverage fanta = new Beverage("Fanta Zero", "Carbonated soda with orange flavor", "Open the can and drink it", 16, 2, 33, true);
            string result = fanta.Examine();
            Assert.Equal("Name: Fanta Zero \nPrice: 16 kr \nStock: 2 \nDetails: Carbonated soda with orange flavor \nVolume: 33 cl \nCarbonated: True", result);

        }

    }
}
