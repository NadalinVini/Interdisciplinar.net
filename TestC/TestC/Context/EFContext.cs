using System.Data.Entity;
using TestC.Models;

namespace TestC.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}