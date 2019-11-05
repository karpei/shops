using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;MultipleActiveResultSets=true; ");
        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
    }

}
