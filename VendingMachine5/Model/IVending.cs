using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine5.Model
{
    interface IVending
    {
        bool Purchase(int index);
        bool Purchase(string name);
        string Use(int index);
        string Use(string name);
        string Examine(string name);
        string Examine(int index);
        string[] ShowAll();
        int InsertMoney(int amount);
        string[] EndTransaction();
        string EndOfDay();
        bool Restock();
        bool AddBeverage(string name, string details, string usage, int price, int stock, int volume, bool carbonated);
        bool AddSnack(string name, string details, string usage, int price, int stock, int weight, bool containsNuts);
        bool AddToy(string name, string details, string usage, int price, int stock, string color, bool requiresBatteries);
      
    }
}
