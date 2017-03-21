using HotStuffPizzaAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HotStuffPizzaAPI.DAL
{
    public class HotStuffPizzaContext : DbContext
    {
        public HotStuffPizzaContext() : base("HotStuffContext") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Reciepe> Reciepes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductReciepe> ProductReciepes { get; set; }
    }
}