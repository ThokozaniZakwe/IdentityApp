﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Kayak", Category = "Watersports", Price = 275 },
                new Product { Id = 2, Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
                new Product { Id = 3, Name = "Soccer Ball", Category = "Soccer", Price = 19.50M },
                new Product { Id = 4, Name = "Corner Flags", Category = "Soccer", Price = 34.95M },
                new Product { Id = 5, Name = "Stadium", Category = "Soccer", Price = 79500 },
                new Product { Id = 6, Name = "Thinking Cap", Category = "Chess", Price = 16 },
                new Product { Id = 7, Name = "Unsteady Chair", Category = "Chess", Price = 29.95M },
                new Product { Id = 8, Name = "Human Chess Board", Category = "Chess", Price = 75 },
                new Product { Id = 9, Name = "Bling-bling King", Category = "Chess", Price = 1200 }
                );
        }
    }
}
