using System;
using System.Threading;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal class Cook : AbstractCook
    {
        protected static object LokerOrder = new object();

        protected readonly Queue<Order<TypePizza, Action<Func<AbstractPizza>>>> Orders;

        public Cook(Queue<Order<TypePizza, Action<Func<AbstractPizza>>>> orders)
        {
            Orders = orders;

            new Thread(MonitorOrder).Start();
        }

        protected void MonitorOrder()
        {
            Order<TypePizza, Action<Func<AbstractPizza>>> order;

            while (true)
            {
                lock (LokerOrder)
                {
                    if (Orders.Count > 0)
                    {
                        order = Orders.Dequeue();

                        EventOrderCompleted += order.CallBackPizza;

                        Thread.Sleep(3000);

                        CompleteOrder(() => FactoryPizza(order.Menu));
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        protected AbstractPizza FactoryPizza(TypePizza menu)
        {
            switch (menu)
            {
                case TypePizza.CaliforniaPizza: return new CaliforniaPizza();
                case TypePizza.ChicagoPizza: return new ChicagoPizza();
                case TypePizza.NeapolitanPizza: return new NeapolitanPizza();
                default: return null;
            }
        }
    }
}
