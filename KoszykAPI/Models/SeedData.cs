using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using KoszykAPI;

namespace KoszykAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KoszykContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<KoszykContext>>()))
            {
                // Look for any movies.
                if (context.KoszykItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.KoszykItems.AddRange(
                    new KoszykItem
                    {
                        Id = 1,
                        Name = "Płyta główna MSI Z270 M5",
                        Price = 680,
                        Promotion = "10%",
                        Quantity = 1,
                        InStock = true
                    },

                    new KoszykItem
                    {
                        Id = 2,
                        Name = "Procesor Intel i9-9900k",
                        Price = 1450,
                        Promotion = "5%",
                        Quantity = 1,
                        InStock = true
                    },

                    new KoszykItem
                    {
                        Id = 3,
                        Name = "Dysk SSD 250GB",
                        Price = 280,
                        Promotion = "-",
                        Quantity = 2,
                        InStock = true
                    },

                    new KoszykItem
                    {
                        Id = 4,
                        Name = "Karta Graficzna GeForce RTX 3080",
                        Price = 9000,
                        Promotion = "5%",
                        Quantity = 1,
                        InStock = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
