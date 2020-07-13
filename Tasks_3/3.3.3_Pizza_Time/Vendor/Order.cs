namespace _3._3._3_Pizza_Time.Vendor
{
    internal struct Order<T,U>
    {
        public T Menu;
        public U CallBackPizza;

        public Order(T menu, U collback)
        {
            Menu = menu;
            CallBackPizza = collback;
        }
    }
}
