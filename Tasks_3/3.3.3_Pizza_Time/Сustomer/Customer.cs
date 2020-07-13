using System;
using _3._3._3_Pizza_Time.Vendor;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Сustomer
{
    internal class Customer
    {
        public string Name { get; }

        protected decimal _money;

        public AbstractProduct Product { get; protected set; }

        public Customer(string name, decimal money)
        {
            Name = name;
            _money = money;
        }

        public bool OrderToPizza(Pizzeria pizzeria, TypePizza pizza)
        {
            return pizzeria.OrderTo(pizza, ref _money, GetPizza);
        }

        protected void GetPizza(Func<AbstractPizza> CallBack)
        {
            Product = CallBack();
        }
    }
}
