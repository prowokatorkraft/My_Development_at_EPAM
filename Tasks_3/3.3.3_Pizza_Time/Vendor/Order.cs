namespace _3._3._3_Pizza_Time.Vendor
{
    internal struct Order<T>
    {
        public T Menu;

        public Order(T menu)
        {
            Menu = menu;
        }
    }
}
