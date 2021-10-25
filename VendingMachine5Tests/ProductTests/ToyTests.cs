using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Products;

namespace VendingMachine5Tests.ProductTests
{
    public class ToyTests
    {
        [Fact]
        public void Constructor()
        {
            Toy toy = new Toy("Small car", "A small toy car", "Pull it back and it goes forward", 24, 8, "blue", false);
            string result = toy.Examine();
            Assert.Equal("Name: Small car \nPrice: 24 kr \nStock: 8 \nDetails: A small toy car \nColor: blue \nRequires batteries: False", result);

        }

    }
}
