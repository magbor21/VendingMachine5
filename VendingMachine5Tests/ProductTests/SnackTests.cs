using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Products;

namespace VendingMachine5Tests.ProductTests
{
    public class SnackTests
    {
        [Fact]
        public void Constructor()
        {
            Snack snack = new Snack("Salted chips", "Estrella chips, lightly salted", "Open the bag and eat them", 37, 14, 175, false);
            string result = snack.Examine();
            Assert.Equal("Name: Salted chips \nPrice: 37 kr \nStock: 14 \nDetails: Estrella chips, lightly salted \nWeight: 175 grams \nContains Nuts: False", result);

        }

    }
}
