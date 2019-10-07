using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eFormMachineAreaDotnet.Tests
{
    [TestFixture]
    public class MachineAreaUTest : DbTestFixture
    {
        [Test]
        public void MachineArea_Create_DoesCreate()
        {
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
            OuterInnerResource outerInnerResource = new OuterInnerResource();

            outerInnerResource.OuterResource = outerResource;
            outerInnerResource.InnerResource = innerResource;
            
            //Act
            
            outerInnerResource.Create(DbContext);
            
            OuterInnerResource dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
            List<OuterInnerResource> machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbOuterInnerResource);
            Assert.NotNull(dbOuterInnerResource.Id);
            
            Assert.AreEqual(outerInnerResource.OuterResourceId, outerResource.Id);
            Assert.AreEqual(outerInnerResource.InnerResourceId, innerResource.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(outerInnerResource.CreatedAt, dbOuterInnerResource.CreatedAt);                                                     
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);                                                         
            Assert.AreEqual(outerInnerResource.UpdatedAt, dbOuterInnerResource.UpdatedAt);                                                     
            Assert.AreEqual(dbOuterInnerResource.WorkflowState, Constants.WorkflowStates.Created);                   
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);                                         
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
        }

        [Test]
        public void MachineArea_Update_DoesUpdate()
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
            OuterInnerResource outerInnerResource = new OuterInnerResource();

            outerInnerResource.OuterResource = outerResource;
            outerInnerResource.InnerResource = innerResource;
            
            DbContext.OuterInnerResources.Add(outerInnerResource);
            DbContext.SaveChanges();
            
            //Act

            OuterResource newOuterResource = new OuterResource()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(newOuterResource);
            DbContext.SaveChanges();

            outerInnerResource.OuterResource = newOuterResource;
            outerInnerResource.Update(DbContext);
            
            OuterInnerResource dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
            List<OuterInnerResource> machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();
            List<OuterInnerResourceVersion> machineAreaVersions = DbContext.OuterInnerResourceVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbOuterInnerResource);
            Assert.NotNull(dbOuterInnerResource.Id);
            
            Assert.AreEqual(dbOuterInnerResource.OuterResourceId, newOuterResource.Id);
            Assert.AreEqual(dbOuterInnerResource.InnerResourceId, innerResource.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(1, machineAreaVersions.Count());
            
            Assert.AreEqual(outerInnerResource.CreatedAt, dbOuterInnerResource.CreatedAt);                                                     
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);                                                         
            Assert.AreEqual(outerInnerResource.UpdatedAt, dbOuterInnerResource.UpdatedAt);                                                     
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);                                         
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
        }

        [Test]
        public void MachineArea_Delete_DoesSetWorkflowStateToRemoved()
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
            OuterInnerResource outerInnerResource = new OuterInnerResource();

            outerInnerResource.OuterResource = outerResource;
            outerInnerResource.InnerResource = innerResource;
            
            DbContext.OuterInnerResources.Add(outerInnerResource);
            DbContext.SaveChanges();
            
            //Act
            
            outerInnerResource.Delete(DbContext);
            
            OuterInnerResource dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
            List<OuterInnerResource> machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();
            List<OuterInnerResourceVersion> machineAreaVersions = DbContext.OuterInnerResourceVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbOuterInnerResource);
            Assert.NotNull(dbOuterInnerResource.Id);
            
            Assert.AreEqual(dbOuterInnerResource.InnerResourceId, innerResource.Id);
            Assert.AreEqual(dbOuterInnerResource.OuterResourceId, outerResource.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(1, machineAreaVersions.Count());
            
            Assert.AreEqual(outerInnerResource.CreatedAt, dbOuterInnerResource.CreatedAt);                                                     
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);                                                         
            Assert.AreEqual(outerInnerResource.UpdatedAt, dbOuterInnerResource.UpdatedAt);                                                     
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);                                         
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
            Assert.AreEqual(dbOuterInnerResource.WorkflowState, Constants.WorkflowStates.Removed);
        }
    }
}