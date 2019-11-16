using AutoService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoService.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autoparts> Autoparts { get; set; }
        public DbSet<Cars> Cars { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TypesAutopart> TypesAutopart { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many [Users-Roles]
            modelBuilder.Entity<UsersRoles>()
                .HasKey(t => new { t.UserId, t.RoleId });
            modelBuilder.Entity<UsersRoles>()
                .HasOne(pt => pt.Users)
                .WithMany(p => p.UsersRoles)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UsersRoles>()
                .HasOne(pt => pt.Roles)
                .WithMany(t => t.UsersRoles)
                .HasForeignKey(pt => pt.RoleId);

            //one to many[Users-Order]
            modelBuilder.Entity<Users>()
                .HasMany(c => c.OrdersClient)
                .WithOne(e => e.Client);

            //one to many[Users-Order]
            modelBuilder.Entity<Users>()
                .HasMany(c => c.OrdersManager)
                .WithOne(e => e.Manager);

            //one to many[Order-AutoParts]
            modelBuilder.Entity<Orders>()
                .HasOne(e => e.Autopart)
                .WithMany(c => c.Order);

            //one to many[Warehouse-AutoParts]
            modelBuilder.Entity<Warehouse>()
                .HasMany(c => c.Autoparts)
                .WithOne(e => e.Warehouse);

            //one to many[Cars-AutoParts]
            modelBuilder.Entity<Cars>()
                .HasMany(c => c.Autoparts)
                .WithOne(e => e.Cars);

            //one to many[TypesAutopart-AutoParts]
            modelBuilder.Entity<TypesAutopart>()
                .HasMany(c => c.Autoparts)
                .WithOne(e => e.TypesAutopart);

        }

        internal bool Find(string email)
        {
            throw new NotImplementedException();
        }

        internal bool Find(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
