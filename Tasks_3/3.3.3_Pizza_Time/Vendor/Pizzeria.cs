using System;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;
using _3._3._3_Pizza_Time.Vendor.Worker;

namespace _3._3._3_Pizza_Time.Vendor
{
    class Pizzeria : AbstractRestaurant
    {
        protected decimal _money;

        protected Queue<Order<TypePizza, Action<Func<AbstractPizza>>>> Orders;
        protected event Action<Func<AbstractPizza>> EventOrderCompleted;
        protected List<AbstractWorker> _worker;

        public Pizzeria(decimal money)
        {
            _money = money;

            Orders = new Queue<Order<TypePizza, Action<Func<AbstractPizza>>>>();
            EventOrderCompleted = new Action<Func<AbstractPizza>>((d) => { });
            _worker = new List<AbstractWorker>() { new Cashier(Orders), new Cook(Orders), new Cook(Orders) };
        }

        public override bool OrderTo(TypePizza menu, ref decimal money, Action<Func<AbstractPizza>> CallBackPizza)
        {
            AbstractCashier cashier = null;

            foreach (var item in _worker)
            {
                if (item is AbstractCashier)
                {
                    cashier = (AbstractCashier) item;
                }
            }

            if (cashier != null)
            {
                return cashier.TakeOrder(menu, ref money, ref _money, CallBackPizza);
            }

            return false;
        }
    }
}
