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
public class InnerResourceUTest : DbTestFixture
{
    [Test]
    public async Task Machine_Create_DoesCreate()
    {
        //Arrange

        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };

        //Act

        await innerResource.Create(DbContext);

        var dbInnerResource = DbContext.InnerResources.AsNoTracking().First();
        var machinelList = DbContext.InnerResources.AsNoTracking().ToList();

        //Assert

        Assert.That(dbInnerResource, Is.Not.Null);
        Assert.That(dbInnerResource.Id, Is.Not.Null);

        Assert.That(machinelList.Count(), Is.EqualTo(1));
        Assert.That(dbInnerResource.CreatedAt.ToString(), Is.EqualTo(innerResource.CreatedAt.ToString()));
        Assert.That(dbInnerResource.Version, Is.EqualTo(innerResource.Version));
        Assert.That(dbInnerResource.UpdatedAt.ToString(), Is.EqualTo(innerResource.UpdatedAt.ToString()));
        Assert.That(Constants.WorkflowStates.Created, Is.EqualTo(dbInnerResource.WorkflowState));
        Assert.That(dbInnerResource.CreatedByUserId, Is.EqualTo(innerResource.CreatedByUserId));
        Assert.That(dbInnerResource.UpdatedByUserId, Is.EqualTo(innerResource.UpdatedByUserId));
        Assert.That(dbInnerResource.Name, Is.EqualTo(innerResource.Name));
    }

    [Test]
    public async Task Machine_Update_DoesUpdate()
    {
        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };

        DbContext.InnerResources.Add(innerResource);
        await DbContext.SaveChangesAsync();

        //Act

        innerResource.Name = Guid.NewGuid().ToString();

        await innerResource.Update(DbContext);

        var dbInnerResource = DbContext.InnerResources.AsNoTracking().First();
        var machinelList = DbContext.InnerResources.AsNoTracking().ToList();
        var machineVersions = DbContext.InnerResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbInnerResource, Is.Not.Null);
        Assert.That(dbInnerResource.Id, Is.Not.Null);

        Assert.That(machinelList.Count(), Is.EqualTo(1));
        Assert.That(machineVersions.Count(), Is.EqualTo(1));

        Assert.That(dbInnerResource.CreatedAt.ToString(), Is.EqualTo(innerResource.CreatedAt.ToString()));
        Assert.That(dbInnerResource.Version, Is.EqualTo(innerResource.Version));
        Assert.That(dbInnerResource.UpdatedAt.ToString(), Is.EqualTo(innerResource.UpdatedAt.ToString()));
        Assert.That(dbInnerResource.CreatedByUserId, Is.EqualTo(innerResource.CreatedByUserId));
        Assert.That(dbInnerResource.UpdatedByUserId, Is.EqualTo(innerResource.UpdatedByUserId));
        Assert.That(dbInnerResource.Name, Is.EqualTo(innerResource.Name));
    }

    [Test]
    public async Task Machine_Delete_SetWorkflowStateToRemoved()
    {
        //Arrange

        var innerResource = new InnerResource
        {
            Name = Guid.NewGuid().ToString()
        };

        DbContext.InnerResources.Add(innerResource);
        await DbContext.SaveChangesAsync();

        //Act

        await innerResource.Delete(DbContext);

        var dbInnerResource = DbContext.InnerResources.AsNoTracking().First();
        var machinelList = DbContext.InnerResources.AsNoTracking().ToList();
        var machineVersions = DbContext.InnerResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbInnerResource, Is.Not.Null);
        Assert.That(dbInnerResource.Id, Is.Not.Null);

        Assert.That(machinelList.Count(), Is.EqualTo(1));
        Assert.That(machineVersions.Count(), Is.EqualTo(1));

        Assert.That(dbInnerResource.CreatedAt.ToString(), Is.EqualTo(innerResource.CreatedAt.ToString()));
        Assert.That(dbInnerResource.Version, Is.EqualTo(innerResource.Version));
        Assert.That(dbInnerResource.UpdatedAt.ToString(), Is.EqualTo(innerResource.UpdatedAt.ToString()));
        Assert.That(dbInnerResource.CreatedByUserId, Is.EqualTo(innerResource.CreatedByUserId));
        Assert.That(dbInnerResource.UpdatedByUserId, Is.EqualTo(innerResource.UpdatedByUserId));
        Assert.That(dbInnerResource.Name, Is.EqualTo(innerResource.Name));

        Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(dbInnerResource.WorkflowState));
    }
}