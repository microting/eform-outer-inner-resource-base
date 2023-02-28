using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFormMachineAreaDotnet.Tests;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eForm_MachineArea_dotnet.Tests
{
    [TestFixture]
    public class ResourceTimeRegistrationUTest : DbTestFixture
    {
        [Test]
        public async Task MachineAreaTimeRegistration_Create_DoesCreate()
        {
            //Arrange

            OuterResource outerResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };
            await outerResource.Create(DbContext);

            InnerResource innerResource = new InnerResource
            {
                Name = Guid.NewGuid().ToString()
            };
            await innerResource.Create(DbContext);

            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration
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


            ResourceTimeRegistration dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
            List<ResourceTimeRegistration> matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbMatr);

            Assert.AreEqual(matr.DoneAt.ToString(), dbMatr.DoneAt.ToString());
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.OuterResourceId, dbMatr.OuterResourceId);
            Assert.AreEqual(matr.InnerResourceId, dbMatr.InnerResourceId);

            Assert.AreEqual(1,matrList.Count());
        }

        [Test]
        public async Task MacineAreaTimeRegistration_Update_DoesUpdate()
        {
            OuterResource outerResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(outerResource);
            await DbContext.SaveChangesAsync();

            InnerResource innerResource = new InnerResource
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.InnerResources.Add(innerResource);
            await DbContext.SaveChangesAsync();

            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration
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

            ResourceTimeRegistration dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
            List<ResourceTimeRegistration> matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();
            List<ResourceTimeRegistrationVersion> matrVersions =
                DbContext.ResourceTimeRegistrationVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbMatr);

            Assert.AreEqual(matr.DoneAt.ToString(), dbMatr.DoneAt.ToString());
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.OuterResourceId, dbMatr.OuterResourceId);
            Assert.AreEqual(matr.InnerResourceId, dbMatr.InnerResourceId);

            Assert.AreEqual(1,matrList.Count());
            Assert.AreEqual(1, matrVersions.Count());
        }

        [Test]
        public async Task MachineAreaTimeRegistration_Delete_DoesSetWorkflowStateToRemoved()
        {
             OuterResource outerResource = new OuterResource
             {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(outerResource);
            await DbContext.SaveChangesAsync();

            InnerResource innerResource = new InnerResource
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.InnerResources.Add(innerResource);
            await DbContext.SaveChangesAsync();

            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration
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

            ResourceTimeRegistration dbMatr = DbContext.ResourceTimeRegistrations.AsNoTracking().First();
            List<ResourceTimeRegistration> matrList = DbContext.ResourceTimeRegistrations.AsNoTracking().ToList();
            List<ResourceTimeRegistrationVersion> matrVersions =
                DbContext.ResourceTimeRegistrationVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbMatr);
            Assert.AreEqual(dbMatr.WorkflowState, Constants.WorkflowStates.Removed);

            Assert.AreEqual(matr.DoneAt.ToString(), dbMatr.DoneAt.ToString());
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.OuterResourceId, dbMatr.OuterResourceId);
            Assert.AreEqual(matr.InnerResourceId, dbMatr.InnerResourceId);

            Assert.AreEqual(1,matrList.Count());
            Assert.AreEqual(1, matrVersions.Count());
        }
    }
}