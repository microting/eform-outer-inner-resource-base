/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Microsoft.EntityFrameworkCore;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Data;

public class OuterInnerResourcePnDbContext : DbContext, IPluginDbContext
{
    public OuterInnerResourcePnDbContext()
    {
    }

    public OuterInnerResourcePnDbContext(DbContextOptions<OuterInnerResourcePnDbContext> options)
        : base(options)
    {
    }

    public DbSet<InnerResource> InnerResources { get; set; }
    public DbSet<InnerResourceVersion> InnerResourceVersions { get; set; }
    public DbSet<OuterResource> OuterResources { get; set; }
    public DbSet<OuterResourceVersion> OuterResourceVersions { get; set; }
    public DbSet<OuterInnerResource> OuterInnerResources { get; set; }
    public DbSet<OuterInnerResourceSite> OuterInnerResourceSites { get; set; }
    public DbSet<OuterInnerResourceSiteVersion> OuterInnerResourceSiteVersions { get; set; }
    public DbSet<OuterInnerResourceVersion> OuterInnerResourceVersions { get; set; }
    public DbSet<ResourceTimeRegistration> ResourceTimeRegistrations { get; set; }
    public DbSet<ResourceTimeRegistrationVersion> ResourceTimeRegistrationVersions { get; set; }

    // plugin settings
    public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
    public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
    public DbSet<PluginPermission> PluginPermissions { get; set; }
    public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
    public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InnerResource>()
            .HasIndex(x => x.Name);
        modelBuilder.Entity<InnerResource>()
            .HasIndex(x => x.CreatedByUserId);
        modelBuilder.Entity<InnerResource>()
            .HasIndex(x => x.UpdatedByUserId);
        modelBuilder.Entity<OuterResource>()
            .HasIndex(x => x.Name);
        modelBuilder.Entity<OuterResource>()
            .HasIndex(x => x.CreatedByUserId);
        modelBuilder.Entity<OuterResource>()
            .HasIndex(x => x.UpdatedByUserId);
    }
}