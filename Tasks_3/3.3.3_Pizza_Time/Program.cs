using System;
using System.Threading;
using _3._3._3_Pizza_Time.Сustomer;
using _3._3._3_Pizza_Time.Vendor;
using _3._3._3_Pizza_Time.Vendor.Product;

namespace _3._3._3_Pizza_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria(5000);
            Customer customer = new Customer(200);

            Console.WriteLine("Customer did order");
            customer.OrderToPizza(pizzeria, TypePizza.NeapolitanPizza);
            
            Console.WriteLine("Customer got product: " + MonitorCustomerProduct(customer).Product.ToString());

            Console.ReadKey();
        }

        static Customer MonitorCustomerProduct(Customer customer)
        {
            while (customer.Product == null)
            {
                Thread.Sleep(1000);
            }

            return customer;
        }
    }
}
