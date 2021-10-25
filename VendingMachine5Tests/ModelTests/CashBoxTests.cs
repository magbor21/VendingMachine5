using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine5.Model;

namespace VendingMachine5Tests.ModelTests
{
    public class CashBoxTests
    {
        [Fact]
        public void Adding()
        {
            CashBox.InsertMoney(1);
            CashBox.InsertMoney(5);
            CashBox.InsertMoney(10);
            CashBox.InsertMoney(20);
            CashBox.InsertMoney(50);
            CashBox.InsertMoney(100);
            CashBox.InsertMoney(500);
            int total = CashBox.InsertMoney(1000);
            Assert.Equal(1686, total);

            var exception = Record.Exception(() => CashBox.InsertMoney(1337)); 
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("1337 is not a valid denomination.", exception.Message);

        }

        [Fact]
        public void Buying()
        {
            CashBox.InsertMoney(1000);
            bool result = CashBox.Buy(600); // 600 < 1000 => OK
            Assert.True(result);

            result = CashBox.Buy(600); // 600 > 400 => Not OK
            Assert.False(result);

            var exception = Record.Exception(() => CashBox.Buy(-45));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("Negative purchases are not allowed", exception.Message);
        }

        [Fact]
        public void ReturningChange()
        {
            CashBox.InsertMoney(1000);
            CashBox.Buy(1);
            string[] result = CashBox.EndTransaction();
            Assert.Equal(14, result.Length);
            Assert.Equal("Total returned amount: 999 kr", result[13]);

            result = CashBox.EndTransaction();
            Assert.Single(result);
            Assert.Equal("Total returned amount: 0 kr", result[0]);

        } 
        
        [Fact]
        public void EndOfDaySales()
        {
            CashBox.InsertMoney(100);
            CashBox.Buy(1);
            CashBox.Buy(2);
            CashBox.Buy(3);
            CashBox.Buy(4);
            CashBox.Buy(5);
            CashBox.EndTransaction();
            string result = CashBox.EndOfDay();
            Assert.Equal("Todays sales adds up to 15 kr", result);

        }

    }
}
