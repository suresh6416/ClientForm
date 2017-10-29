using ClientRequest.Entities.Models;
using ClientRequest.Entities.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Data.Context
{
    public class APIContext : DbContext
    {
        public APIContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
