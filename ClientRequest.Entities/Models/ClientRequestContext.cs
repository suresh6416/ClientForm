using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClientRequest.Entities.Models.Mapping;

namespace ClientRequest.Entities.Models
{
    public partial class ClientRequestContext : DbContext
    {
        static ClientRequestContext()
        {
            Database.SetInitializer<ClientRequestContext>(null);
        }

        public ClientRequestContext()
            : base("Name=ClientRequestContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
