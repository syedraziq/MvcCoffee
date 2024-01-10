using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCoffee.Data;
using System;
using System.Linq;

namespace MvcCoffee.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCoffeeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCoffeeContext>>()))
            {
                // Look for any movies.
                if (context.Coffee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Coffee.AddRange(
                    new Coffee
                    {
                        Name = "When Harry Met Sally",
                        Descriptions = "",
                        Price = 7.99M,
                        Stock=1
                    },

                    new Coffee
                    {
                        Name = "When Harry Met Sally",
                        Descriptions = "",
                        Price = 7.99M,
                        Stock = 1
                    },

                    new Coffee
                    {
                        Name = "When Harry Met Sally",
                        Descriptions = "",
                        Price = 7.99M,
                        Stock = 1
                    }, 
                    new Coffee
                    {
                        Name = "When Harry Met Sally",
                        Descriptions = "",
                        Price = 7.99M,
                        Stock = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}