using CuaHang.model;
using CuaHang.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CuaHang.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<AccountModel> Account { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonDatHang> DonDatHang { get; set; }
        public virtual DbSet<ImageProduct> ImageProduct { get; set; }
        public virtual DbSet<KhanhHang> KhanhHang { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        /*public virtual DbSet<GioHang> GioHang { get; set; }*/
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<AccountModel>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.IDBrand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonDatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhanhHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhanhHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhanhHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhanhHang>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhanhHang>()
                .HasMany(e => e.DonDatHang)
                .WithOptional(e => e.KhanhHang)
                .HasForeignKey(e => e.MaKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.MaSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ImageProduct)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);
        }
    }
}
