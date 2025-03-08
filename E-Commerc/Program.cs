using E_Commerc.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_Commerc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ECommercContext())
            {
                context.Database.Migrate(); // Apply migrations
            }
            Console.WriteLine("Database created successfully.");
        }
    }
}