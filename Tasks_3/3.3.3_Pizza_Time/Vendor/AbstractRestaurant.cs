using System;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor
{
    internal abstract class AbstractRestaurant
    {
        public abstract bool OrderTo(TypePizza menu, ref decimal money, Action<Func<AbstractPizza>> CollBackPizza);
    }
}
