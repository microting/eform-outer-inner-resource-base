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
    public class OuterInnerResourceUTest : DbTestFixture
    {
        [Test]
        public async Task MachineArea_Create_DoesCreate()
        {
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

            OuterInnerResource outerInnerResource = new OuterInnerResource
            {
                OuterResourceId = outerResource.Id,
                InnerResourceId = innerResource.Id
            };

            //Act

            await outerInnerResource.Create(DbContext);

            OuterInnerResource dbOuterInnerResource = DbContext.OuterInnerResources.AsNoTracking().First();
            List<OuterInnerResource> machineAreaList = DbContext.OuterInnerResources.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbOuterInnerResource);
            Assert.NotNull(dbOuterInnerResource.Id);

            Assert.AreEqual(outerInnerResource.OuterResourceId, outerResource.Id);
            Assert.AreEqual(outerInnerResource.InnerResourceId, innerResource.Id);

            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(outerInnerResource.CreatedAt.ToString(), dbOuterInnerResource.CreatedAt.ToString());
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);
            Assert.AreEqual(outerInnerResource.UpdatedAt.ToString(), dbOuterInnerResource.UpdatedAt.ToString());
            Assert.AreEqual(dbOuterInnerResource.WorkflowState, Constants.WorkflowStates.Created);
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
        }

        [Test]
        public async Task MachineArea_Update_DoesUpdate()
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

            OuterInnerResource outerInnerResource = new OuterInnerResource
            {
                OuterResourceId = outerResource.Id,
                InnerResourceId = innerResource.Id
            };

            DbContext.OuterInnerResources.Add(outerInnerResource);
            await DbContext.SaveChangesAsync();

            //Act

            OuterResource newOuterResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.OuterResources.Add(newOuterResource);
            await DbContext.SaveChangesAsync();

            outerInnerResource.OuterResourceId = newOuterResource.Id;
            await outerInnerResource.Update(DbContext);

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

            Assert.AreEqual(outerInnerResource.CreatedAt.ToString(), dbOuterInnerResource.CreatedAt.ToString());
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);
            Assert.AreEqual(outerInnerResource.UpdatedAt.ToString(), dbOuterInnerResource.UpdatedAt.ToString());
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
        }

        [Test]
        public async Task MachineArea_Delete_DoesSetWorkflowStateToRemoved()
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

            OuterInnerResource outerInnerResource = new OuterInnerResource();

            outerInnerResource.OuterResourceId = outerResource.Id;
            outerInnerResource.InnerResourceId = innerResource.Id;

            DbContext.OuterInnerResources.Add(outerInnerResource);
            await DbContext.SaveChangesAsync();

            //Act

            await outerInnerResource.Delete(DbContext);

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

            Assert.AreEqual(outerInnerResource.CreatedAt.ToString(), dbOuterInnerResource.CreatedAt.ToString());
            Assert.AreEqual(outerInnerResource.Version, dbOuterInnerResource.Version);
            Assert.AreEqual(outerInnerResource.UpdatedAt.ToString(), dbOuterInnerResource.UpdatedAt.ToString());
            Assert.AreEqual(outerInnerResource.CreatedByUserId, dbOuterInnerResource.CreatedByUserId);
            Assert.AreEqual(outerInnerResource.UpdatedByUserId, dbOuterInnerResource.UpdatedByUserId);
            Assert.AreEqual(dbOuterInnerResource.WorkflowState, Constants.WorkflowStates.Removed);
        }
    }
}