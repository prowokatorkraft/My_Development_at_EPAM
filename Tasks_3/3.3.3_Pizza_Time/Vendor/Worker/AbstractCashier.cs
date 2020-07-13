using System;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal abstract class AbstractCashier : AbstractWorker
    {
        public abstract bool TakeOrder(TypePizza menu, ref decimal customerMoney, ref decimal companyMoney, Action<Func<AbstractPizza>> CollBackPizza);
    }
}
