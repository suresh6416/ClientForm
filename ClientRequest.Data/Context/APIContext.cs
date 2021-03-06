﻿using ClientRequest.Entities.Models;
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
        static APIContext()
        {            
            Database.SetInitializer<APIContext>(null);
        }

        public APIContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<ClientModule> ClientModules { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestStatu> RequestStatus { get; set; }
        public DbSet<StatusLookup> StatusLookups { get; set; }
        public DbSet<WorkLocationLookup> WorkLocationLookups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new ClientModuleMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new JobNatureMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new RequestMap());
            modelBuilder.Configurations.Add(new RequestStatuMap());
            modelBuilder.Configurations.Add(new StatusLookupMap());
            modelBuilder.Configurations.Add(new WorkLocationLookupMap());
        }
    }
}
