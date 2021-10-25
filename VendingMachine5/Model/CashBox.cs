using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Model
{
    public class CashBox
    {
        private static readonly int[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1 }; // The denominations
        private static int salesTotal = 0;
        private static int cashPool = 0;

        public static int InsertMoney(int amount) // adds money to the cash pool
        {
            for(int i = 0;i < denominations.Length;i++)
            {
                if(amount == denominations[i])
                {
                    cashPool += amount;
                    return cashPool;
                }
            }

            throw new ArgumentException($"{amount} is not a valid denomination.");

        }


        public static bool Buy(int price) // checks and removes the price amount from the cash pool
        {
            if (price < 0)
                throw new ArgumentException("Negative purchases are not allowed");

            if (price > cashPool)
                return false;
            else
            {
                cashPool -= price;
                salesTotal += price;
            }
            return true;
        }

        public static string[] EndTransaction() //Return the change to the customer
        {
            string[] notesAndCoins = new string[0];
            int cashPoolTemp = cashPool;

            while (cashPoolTemp > 0)
            {
                for(int i = 0; i < denominations.Length;i++) //Returning one note/coin at a time starting with the largest
                {
                    if(cashPoolTemp >= denominations[i])
                    {
                        Array.Resize(ref notesAndCoins, notesAndCoins.Length + 1);
                        notesAndCoins[notesAndCoins.Length - 1] = $"Returning {denominations[i]} kr";
                        cashPoolTemp -= denominations[i];
                        break;
                    }
                }

            }

            Array.Resize(ref notesAndCoins, notesAndCoins.Length + 1);
            notesAndCoins[notesAndCoins.Length - 1] = $"Total returned amount: {cashPool} kr"; // Adds a total to the end of the message

            cashPool = 0;
            return notesAndCoins;
        }

        public static string EndOfDay() // sums up todays transactions and resets the counter
        {
            int todaysSales = salesTotal;
            salesTotal = 0;
            return $"Todays sales adds up to {todaysSales} kr";
        }
    }
}
