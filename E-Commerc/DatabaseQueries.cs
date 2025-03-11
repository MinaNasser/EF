using E_Commerc.Context;
using E_Commerc.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerc
{
    public class DatabaseQueries
    {
        private readonly ECommercContext _db;

        public DatabaseQueries(ECommercContext db)

        {
            _db = db;
        }


        public void GetCustomers()
        {
            //egar loding 
            var customers = _db.Customers;
            Console.WriteLine("\n🔹 Customers List:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
            }

        }

        public void GetOrders()
        {
            var orders = _db.Orders.Include(o => o.Customer).ToList();
            Console.WriteLine("\n🔹 Orders List:");
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Customer: {order.Customer.Name}, Date: {order.OrderDate}, Total: {order.TotalAmount}");
            }
        }
        public void GetOrderDetails()
        {
            var orderDetails = _db.OrderDetails.Include(od => od.Order).Include(od => od.Product).ToList();
            Console.WriteLine("\n🔹 Order Details:");
            foreach (var detail in orderDetails)
            {
                Console.WriteLine($"Order ID: {detail.OrderId}, Product: {detail.Product.Name}, Quantity: {detail.Quantity}, Price: {detail.UnitPrice}");
            }
        }
        public void GetProducts()
        {
            var products = _db.Products.ToList();
            Console.WriteLine("\n🔹 Products List:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.StockQuantity}");
            }
        }

        public void GetSpecificProduct(string productName)
        {
            var product = _db.Products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                Console.WriteLine($"\n✅ Found Product: {product.Name} - ${product.Price}");
            }
            else
            {
                Console.WriteLine("\n❌ Product not found!");
            }
        }
    }
}
