using Microsoft.EntityFrameworkCore;
using Microting.eFormMachineAreaBase.Infrastructure.Data.Entities;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data
{
    public class MachineAreaPnDbContext : DbContext
    {

        public MachineAreaPnDbContext() { }

        public MachineAreaPnDbContext(DbContextOptions options) : base(options)
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
        public DbSet<MachineAreaSetting> MachineAreaSettings { get; set; }
        public DbSet<MachineAreaSettingVersion> MachineAreaSettingVersions { get; set; }
        public DbSet<MachineAreaTimeRegistration> MachineAreaTimeRegistrations { get; set; }
        public DbSet<MachineAreaTimeRegistrationVersion> MachineAreaTimeRegistrationVersions { get; set; }

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