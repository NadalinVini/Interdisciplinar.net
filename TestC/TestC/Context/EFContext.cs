using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace TestC.Context
{
    public class EFContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients
        { get; set; }
    }
}