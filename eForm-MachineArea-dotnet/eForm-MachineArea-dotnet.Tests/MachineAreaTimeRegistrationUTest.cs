using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            MachineAreaTimeRegistration matr = new MachineAreaTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.Area = area;
            matr.Machine = machine;
            
            //Act
            
            matr.Create(DbContext);
            
            
            MachineAreaTimeRegistration dbMatr = DbContext.MachineAreaTimeRegistrations.AsNoTracking().First();
            List<MachineAreaTimeRegistration> matrList = DbContext.MachineAreaTimeRegistrations.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMatr);
            
            Assert.AreEqual(matr.DoneAt, dbMatr.DoneAt);
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.AreaId, dbMatr.AreaId);
            Assert.AreEqual(matr.MachineId, dbMatr.MachineId);
            
            Assert.AreEqual(1,matrList.Count());
        }

        [Test]
        public void MacineAreaTimeRegistration_Update_DoesUpdate()
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
            MachineAreaTimeRegistration matr = new MachineAreaTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.Area = area;
            matr.Machine = machine;

            DbContext.MachineAreaTimeRegistrations.Add(matr);
            DbContext.SaveChanges();
            
            //Act
            matr.TimeInHours = 20;
            
            matr.Update(DbContext);

            MachineAreaTimeRegistration dbMatr = DbContext.MachineAreaTimeRegistrations.AsNoTracking().First();
            List<MachineAreaTimeRegistration> matrList = DbContext.MachineAreaTimeRegistrations.AsNoTracking().ToList();
            List<MachineAreaTimeRegistrationVersion> matrVersions =
                DbContext.MachineAreaTimeRegistrationVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMatr);
            
            Assert.AreEqual(matr.DoneAt, dbMatr.DoneAt);
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.AreaId, dbMatr.AreaId);
            Assert.AreEqual(matr.MachineId, dbMatr.MachineId);
            
            Assert.AreEqual(1,matrList.Count());
            Assert.AreEqual(1, matrVersions.Count());
        }

        [Test]
        public void MachineAreaTimeRegistration_Delete_DoesSetWorkflowStateToRemoved()
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
            MachineAreaTimeRegistration matr = new MachineAreaTimeRegistration();
            
            matr.DoneAt = DateTime.Now;
            matr.TimeInHours = 10;
            matr.TimeInMinutes = 60;
            matr.TimeInSeconds = 100;
            matr.SDKCaseId = rnd.Next(1, 100);
            matr.SDKSiteId = rnd.Next(1, 100);
            matr.SDKFieldValueId = rnd.Next(1, 100);
            matr.Area = area;
            matr.Machine = machine;

            DbContext.MachineAreaTimeRegistrations.Add(matr);
            DbContext.SaveChanges();
            
            //Act
            matr.TimeInHours = 20;
            
            matr.Delete(DbContext);

            MachineAreaTimeRegistration dbMatr = DbContext.MachineAreaTimeRegistrations.AsNoTracking().First();
            List<MachineAreaTimeRegistration> matrList = DbContext.MachineAreaTimeRegistrations.AsNoTracking().ToList();
            List<MachineAreaTimeRegistrationVersion> matrVersions =
                DbContext.MachineAreaTimeRegistrationVersions.AsNoTracking().ToList();
            
            //Assert
            
            Assert.NotNull(dbMatr);
            Assert.AreEqual(dbMatr.WorkflowState, eFormShared.Constants.WorkflowStates.Removed);
            
            Assert.AreEqual(matr.DoneAt, dbMatr.DoneAt);
            Assert.AreEqual(matr.TimeInHours, dbMatr.TimeInHours);
            Assert.AreEqual(matr.TimeInMinutes, dbMatr.TimeInMinutes);
            Assert.AreEqual(matr.TimeInSeconds, dbMatr.TimeInSeconds);
            Assert.AreEqual(matr.SDKCaseId, dbMatr.SDKCaseId);
            Assert.AreEqual(matr.SDKSiteId, dbMatr.SDKSiteId);
            Assert.AreEqual(matr.SDKFieldValueId, dbMatr.SDKFieldValueId);
            Assert.AreEqual(matr.AreaId, dbMatr.AreaId);
            Assert.AreEqual(matr.MachineId, dbMatr.MachineId);
            
            Assert.AreEqual(1,matrList.Count());
            Assert.AreEqual(1, matrVersions.Count());
        }
    }
}