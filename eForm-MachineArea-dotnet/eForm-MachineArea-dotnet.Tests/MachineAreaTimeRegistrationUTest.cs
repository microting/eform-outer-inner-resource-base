using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormMachineAreaBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eFormMachineAreaDotnet.Tests
{
    [TestFixture]
    public class MachineAreaTimeRegistrationUTest : DbTestFixture
    {
        [Test]
        public void MachineAreaTimeRegistration_Create_DoesCreate()
        {
            //Arrange
            
            OuterResource outerResource = new OuterResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            outerResource.Create(DbContext);
            
            InnerResource innerResource = new InnerResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            innerResource.Create(DbContext);
            
            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.OuterResourceId = outerResource.Id;
            matr.InnerResourceId = innerResource.Id;
            
            //Act
            
            matr.Create(DbContext);
            
            
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
        public void MacineAreaTimeRegistration_Update_DoesUpdate()
        {
            OuterResource outerResource = new OuterResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(outerResource);
            DbContext.SaveChanges();

            InnerResource innerResource = new InnerResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.InnerResources.Add(innerResource);
            DbContext.SaveChanges();
            
            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.OuterResourceId = outerResource.Id;
            matr.InnerResourceId = innerResource.Id;

            DbContext.ResourceTimeRegistrations.Add(matr);
            DbContext.SaveChanges();
            
            //Act
            matr.TimeInHours = 20;
            
            matr.Update(DbContext);

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
        public void MachineAreaTimeRegistration_Delete_DoesSetWorkflowStateToRemoved()
        {
             OuterResource outerResource = new OuterResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(outerResource);
            DbContext.SaveChanges();

            InnerResource innerResource = new InnerResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.InnerResources.Add(innerResource);
            DbContext.SaveChanges();
            
            Random rnd = new Random();
            ResourceTimeRegistration matr = new ResourceTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.OuterResourceId = outerResource.Id;
            matr.InnerResourceId = innerResource.Id;

            DbContext.ResourceTimeRegistrations.Add(matr);
            DbContext.SaveChanges();
            
            //Act
            matr.TimeInHours = 20;
            
            matr.Delete(DbContext);

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