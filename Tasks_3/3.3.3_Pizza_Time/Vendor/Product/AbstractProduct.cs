namespace _3._3._3_Pizza_Time.Vendor.Product
{
    internal abstract class AbstractProduct
    {
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
