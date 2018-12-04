﻿using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using FastFood.Data.EntityConfiguration;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

	    public DbSet<Employee> Employees { get; set; }

	    public DbSet<Position> Positions { get; set; }

	    public DbSet<Category> Categories { get; set; }

	    public DbSet<Item> Items { get; set; }

	    public DbSet<Order> Orders { get; set; }

	    public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
		{
		    builder.ApplyConfiguration(new EmployeeConfig());

		    builder.ApplyConfiguration(new PositionConfig());

		    builder.ApplyConfiguration(new CategoryConfig());

		    builder.ApplyConfiguration(new ItemConfig());

		    builder.ApplyConfiguration(new OrderConfig());

		    builder.ApplyConfiguration(new OrderItemConfig());
        }
        
	}
}