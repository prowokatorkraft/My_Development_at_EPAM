using System;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time.Vendor.Worker
{
    internal abstract class AbstractCook : AbstractWorker
    {
        public event Action<Func<AbstractPizza>> EventOrderCompleted = new Action<Func<AbstractPizza>>((d) => { });

        protected void CompleteOrder(Func<AbstractPizza> CollBackPizza)
        {
            EventOrderCompleted.Invoke(CollBackPizza);
        }
    }
}
