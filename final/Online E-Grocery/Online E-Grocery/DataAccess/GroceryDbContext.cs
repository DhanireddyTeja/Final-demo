using Microsoft.EntityFrameworkCore;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.DataAccess
{
    public class GroceryDbContext :DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {

        }
        public DbSet<User> user { get; set; }
        public DbSet<Items> item { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Rating> rating { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.itemId).HasColumnName("Item Id");
                entity.Property(e => e.itemName).HasColumnName("Item Name");
                entity.Property(e => e.itemPrice).HasColumnName("Item Price");
                entity.Property(e => e.rating).HasColumnName("Rating");

            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
