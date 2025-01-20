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
public class OuterResourceUTest : DbTestFixture
{
    [Test]
    public async Task Area_Create_DoesCreate()
    {
        //Arrange

        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };

        //Act

        await outerResource.Create(DbContext);

        var dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
        var areaList = DbContext.OuterResources.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterResource, Is.Not.Null);
        Assert.That(dbOuterResource.Id, Is.Not.Null);

        Assert.That(areaList.Count(), Is.EqualTo(1));
        Assert.That(dbOuterResource.CreatedAt.ToString(), Is.EqualTo(outerResource.CreatedAt.ToString()));
        Assert.That(dbOuterResource.Version, Is.EqualTo(outerResource.Version));
        Assert.That(dbOuterResource.UpdatedAt.ToString(), Is.EqualTo(outerResource.UpdatedAt.ToString()));
        Assert.That(Constants.WorkflowStates.Created, Is.EqualTo(dbOuterResource.WorkflowState));
        Assert.That(dbOuterResource.CreatedByUserId, Is.EqualTo(outerResource.CreatedByUserId));
        Assert.That(dbOuterResource.UpdatedByUserId, Is.EqualTo(outerResource.UpdatedByUserId));
        Assert.That(dbOuterResource.Name, Is.EqualTo(outerResource.Name));
    }

    [Test]
    public async Task Area_Update_DoesUpdate()
    {
        //Arrange

        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };

        DbContext.OuterResources.Add(outerResource);
        await DbContext.SaveChangesAsync();

        //Act

        outerResource.Name = Guid.NewGuid().ToString();

        await outerResource.Update(DbContext);

        var dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
        var areasList = DbContext.OuterResources.AsNoTracking().ToList();
        var areaVersions = DbContext.OuterResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterResource, Is.Not.Null);

        Assert.That(areasList.Count(), Is.EqualTo(1));
        Assert.That(areaVersions.Count(), Is.EqualTo(1));
        Assert.That(dbOuterResource.Name, Is.EqualTo(outerResource.Name));
        Assert.That(dbOuterResource.CreatedAt.ToString(), Is.EqualTo(outerResource.CreatedAt.ToString()));
        Assert.That(dbOuterResource.Version, Is.EqualTo(outerResource.Version));
        Assert.That(dbOuterResource.UpdatedAt.ToString(), Is.EqualTo(outerResource.UpdatedAt.ToString()));
        Assert.That(dbOuterResource.CreatedByUserId, Is.EqualTo(outerResource.CreatedByUserId));
        Assert.That(dbOuterResource.UpdatedByUserId, Is.EqualTo(outerResource.UpdatedByUserId));
    }

    [Test]
    public async Task Area_Delete_DoesSetWorkflowStateToRemoved()
    {
        //Arrange

        var outerResource = new OuterResource
        {
            Name = Guid.NewGuid().ToString()
        };

        DbContext.OuterResources.Add(outerResource);
        await DbContext.SaveChangesAsync();

        //Act
        await outerResource.Delete(DbContext);

        var dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
        var areaList = DbContext.OuterResources.AsNoTracking().ToList();
        var areaVersions = DbContext.OuterResourceVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbOuterResource, Is.Not.Null);

        Assert.That(areaList.Count(), Is.EqualTo(1));
        Assert.That(areaVersions.Count(), Is.EqualTo(1));

        Assert.That(dbOuterResource.Name, Is.EqualTo(outerResource.Name));
        Assert.That(dbOuterResource.CreatedAt.ToString(), Is.EqualTo(outerResource.CreatedAt.ToString()));
        Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(dbOuterResource.WorkflowState));

        Assert.That(dbOuterResource.Version, Is.EqualTo(outerResource.Version));
        Assert.That(dbOuterResource.UpdatedAt.ToString(), Is.EqualTo(outerResource.UpdatedAt.ToString()));
        Assert.That(dbOuterResource.CreatedByUserId, Is.EqualTo(outerResource.CreatedByUserId));
        Assert.That(dbOuterResource.UpdatedByUserId, Is.EqualTo(outerResource.UpdatedByUserId));
    }
}