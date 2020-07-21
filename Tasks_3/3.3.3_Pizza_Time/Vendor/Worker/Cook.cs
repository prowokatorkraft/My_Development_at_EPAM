using System;
using System.Threading;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal class Cook : AbstractCook
    {
        protected static object LokerOrder = new object();
        protected Action<Func<int, AbstractPizza>> InvokeDeliveryPizza;
        protected readonly Queue<Order<TypePizza>> Orders;

        public Cook(AbstractRestaurant work, Queue<Order<TypePizza>> orders, Action<Func<int, AbstractPizza>> invokeDeliveryPizza)
        {
            Work = work;
            Orders = orders;
            InvokeDeliveryPizza = invokeDeliveryPizza;

            new Thread(MonitorOrder).Start();
        }

        protected void MonitorOrder()
        {
            Thread.CurrentThread.IsBackground = true;

            Order<TypePizza> order;

            while (true)
            {
                lock (LokerOrder)
                {
                    if (Orders.Count > 0)
                    {
                        order = Orders.Dequeue();

                        Thread.Sleep(3000);

                        InvokeDeliveryPizza((orderNumber) =>
                        {
                            if (orderNumber == order.GetHashCode())
                            {
                                return FactoryPizza(order.Menu);
                            }

                            return null;
                        });
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
                case TypePizza.CaliforniaPizza: return new CaliforniaPizza(Work);
                case TypePizza.ChicagoPizza: return new ChicagoPizza(Work);
                case TypePizza.NeapolitanPizza: return new NeapolitanPizza(Work);
                default: return null;
            }
        }
    }
}
