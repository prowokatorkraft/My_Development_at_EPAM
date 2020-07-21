using System;
using System.Collections.Generic;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal class Cashier : AbstractCashier
    {
        protected readonly Queue<Order<TypePizza>> Orders;

        public Cashier(AbstractRestaurant work, Queue<Order<TypePizza>> orders)
        {
            Work = work;
            Orders = orders;
        }

        public override int TakeOrder(TypePizza menu, ref decimal customerMoney, ref decimal companyMoney)
        {
            if (menu == TypePizza.None || CheckMoney(menu, ref customerMoney, ref companyMoney) == -1)
            {
                return -1;
            }

            var order = new Order<TypePizza>(menu);
            
            Orders.Enqueue(order);

            return order.GetHashCode();
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
