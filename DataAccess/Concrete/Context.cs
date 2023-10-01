using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-TP3O7NB\\SQLEXPRESS;database=OkraDb;integrated security=true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Foot> Feet { get; set; }
        public DbSet<FootColor> FootColors { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Proforma> Proformas { get; set; }
    }
}
