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
    public class OuterResourceUTest : DbTestFixture
    {
        [Test]
        public async Task Area_Create_DoesCreate()
        {
            //Arrange

            OuterResource outerResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };

            //Act

            await outerResource.Create(DbContext);

            OuterResource dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
            List<OuterResource> areaList = DbContext.OuterResources.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbOuterResource);
            Assert.NotNull(dbOuterResource.Id);

            Assert.AreEqual(1,areaList.Count());
            Assert.AreEqual(outerResource.CreatedAt.ToString(), dbOuterResource.CreatedAt.ToString());
            Assert.AreEqual(outerResource.Version, dbOuterResource.Version);
            Assert.AreEqual(outerResource.UpdatedAt.ToString(), dbOuterResource.UpdatedAt.ToString());
            Assert.AreEqual(dbOuterResource.WorkflowState, Constants.WorkflowStates.Created);
            Assert.AreEqual(outerResource.CreatedByUserId, dbOuterResource.CreatedByUserId);
            Assert.AreEqual(outerResource.UpdatedByUserId, dbOuterResource.UpdatedByUserId);
            Assert.AreEqual(outerResource.Name, dbOuterResource.Name);
        }

        [Test]
        public async Task Area_Update_DoesUpdate()
        {
            //Arrange

            OuterResource outerResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };

            DbContext.OuterResources.Add(outerResource);
            await DbContext.SaveChangesAsync();

            //Act

            outerResource.Name = Guid.NewGuid().ToString();

            await outerResource.Update(DbContext);

            OuterResource dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
            List<OuterResource> areasList = DbContext.OuterResources.AsNoTracking().ToList();
            List<OuterResourceVersion> areaVersions = DbContext.OuterResourceVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbOuterResource);

            Assert.AreEqual(1, areasList.Count());
            Assert.AreEqual(1, areaVersions.Count());
            Assert.AreEqual(outerResource.Name, dbOuterResource.Name);
            Assert.AreEqual(outerResource.CreatedAt.ToString(), dbOuterResource.CreatedAt.ToString());
            Assert.AreEqual(outerResource.Version, dbOuterResource.Version);
            Assert.AreEqual(outerResource.UpdatedAt.ToString(), dbOuterResource.UpdatedAt.ToString());
            Assert.AreEqual(outerResource.CreatedByUserId, dbOuterResource.CreatedByUserId);
            Assert.AreEqual(outerResource.UpdatedByUserId, dbOuterResource.UpdatedByUserId);
        }

        [Test]
        public async Task Area_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange

            OuterResource outerResource = new OuterResource
            {
                Name = Guid.NewGuid().ToString()
            };

            DbContext.OuterResources.Add(outerResource);
            await DbContext.SaveChangesAsync();

            //Act
            await outerResource.Delete(DbContext);

            OuterResource dbOuterResource = DbContext.OuterResources.AsNoTracking().First();
            List<OuterResource> areaList = DbContext.OuterResources.AsNoTracking().ToList();
            List<OuterResourceVersion> areaVersions = DbContext.OuterResourceVersions.AsNoTracking().ToList();

            //Assert

            Assert.NotNull(dbOuterResource);

            Assert.AreEqual(1, areaList.Count());
            Assert.AreEqual(1, areaVersions.Count());

            Assert.AreEqual(outerResource.Name, dbOuterResource.Name);
            Assert.AreEqual(outerResource.CreatedAt.ToString(), dbOuterResource.CreatedAt.ToString());
            Assert.AreEqual(dbOuterResource.WorkflowState, Constants.WorkflowStates.Removed);

            Assert.AreEqual(outerResource.Version, dbOuterResource.Version);
            Assert.AreEqual(outerResource.UpdatedAt.ToString(), dbOuterResource.UpdatedAt.ToString());
            Assert.AreEqual(outerResource.CreatedByUserId, dbOuterResource.CreatedByUserId);
            Assert.AreEqual(outerResource.UpdatedByUserId, dbOuterResource.UpdatedByUserId);
        }
    }
}