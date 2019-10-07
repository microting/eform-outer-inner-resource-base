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
    public class MachineAreaUTest : DbTestFixture
    {
        [Test]
        public void MachineArea_Create_DoesCreate()
        {
            Area area = new Area()
            {
                Name = Guid.NewGuid().ToString()
            };
            area.Create(DbContext);
            
            Machine machine = new Machine()
            {
                Name = Guid.NewGuid().ToString()
            };
            machine.Create(DbContext);
            
            Random rnd = new Random();
            MachineArea machineArea = new MachineArea();

            machineArea.AreaId = area.Id;
            machineArea.MachineId = machine.Id;
            
            //Act
            
            machineArea.Create(DbContext);
            
            MachineArea dbMachineArea = DbContext.MachineAreas.AsNoTracking().First();
            List<MachineArea> machineAreaList = DbContext.MachineAreas.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMachineArea);
            Assert.NotNull(dbMachineArea.Id);
            
            Assert.AreEqual(machineArea.AreaId, area.Id);
            Assert.AreEqual(machineArea.MachineId, machine.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(machineArea.CreatedAt.ToString(), dbMachineArea.CreatedAt.ToString());                                                     
            Assert.AreEqual(machineArea.Version, dbMachineArea.Version);                                                         
            Assert.AreEqual(machineArea.UpdatedAt.ToString(), dbMachineArea.UpdatedAt.ToString());                                                     
            Assert.AreEqual(dbMachineArea.WorkflowState, Constants.WorkflowStates.Created);                   
            Assert.AreEqual(machineArea.CreatedByUserId, dbMachineArea.CreatedByUserId);                                         
            Assert.AreEqual(machineArea.UpdatedByUserId, dbMachineArea.UpdatedByUserId);
        }

        [Test]
        public void MachineArea_Update_DoesUpdate()
        {
            Area area = new Area()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.Areas.Add(area);
            DbContext.SaveChanges();
            
            Machine machine = new Machine()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.Machines.Add(machine);
            DbContext.SaveChanges();
            
            Random rnd = new Random();
            MachineArea machineArea = new MachineArea();

            machineArea.AreaId = area.Id;
            machineArea.MachineId = machine.Id;
            
            DbContext.MachineAreas.Add(machineArea);
            DbContext.SaveChanges();
            
            //Act

            Area newArea = new Area()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.Areas.Add(newArea);
            DbContext.SaveChanges();

            machineArea.AreaId = newArea.Id;
            machineArea.Update(DbContext);
            
            MachineArea dbMachineArea = DbContext.MachineAreas.AsNoTracking().First();
            List<MachineArea> machineAreaList = DbContext.MachineAreas.AsNoTracking().ToList();
            List<MachineAreaVersion> machineAreaVersions = DbContext.MachineAreaVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMachineArea);
            Assert.NotNull(dbMachineArea.Id);
            
            Assert.AreEqual(dbMachineArea.AreaId, newArea.Id);
            Assert.AreEqual(dbMachineArea.MachineId, machine.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(1, machineAreaVersions.Count());
            
            Assert.AreEqual(machineArea.CreatedAt.ToString(), dbMachineArea.CreatedAt.ToString());                                                     
            Assert.AreEqual(machineArea.Version, dbMachineArea.Version);                                                         
            Assert.AreEqual(machineArea.UpdatedAt.ToString(), dbMachineArea.UpdatedAt.ToString());                                                     
            Assert.AreEqual(machineArea.CreatedByUserId, dbMachineArea.CreatedByUserId);                                         
            Assert.AreEqual(machineArea.UpdatedByUserId, dbMachineArea.UpdatedByUserId);
        }

        [Test]
        public void MachineArea_Delete_DoesSetWorkflowStateToRemoved()
        {
            Area area = new Area()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.Areas.Add(area);
            DbContext.SaveChanges();
            
            Machine machine = new Machine()
            {
                Name = Guid.NewGuid().ToString()
            };
            DbContext.Machines.Add(machine);
            DbContext.SaveChanges();
            
            Random rnd = new Random();
            MachineArea machineArea = new MachineArea();

            machineArea.AreaId = area.Id;
            machineArea.MachineId = machine.Id;
            
            DbContext.MachineAreas.Add(machineArea);
            DbContext.SaveChanges();
            
            //Act
            
            machineArea.Delete(DbContext);
            
            MachineArea dbMachineArea = DbContext.MachineAreas.AsNoTracking().First();
            List<MachineArea> machineAreaList = DbContext.MachineAreas.AsNoTracking().ToList();
            List<MachineAreaVersion> machineAreaVersions = DbContext.MachineAreaVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMachineArea);
            Assert.NotNull(dbMachineArea.Id);
            
            Assert.AreEqual(dbMachineArea.MachineId, machine.Id);
            Assert.AreEqual(dbMachineArea.AreaId, area.Id);
            
            Assert.AreEqual(1,machineAreaList.Count());
            Assert.AreEqual(1, machineAreaVersions.Count());
            
            Assert.AreEqual(machineArea.CreatedAt.ToString(), dbMachineArea.CreatedAt.ToString());                                                     
            Assert.AreEqual(machineArea.Version, dbMachineArea.Version);                                                         
            Assert.AreEqual(machineArea.UpdatedAt.ToString(), dbMachineArea.UpdatedAt.ToString());                                                     
            Assert.AreEqual(machineArea.CreatedByUserId, dbMachineArea.CreatedByUserId);                                         
            Assert.AreEqual(machineArea.UpdatedByUserId, dbMachineArea.UpdatedByUserId);
            Assert.AreEqual(dbMachineArea.WorkflowState, Constants.WorkflowStates.Removed);
        }
    }
}