﻿using DbModel;
using Microsoft.EntityFrameworkCore;
namespace Provider
{
    public class OfficeDB : DbContext
    {
        private const string ConnectionString = @"Server=localhost,10001;Database=HW_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq!;TrustServerCertificate=true;MultiSubnetFailover=True;";
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbSalesOffice> SalesOffices { get; set; }
        public DbSet<DbCar> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
              .HasKey(u => u.UserId);
            modelBuilder.Entity<DbSalesOffice>()
              .HasKey(s => s.Id);
            modelBuilder.Entity<DbCar>()
              .HasKey(c => c.Id);
        }

    }
}

