﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using nortWind.Models;

namespace nortWind.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "CategoryName").IsUnique();

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Picture).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Image).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ImageThumbnail).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.BirthDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Extension)
                .HasMaxLength(4)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Photo).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ReportsTo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.EmployeeId, "EmployeeID");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "ShippedDate");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.RequiredDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.ShipAddress)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipCity)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipCountry)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipName)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipPostalCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipRegion)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ShipVia)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ShippedDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PRIMARY");

            entity.ToTable("order details");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UnitPrice).HasPrecision(19, 4);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.HasIndex(e => e.SupplierId, "SupplierID");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Discontinued).HasDefaultValueSql("'0'");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.SupplierId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PRIMARY");

            entity.ToTable("shippers");

            entity.Property(e => e.ShipperId)
                .HasColumnType("int(11)")
                .HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.HomePage).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
