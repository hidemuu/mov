﻿using Mov.Bom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Repository.Sql
{
    public class BomDbContext : DbContext
    {
        public BomDbContext() { }
        /// <summary>
        /// Creates a new Contoso DbContext.
        /// </summary>
        public BomDbContext(DbContextOptions<BomDbContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets the orders DbSet.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets the products DbSet.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets the line items DbSet.
        /// </summary>
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}