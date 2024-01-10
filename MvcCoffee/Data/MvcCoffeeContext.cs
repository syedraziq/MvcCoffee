using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCoffee.Models;

namespace MvcCoffee.Data
{
    public class MvcCoffeeContext : DbContext
    {
        public MvcCoffeeContext (DbContextOptions<MvcCoffeeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCoffee.Models.Coffee> Coffee { get; set; } = default!;
        public DbSet<Tea> Tea { get; set; } = default!;
        public DbSet<Dessert> Dessert { get; set; } = default!;
    }
}
