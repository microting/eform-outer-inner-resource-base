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
    public class AreaUTest : DbTestFixture
    {
        [Test]
        public void Area_Create_DoesCreate()
        {
            //Arrange
            
            Area area = new Area();
            area.Name = Guid.NewGuid().ToString();

            //Act

            area.Create(DbContext);

            Area dbArea = DbContext.Areas.AsNoTracking().First();
            List<Area> areaList = DbContext.Areas.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbArea);
            Assert.NotNull(dbArea.Id);
            
            Assert.AreEqual(1,areaList.Count());
            Assert.AreEqual(area.CreatedAt.ToString(), dbArea.CreatedAt.ToString());
            Assert.AreEqual(area.Version, dbArea.Version);
            Assert.AreEqual(area.UpdatedAt.ToString(), dbArea.UpdatedAt.ToString());
            Assert.AreEqual(dbArea.WorkflowState, Constants.WorkflowStates.Created);
            Assert.AreEqual(area.CreatedByUserId, dbArea.CreatedByUserId);
            Assert.AreEqual(area.UpdatedByUserId, dbArea.UpdatedByUserId);
            Assert.AreEqual(area.Name, dbArea.Name);
        }

        [Test]
        public void Area_Update_DoesUpdate()
        {
            //Arrange
            
            Area area = new Area();
            area.Name = Guid.NewGuid().ToString();

            DbContext.Areas.Add(area);
            DbContext.SaveChanges();
            
            //Act

            area.Name = Guid.NewGuid().ToString();

            area.Update(DbContext);

            Area dbArea = DbContext.Areas.AsNoTracking().First();
            List<Area> areasList = DbContext.Areas.AsNoTracking().ToList();
            List<AreaVersion> areaVersions = DbContext.AreaVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbArea);
            
            Assert.AreEqual(1, areasList.Count());
            Assert.AreEqual(1, areaVersions.Count());
            Assert.AreEqual(area.Name, dbArea.Name);
            Assert.AreEqual(area.CreatedAt.ToString(), dbArea.CreatedAt.ToString());
            Assert.AreEqual(area.Version, dbArea.Version);                                        
            Assert.AreEqual(area.UpdatedAt.ToString(), dbArea.UpdatedAt.ToString());
            Assert.AreEqual(area.CreatedByUserId, dbArea.CreatedByUserId);                        
            Assert.AreEqual(area.UpdatedByUserId, dbArea.UpdatedByUserId);                        
        }

        [Test]
        public void Area_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange
            
            Area area = new Area();
            area.Name = Guid.NewGuid().ToString();

            DbContext.Areas.Add(area);
            DbContext.SaveChanges();
            
            //Act
            area.Delete(DbContext);

            Area dbArea = DbContext.Areas.AsNoTracking().First();
            List<Area> areaList = DbContext.Areas.AsNoTracking().ToList();
            List<AreaVersion> areaVersions = DbContext.AreaVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbArea);
            
            Assert.AreEqual(1, areaList.Count());
            Assert.AreEqual(1, areaVersions.Count());
            
            Assert.AreEqual(area.Name, dbArea.Name);
            Assert.AreEqual(area.CreatedAt.ToString(), dbArea.CreatedAt.ToString());
            Assert.AreEqual(dbArea.WorkflowState, Constants.WorkflowStates.Removed);
                                                                            
            Assert.AreEqual(area.Version, dbArea.Version);                 
            Assert.AreEqual(area.UpdatedAt.ToString(), dbArea.UpdatedAt.ToString());             
            Assert.AreEqual(area.CreatedByUserId, dbArea.CreatedByUserId); 
            Assert.AreEqual(area.UpdatedByUserId, dbArea.UpdatedByUserId); 
        }
    }
}