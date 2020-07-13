using System;
using _3._3._3_Pizza_Time.Vendor;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Сustomer
{
    internal class Customer
    {
        protected decimal _money;

        public AbstractProduct Product { get; protected set; }

        public Customer(decimal money)
        {
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
