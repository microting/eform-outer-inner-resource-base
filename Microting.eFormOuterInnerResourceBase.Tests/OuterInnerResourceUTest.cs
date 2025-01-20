using System;
using System.Linq;
using System.Threading.Tasks;
using eFormMachineAreaDotnet.Tests;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eForm_MachineArea_dotnet.Tests;

[TestFixture]
public class OuterInnerResourceUTest : DbTestFixture
{
    [Test]
    public async Task MachineArea_Create_DoesCreate()
    {
        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };
        await outerResource.Create(DbContext);

        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };
        await innerResource.Create(DbContext);

        var outerInnerResource = new OuterInnerResource
        {
            OuterResourceId = outerResource.Id,
            InnerResourceId = innerResource.Id
        };

        //Act

        await outerInnerResource.Create(DbContext);

        var dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
        var machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterInnerResource, Is.Not.Null);
        Assert.That(dbOuterInnerResource.Id, Is.Not.Null);

        Assert.That(outerResource.Id, Is.EqualTo(outerInnerResource.OuterResourceId));
        Assert.That(innerResource.Id, Is.EqualTo(outerInnerResource.InnerResourceId));

        Assert.That(machineAreaList.Count(), Is.EqualTo(1));
        Assert.That(dbOuterInnerResource.CreatedAt.ToString(), Is.EqualTo(outerInnerResource.CreatedAt.ToString()));
        Assert.That(dbOuterInnerResource.Version, Is.EqualTo(outerInnerResource.Version));
        Assert.That(dbOuterInnerResource.UpdatedAt.ToString(), Is.EqualTo(outerInnerResource.UpdatedAt.ToString()));
        Assert.That(Constants.WorkflowStates.Created, Is.EqualTo(dbOuterInnerResource.WorkflowState));
        Assert.That(dbOuterInnerResource.CreatedByUserId, Is.EqualTo(outerInnerResource.CreatedByUserId));
        Assert.That(dbOuterInnerResource.UpdatedByUserId, Is.EqualTo(outerInnerResource.UpdatedByUserId));
    }

    [Test]
    public async Task MachineArea_Update_DoesUpdate()
    {
        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };
        DbContext.OuterResources.Add(outerResource);
        await DbContext.SaveChangesAsync();

        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };
        DbContext.InnerResources.Add(innerResource);
        await DbContext.SaveChangesAsync();

        var outerInnerResource = new OuterInnerResource
        {
            OuterResourceId = outerResource.Id,
            InnerResourceId = innerResource.Id
        };

        DbContext.OuterInnerResources.Add(outerInnerResource);
        await DbContext.SaveChangesAsync();

        //Act

        var newOuterResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };
        DbContext.OuterResources.Add(newOuterResource);
        await DbContext.SaveChangesAsync();

        outerInnerResource.OuterResourceId = newOuterResource.Id;
        await outerInnerResource.Update(DbContext);

        var dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
        var machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();
        var machineAreaVersions = DbContext.OuterInnerResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterInnerResource, Is.Not.Null);
        Assert.That(dbOuterInnerResource.Id, Is.Not.Null);

        Assert.That(newOuterResource.Id, Is.EqualTo(dbOuterInnerResource.OuterResourceId));
        Assert.That(innerResource.Id, Is.EqualTo(dbOuterInnerResource.InnerResourceId));

        Assert.That(machineAreaList.Count(), Is.EqualTo(1));
        Assert.That(machineAreaVersions.Count(), Is.EqualTo(1));

        Assert.That(dbOuterInnerResource.CreatedAt.ToString(), Is.EqualTo(outerInnerResource.CreatedAt.ToString()));
        Assert.That(dbOuterInnerResource.Version, Is.EqualTo(outerInnerResource.Version));
        Assert.That(dbOuterInnerResource.UpdatedAt.ToString(), Is.EqualTo(outerInnerResource.UpdatedAt.ToString()));
        Assert.That(dbOuterInnerResource.CreatedByUserId, Is.EqualTo(outerInnerResource.CreatedByUserId));
        Assert.That(dbOuterInnerResource.UpdatedByUserId, Is.EqualTo(outerInnerResource.UpdatedByUserId));
    }

    [Test]
    public async Task MachineArea_Delete_DoesSetWorkflowStateToRemoved()
    {
        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };
        DbContext.OuterResources.Add(outerResource);
        await DbContext.SaveChangesAsync();

        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };
        DbContext.InnerResources.Add(innerResource);
        await DbContext.SaveChangesAsync();

        var outerInnerResource = new OuterInnerResource();

        outerInnerResource.OuterResourceId = outerResource.Id;
        outerInnerResource.InnerResourceId = innerResource.Id;

        DbContext.OuterInnerResources.Add(outerInnerResource);
        await DbContext.SaveChangesAsync();

        //Act

        await outerInnerResource.Delete(DbContext);

        var dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
        var machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();
        var machineAreaVersions = DbContext.OuterInnerResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterInnerResource, Is.Not.Null);
        Assert.That(dbOuterInnerResource.Id, Is.Not.Null);

        Assert.That(innerResource.Id, Is.EqualTo(dbOuterInnerResource.InnerResourceId));
        Assert.That(outerResource.Id, Is.EqualTo(dbOuterInnerResource.OuterResourceId));

        Assert.That(machineAreaList.Count(), Is.EqualTo(1));
        Assert.That(machineAreaVersions.Count(), Is.EqualTo(1));

        Assert.That(dbOuterInnerResource.CreatedAt.ToString(), Is.EqualTo(outerInnerResource.CreatedAt.ToString()));
        Assert.That(dbOuterInnerResource.Version, Is.EqualTo(outerInnerResource.Version));
        Assert.That(dbOuterInnerResource.UpdatedAt.ToString(), Is.EqualTo(outerInnerResource.UpdatedAt.ToString()));
        Assert.That(dbOuterInnerResource.CreatedByUserId, Is.EqualTo(outerInnerResource.CreatedByUserId));
        Assert.That(dbOuterInnerResource.UpdatedByUserId, Is.EqualTo(outerInnerResource.UpdatedByUserId));
        Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(dbOuterInnerResource.WorkflowState));
    }
}