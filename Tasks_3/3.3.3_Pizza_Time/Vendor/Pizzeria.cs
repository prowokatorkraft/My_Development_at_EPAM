using System;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;
using _3._3._3_Pizza_Time.Vendor.Worker;

namespace _3._3._3_Pizza_Time.Vendor
{
    class Pizzeria : AbstractRestaurant
    {
        protected decimal _money;

        protected Queue<Order<TypePizza>> Orders;
        protected event Action<Func<AbstractPizza>> EventOrderCompleted;
        protected List<AbstractWorker> _worker;

        public Pizzeria(decimal money)
        {
            _money = money;

            Orders = new Queue<Order<TypePizza>>();
            EventOrderCompleted = new Action<Func<AbstractPizza>>((d) => { });
            _worker = new List<AbstractWorker>() { new Cashier(this, Orders), new Cook(this, Orders, InvokeDeliveryPizza), new Cook(this, Orders, InvokeDeliveryPizza) };
        }

        public override int OrderTo(TypePizza menu, ref decimal money)
        {
            AbstractCashier cashier = null;

            foreach (var item in _worker)
            {
                if (item is AbstractCashier)
                {
                    cashier = (AbstractCashier) item;
                    break;
                }
            }

            if (cashier != null)
            {
                // TODO: ????
                return cashier.TakeOrder(menu, ref money, ref _money);
            }

            return -1;
        }
    }
}
