using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tablolari ile proje classlarini baglar
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }//hangi class hangi tabloya denk geliyor
        public DbSet<Category>  Categories{ get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
