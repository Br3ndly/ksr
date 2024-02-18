using ksr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksr
{
    public class AppDatabase : DbContext
    {
        string connectionString = $"server=localhost; database=dbkasir; UID=root; password=20060126;";
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Penjualan>()
                .HasMany<DetailPenjualan>()
                .WithOne(x=>x.Penjualan).HasForeignKey("PenjualanId");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User {  get; set; }
      public DbSet<Produk> Produk {  get; set; }
      public DbSet<Pelanggan> Pelanggan {  get; set; }
      public DbSet<Penjualan> Penjualan{ get; set; }
      public DbSet<DetailPenjualan> DetailPenjualan { get; set; }
    }
}
