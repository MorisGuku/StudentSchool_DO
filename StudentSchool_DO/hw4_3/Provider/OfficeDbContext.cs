using DbModel;
using Microsoft.EntityFrameworkCore;
namespace Provider
{
    public class OfficeDB : DbContext
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbSalesOffice> SalesOffices { get; set; }
        public DbSet<DbCar> Cars { get; set; }
        private const string ConnectionString = @"Server=localhost,1433;Database=HW_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq@;TrustServerCertificate=true";
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

