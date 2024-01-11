﻿using BlazorShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}