using System;
using System.Collections.Generic;
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
            List<Customer> customers = new List<Customer>() { new Customer("Andrey", 200) };

            Console.WriteLine($"{customers[0].Name} did order");

            customers[0].OrderToPizza(pizzeria, TypePizza.ChicagoPizza);
            
            Console.WriteLine($"{customers[0].Name} got product: " + MonitorCustomerProduct(customers[0])?.Product.ToString());

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
