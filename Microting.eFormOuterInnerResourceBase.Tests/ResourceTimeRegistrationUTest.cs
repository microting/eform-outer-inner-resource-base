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
public class ResourceTimeRegistrationUTest : DbTestFixture
{
    [Test]
    public async Task MachineAreaTimeRegistration_Create_DoesCreate()
    {
        //Arrange

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

        var rnd = new Random();
        var matr = new ResourceTimeRegistration
        {
            DoneAt = DateTime.Now,
            TimeInHours = 10,
            TimeInMinutes = 60,
            TimeInSeconds = 100,
            SDKCaseId = rnd.Next(1, 100),
            SDKSiteId = rnd.Next(1, 100),
            SDKFieldValueId = rnd.Next(1, 100),
            OuterResourceId = outerResource.Id,
            InnerResourceId = innerResource.Id
        };

        //Act

        await matr.Create(DbContext);


        var dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
        var matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();

        //Assert

        Assert.That(dbMatr, Is.Not.Null);

        Assert.That(dbMatr.DoneAt.ToString(), Is.EqualTo(matr.DoneAt.ToString()));
        Assert.That(dbMatr.TimeInHours, Is.EqualTo(matr.TimeInHours));
        Assert.That(dbMatr.TimeInMinutes, Is.EqualTo(matr.TimeInMinutes));
        Assert.That(dbMatr.TimeInSeconds, Is.EqualTo(matr.TimeInSeconds));
        Assert.That(dbMatr.SDKCaseId, Is.EqualTo(matr.SDKCaseId));
        Assert.That(dbMatr.SDKSiteId, Is.EqualTo(matr.SDKSiteId));
        Assert.That(dbMatr.SDKFieldValueId, Is.EqualTo(matr.SDKFieldValueId));
        Assert.That(dbMatr.OuterResourceId, Is.EqualTo(matr.OuterResourceId));
        Assert.That(dbMatr.InnerResourceId, Is.EqualTo(matr.InnerResourceId));

        Assert.That(matrList.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task MacineAreaTimeRegistration_Update_DoesUpdate()
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

        var rnd = new Random();
        var matr = new ResourceTimeRegistration
        {
            DoneAt = DateTime.Now,
            TimeInHours = 10,
            TimeInMinutes = 60,
            TimeInSeconds = 100,
            SDKCaseId = rnd.Next(1, 100),
            SDKSiteId = rnd.Next(1, 100),
            SDKFieldValueId = rnd.Next(1, 100),
            OuterResourceId = outerResource.Id,
            InnerResourceId = innerResource.Id
        };

        DbContext.ResourceTimeRegistrations.Add(matr);
        await DbContext.SaveChangesAsync();

        //Act
        matr.TimeInHours = 20;

        await matr.Update(DbContext);

        var dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
        var matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();
        var matrVersions =
            DbContext.ResourceTimeRegistrationVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbMatr, Is.Not.Null);

        Assert.That(dbMatr.DoneAt.ToString(), Is.EqualTo(matr.DoneAt.ToString()));
        Assert.That(dbMatr.TimeInHours, Is.EqualTo(matr.TimeInHours));
        Assert.That(dbMatr.TimeInMinutes, Is.EqualTo(matr.TimeInMinutes));
        Assert.That(dbMatr.TimeInSeconds, Is.EqualTo(matr.TimeInSeconds));
        Assert.That(dbMatr.SDKCaseId, Is.EqualTo(matr.SDKCaseId));
        Assert.That(dbMatr.SDKSiteId, Is.EqualTo(matr.SDKSiteId));
        Assert.That(dbMatr.SDKFieldValueId, Is.EqualTo(matr.SDKFieldValueId));
        Assert.That(dbMatr.OuterResourceId, Is.EqualTo(matr.OuterResourceId));
        Assert.That(dbMatr.InnerResourceId, Is.EqualTo(matr.InnerResourceId));

        Assert.That(matrList.Count(), Is.EqualTo(1));
        Assert.That(matrVersions.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task MachineAreaTimeRegistration_Delete_DoesSetWorkflowStateToRemoved()
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

        var rnd = new Random();
        var matr = new ResourceTimeRegistration
        {
            DoneAt = DateTime.Now,
            TimeInHours = 10,
            TimeInMinutes = 60,
            TimeInSeconds = 100,
            SDKCaseId = rnd.Next(1, 100),
            SDKSiteId = rnd.Next(1, 100),
            SDKFieldValueId = rnd.Next(1, 100),
            OuterResourceId = outerResource.Id,
            InnerResourceId = innerResource.Id
        };

        DbContext.ResourceTimeRegistrations.Add(matr);
        await DbContext.SaveChangesAsync();

        //Act
        matr.TimeInHours = 20;

        await matr.Delete(DbContext);

        var dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
        var matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();
        var matrVersions =
            DbContext.ResourceTimeRegistrationVersions.AsNoTracking().ToList();

        //Assert

        Assert.That(dbMatr, Is.Not.Null);
        Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(dbMatr.WorkflowState));

        Assert.That(dbMatr.DoneAt.ToString(), Is.EqualTo(matr.DoneAt.ToString()));
        Assert.That(dbMatr.TimeInHours, Is.EqualTo(matr.TimeInHours));
        Assert.That(dbMatr.TimeInMinutes, Is.EqualTo(matr.TimeInMinutes));
        Assert.That(dbMatr.TimeInSeconds, Is.EqualTo(matr.TimeInSeconds));
        Assert.That(dbMatr.SDKCaseId, Is.EqualTo(matr.SDKCaseId));
        Assert.That(dbMatr.SDKSiteId, Is.EqualTo(matr.SDKSiteId));
        Assert.That(dbMatr.SDKFieldValueId, Is.EqualTo(matr.SDKFieldValueId));
        Assert.That(dbMatr.OuterResourceId, Is.EqualTo(matr.OuterResourceId));
        Assert.That(dbMatr.InnerResourceId, Is.EqualTo(matr.InnerResourceId));

        Assert.That(matrList.Count(), Is.EqualTo(1));
        Assert.That(matrVersions.Count(), Is.EqualTo(1));
    }
}