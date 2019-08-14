using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SellContracts.Models
{
    public class SaleContext:DbContext
    {
        public SaleContext() :
        base("DefaultConnection")
        { }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}