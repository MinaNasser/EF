using E_Commerc.Context;
using E_Commerc.Entites; // Note: corrected 'Entites' to 'Entities'
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerc
{

    public class Program
    {
        public static void Main()
        {
            using (var db = new ECommercContext())
            {
                db.Database.Migrate();

                var orderDetails = db.OrderDetails
                    .Where(o => o.Quantity == 5)
                    .ToList();

                Console.WriteLine($"Found {orderDetails.Count} orders with quantity 5");

                // Call the methods with the context
                OrderDetailsLoad(orderDetails, db);
                AddNewOrder(db);          // New method
                AddNewProduct(db);        // New method
                AddNewOrderDetail(db);
            }
            Console.WriteLine("Database operations completed successfully.");
        }

        // Existing OrderDetailsLoad method (unchanged)
        public static void OrderDetailsLoad(List<OrderDetail> orderDetails, ECommercContext db)
        {
            try
            {
                foreach (var orderDetail in orderDetails)
                {
                    Console.WriteLine($"Processing OrderDetail - ID: {orderDetail.Id}, " +
                                    $"OrderId: {orderDetail.OrderId}, " +
                                    $"ProductId: {orderDetail.ProductId}, " +
                                    $"Quantity: {orderDetail.Quantity}, " +
                                    $"UnitPrice: {orderDetail.UnitPrice}");

                    orderDetail.Quantity += 1;
                    orderDetail.UnitPrice *= 1.1m;

                    if (orderDetail.Order == null)
                    {
                        db.Entry(orderDetail)
                          .Reference(o => o.Order)
                          .Load();
                        Console.WriteLine($"Loaded Order: {orderDetail.Order?.Id}");
                    }

                    if (orderDetail.Product == null)
                    {
                        db.Entry(orderDetail)
                          .Reference(o => o.Product)
                          .Load();
                        Console.WriteLine($"Loaded Product: {orderDetail.Product?.Id}");
                    }

                    db.OrderDetails.Update(orderDetail);
                }

                int recordsAffected = db.SaveChanges();
                Console.WriteLine($"Updated {recordsAffected} existing order details");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order details: {ex.Message}");
            }
        }

        // New method to add an Order
        public static void AddNewOrder(ECommercContext db)
        {
            try
            {
                var newOrder = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    TotalAmount = 0m // Will be updated when order details are added
                };

                db.Orders.Add(newOrder);
                int recordsAffected = db.SaveChanges();

                Console.WriteLine($"Added {recordsAffected} new order with ID: {newOrder.Id}");
                Console.WriteLine($"New Order - Date: {newOrder.OrderDate}, " +
                                $"CustomerId: {newOrder.CustomerId}, " +
                                $"TotalAmount: {newOrder.TotalAmount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new order: {ex.Message}");
            }
        }

        // New method to add a Product
        public static void AddNewProduct(ECommercContext db)
        {
            try
            {
                var newProduct = new Product
                {
                    Name = "Sample Product",
                    
                    Price = 49.99m,
                    StockQuantity = 100
                };

                db.Products.Add(newProduct);
                int recordsAffected = db.SaveChanges();

                Console.WriteLine($"Added {recordsAffected} new product with ID: {newProduct.Id}");
                Console.WriteLine($"New Product - Name: {newProduct.Name}, " +
                                $"Price: {newProduct.Price}, " +
                                $"Stock: {newProduct.StockQuantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new product: {ex.Message}");
            }
        }

        // Existing AddNewOrderDetail method (slightly modified to use new product price)
        public static void AddNewOrderDetail(ECommercContext db)
        {
            try
            {
                var firstOrder = db.Orders.FirstOrDefault();
                var firstProduct = db.Products.FirstOrDefault();

                if (firstOrder == null || firstProduct == null)
                {
                    Console.WriteLine("Cannot add OrderDetail: No Orders or Products found in database");
                    return;
                }

                var newOrderDetail = new OrderDetail
                {
                    OrderId = firstOrder.Id,
                    ProductId = firstProduct.Id,
                    Quantity = 2,
                    UnitPrice = firstProduct.Price // Use product's price
                };

                db.OrderDetails.Add(newOrderDetail);
                int recordsAffected = db.SaveChanges();

                Console.WriteLine($"Added {recordsAffected} new order detail with ID: {newOrderDetail.Id}");
                Console.WriteLine($"New OrderDetail - OrderId: {newOrderDetail.OrderId}, " +
                                $"ProductId: {newOrderDetail.ProductId}, " +
                                $"Quantity: {newOrderDetail.Quantity}, " +
                                $"UnitPrice: {newOrderDetail.UnitPrice}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new order detail: {ex.Message}");
            }
        }
    }
}