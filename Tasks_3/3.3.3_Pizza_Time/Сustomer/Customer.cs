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

        private int _orderNumber = -1;

        public Customer(string name, decimal money)
        {
            Name = name;
            _money = money;
        }

        public bool OrderToPizza(Pizzeria pizzeria, TypePizza pizza)
        {
            _orderNumber = pizzeria.OrderTo(pizza, ref _money);

            if (_orderNumber < 0)
            {
                return false;
            }

            pizzeria.DeliveryProductEvent += GetPizza;
            
            return true;
        }

        private void GetPizza(Func<int, AbstractPizza> obj)
        {
            var temp = obj(_orderNumber);

            if (temp != null)
            {
                Product = temp;
                temp.Manufacturer.DeliveryProductEvent -= GetPizza;
            }
        }
    }
}
