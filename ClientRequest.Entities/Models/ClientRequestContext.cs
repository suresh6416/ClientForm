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

        public DbSet<Client> Clients { get; set; }
        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestStatu> RequestStatus { get; set; }
        public DbSet<StatusLookup> StatusLookups { get; set; }
        public DbSet<WorkLocationLookup> WorkLocationLookups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new JobNatureMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new RequestMap());
            modelBuilder.Configurations.Add(new RequestStatuMap());
            modelBuilder.Configurations.Add(new StatusLookupMap());
            modelBuilder.Configurations.Add(new WorkLocationLookupMap());
        }
    }
}
