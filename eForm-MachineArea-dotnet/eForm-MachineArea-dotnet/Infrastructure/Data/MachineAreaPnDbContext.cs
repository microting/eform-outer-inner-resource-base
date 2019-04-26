using Microsoft.EntityFrameworkCore;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.eFormMachineAreaBase.Infrastructure.Data.Entities;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data
{
    public class MachineAreaPnDbContext : DbContext, IPluginDbContext
    {

        public MachineAreaPnDbContext() { }

        public MachineAreaPnDbContext(DbContextOptions<MachineAreaPnDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineVersion> MachineVersions { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaVersion> AreaVersions { get; set; }
        public DbSet<MachineArea> MachineAreas { get; set; }
        public DbSet<MachineAreaSite> MachineAreaSites { get; set; }
        public DbSet<MachineAreaSiteVersion> MachineAreaSiteVersions { get; set; }
        public DbSet<MachineAreaVersion> MachineAreaVersions { get; set; }
        public DbSet<MachineAreaTimeRegistration> MachineAreaTimeRegistrations { get; set; }
        public DbSet<MachineAreaTimeRegistrationVersion> MachineAreaTimeRegistrationVersions { get; set; }
        
        // plugin settings
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Machine>()
                .HasIndex(x => x.Name);
            modelBuilder.Entity<Machine>()
                .HasIndex(x => x.CreatedByUserId);
            modelBuilder.Entity<Machine>()
                .HasIndex(x => x.UpdatedByUserId);
            modelBuilder.Entity<Area>()
                .HasIndex(x => x.Name);
            modelBuilder.Entity<Area>()
                .HasIndex(x => x.CreatedByUserId);
            modelBuilder.Entity<Area>()
                .HasIndex(x => x.UpdatedByUserId);
        }
    }
}