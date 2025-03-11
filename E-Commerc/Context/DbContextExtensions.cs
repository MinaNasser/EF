using E_Commerc.Entites;
using E_Commerc.Migrations;
using Microsoft.EntityFrameworkCore;

namespace E_Commerc.Context
{
    public static class DbContextExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var fixedOrderDate = new DateTime(2024, 3, 1);
            var fixedShippingDate = new DateTime(2024, 3, 5);
            var fixedStockDate = new DateTime(2024, 2, 28);

            // 🟢 Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123456789" },
                new Customer { Id = 2, Name = "Jane Doe", Email = "jane@example.com", PhoneNumber = "987654321" },
                new Customer { Id = 3, Name = "Alice Brown", Email = "alice@example.com", PhoneNumber = "555123456" },
                new Customer { Id = 4, Name = "Bob Smith", Email = "bob@example.com", PhoneNumber = "666987654" },
                new Customer { Id = 5, Name = "Charlie Johnson", Email = "charlie@example.com", PhoneNumber = "777654321" },
                new Customer { Id = 6, Name = "David Wilson", Email = "david@example.com", PhoneNumber = "888123987" },
                new Customer { Id = 7, Name = "Eve Taylor", Email = "eve@example.com", PhoneNumber = "999654789" },
                new Customer { Id = 8, Name = "Frank White", Email = "frank@example.com", PhoneNumber = "111222333" },
                new Customer { Id = 9, Name = "Grace Hall", Email = "grace@example.com", PhoneNumber = "444555666" },
                new Customer { Id = 10, Name = "Hank Adams", Email = "hank@example.com", PhoneNumber = "777888999" }
            );

            // 🟢 Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1000m, StockQuantity = 50 },
                new Product { Id = 2, Name = "Phone", Price = 500m, StockQuantity = 100 },
                new Product { Id = 3, Name = "Tablet", Price = 300m, StockQuantity = 80 },
                new Product { Id = 4, Name = "Monitor", Price = 200m, StockQuantity = 70 },
                new Product { Id = 5, Name = "Keyboard", Price = 50m, StockQuantity = 150 },
                new Product { Id = 6, Name = "Mouse", Price = 30m, StockQuantity = 200 },
                new Product { Id = 7, Name = "Headphones", Price = 80m, StockQuantity = 120 },
                new Product { Id = 8, Name = "Smart Watch", Price = 150m, StockQuantity = 90 },
                new Product { Id = 9, Name = "Speaker", Price = 60m, StockQuantity = 110 },
                new Product { Id = 10, Name = "USB Drive", Price = 20m, StockQuantity = 300 }
            );

            // 🟢 Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = fixedOrderDate, TotalAmount = 1500m },
                new Order { Id = 2, CustomerId = 2, OrderDate = fixedOrderDate, TotalAmount = 800m },
                new Order { Id = 3, CustomerId = 3, OrderDate = fixedOrderDate, TotalAmount = 600m },
                new Order { Id = 4, CustomerId = 4, OrderDate = fixedOrderDate, TotalAmount = 1200m },
                new Order { Id = 5, CustomerId = 5, OrderDate = fixedOrderDate, TotalAmount = 500m }
            );

            // 🟢 OrderDetails
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1000m },
                new OrderDetail { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 500m },
                new OrderDetail { Id = 3, OrderId = 2, ProductId = 3, Quantity = 2, UnitPrice = 300m },
                new OrderDetail { Id = 4, OrderId = 3, ProductId = 4, Quantity = 1, UnitPrice = 200m },
                new OrderDetail { Id = 5, OrderId = 3, ProductId = 5, Quantity = 2, UnitPrice = 50m }
            );

            // 🟢 Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, OrderId = 1, PaymentMethod = "Credit Card", IsPaid = true },
                new Payment { Id = 2, OrderId = 2, PaymentMethod = "PayPal", IsPaid = true },
                new Payment { Id = 3, OrderId = 3, PaymentMethod = "Bank Transfer", IsPaid = false }
            );

            // 🟢 Shippings
            modelBuilder.Entity<Shipping>().HasData(
                new Shipping { Id = 1, OrderId = 1, Address = "123 Main St, NY", ShippedDate = fixedShippingDate },
                new Shipping { Id = 2, OrderId = 2, Address = "456 Elm St, LA", ShippedDate = fixedShippingDate },
                new Shipping { Id = 3, OrderId = 3, Address = "789 Oak St, TX", ShippedDate = fixedShippingDate }
            );

            // 🟢 StockHistories
            modelBuilder.Entity<StockHistory>().HasData(
                new StockHistory { Id = 1, ProductId = 1, QuantityChanged = -1, ChangeDate = fixedStockDate },
                new StockHistory { Id = 2, ProductId = 2, QuantityChanged = -1, ChangeDate = fixedStockDate },
                new StockHistory { Id = 3, ProductId = 3, QuantityChanged = -2, ChangeDate = fixedStockDate },
                new StockHistory { Id = 4, ProductId = 4, QuantityChanged = -1, ChangeDate = fixedStockDate },
                new StockHistory { Id = 5, ProductId = 5, QuantityChanged = -2, ChangeDate = fixedStockDate }
            );
        }
    }
}
