using System;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor
{
    internal abstract class AbstractRestaurant
    {
        public event Action<Func<int, AbstractPizza>> DeliveryProductEvent;

        public abstract int OrderTo(TypePizza menu, ref decimal money);
        protected void InvokeDeliveryPizza(Func<int, AbstractPizza> TryOrder)
        {
            DeliveryProductEvent.Invoke(TryOrder);
        }
    }
}
