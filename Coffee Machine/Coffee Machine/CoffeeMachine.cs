using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Machine
{
    public class CoffeeMachine
    {
        public double Balance { get; set; }
        public double Water { get; set; }
        public double Milk { get; set; }
        public double Coffee { get; set; }
        public double Money { get; private set; }

        public CoffeeMachine()
        {
            Balance = 0.00;
            Water = 300;
            Milk = 300;
            Coffee = 300;
            Money = 0.00;
        }

        public void AddBalance(double amount)
        {
            Balance += amount;
        }

        public bool PourEspresso()
        {
            double cost = 1.5;
            if (Water < 50)
            {
                return false; // Not enough water
            }
            if (Coffee < 18)
            {
                return false; // Not enough coffee
            }
            if (Balance < cost)
            {
                return false; // Not enough balance
            }

            Water -= 50;
            Coffee -= 18;
            Balance -= cost;
            Money += cost;
            return true; // Espresso successfully poured
        }

        public bool PourLatte()
        {
            double cost = 2.5;
            if (Water < 200 || Milk < 150 || Coffee < 24 || Balance < cost)
            {
                return false; // Not enough resources or balance
            }

            Water -= 200;
            Milk -= 150;
            Coffee -= 24;
            Balance -= cost;
            Money += cost;
            return true; // Latte successfully poured
        }

        public bool PourCappuccino()
        {
            double cost = 3.0;
            if (Water < 250 || Milk < 50 || Coffee < 24 || Balance < cost)
            {
                return false; // Not enough resources or balance
            }

            Water -= 250;
            Milk -= 50;
            Coffee -= 24;
            Balance -= cost;
            Money += cost;
            return true; // Cappuccino successfully poured
        }
    }
}
