using System;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal class Cashier : AbstractCashier
    {
        protected readonly Queue<Order<TypePizza, Action<Func<AbstractPizza>>>> Orders;

        public Cashier(Queue<Order<TypePizza, Action<Func<AbstractPizza>>>> orders)
        {
            Orders = orders;
        }

        public override bool TakeOrder(TypePizza menu, ref decimal customerMoney, ref decimal companyMoney, Action<Func<AbstractPizza>> CollBackPizza)
        {
            if (menu == TypePizza.None || CheckMoney(menu, ref customerMoney, ref companyMoney) == -1)
            {
                return false;
            }

            Orders.Enqueue(new Order<TypePizza, Action<Func<AbstractPizza>>>(menu, CollBackPizza));

            return true;
        }

        private int CheckMoney(TypePizza menu, ref decimal customerMoney, ref decimal companyMoney)
        {
            if (((int)menu) <= customerMoney)
            {
                customerMoney -= (int)menu;
                companyMoney += (int)menu;

                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
