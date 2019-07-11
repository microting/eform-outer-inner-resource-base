using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eFormMachineAreaBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eFormMachineAreaDotnet.Tests
{
    [TestFixture]
    public class MachineUTest : DbTestFixture
    {
        [Test]
        public void Machine_Create_DoesCreate()
        {
            //Arrange
            
            Machine machine = new Machine();
            machine.Name = Guid.NewGuid().ToString();
            
            //Act
            
            machine.Create(DbContext);                                                             
                                                                                     
            Machine dbMachine = DbContext.Machines.AsNoTracking().First();                               
            List<Machine> machinelList = DbContext.Machines.AsNoTracking().ToList();                      
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbMachine);                                                             
            Assert.NotNull(dbMachine.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());                                                
            Assert.AreEqual(machine.CreatedAt, dbMachine.CreatedAt);                                  
            Assert.AreEqual(machine.Version, dbMachine.Version);                                      
            Assert.AreEqual(machine.UpdatedAt, dbMachine.UpdatedAt);                                  
            Assert.AreEqual(dbMachine.WorkflowState, eFormShared.Constants.WorkflowStates.Created);
            Assert.AreEqual(machine.CreatedByUserId, dbMachine.CreatedByUserId);                      
            Assert.AreEqual(machine.UpdatedByUserId, dbMachine.UpdatedByUserId);                      
            Assert.AreEqual(machine.Name, dbMachine.Name);                                            
        }

        [Test]
        public void Machine_Update_DoesUpdate()
        {
            Machine machine = new Machine();
            machine.Name = Guid.NewGuid().ToString();
            
            DbContext.Machines.Add(machine);
            DbContext.SaveChanges();
            
            //Act

            machine.Name = Guid.NewGuid().ToString();

            machine.Update(DbContext);
                                                                                     
            Machine dbMachine = DbContext.Machines.AsNoTracking().First();                               
            List<Machine> machinelList = DbContext.Machines.AsNoTracking().ToList();
            List<MachineVersion> machineVersions = DbContext.MachineVersions.AsNoTracking().ToList();
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbMachine);                                                             
            Assert.NotNull(dbMachine.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());
            Assert.AreEqual(1, machineVersions.Count());
            
            Assert.AreEqual(machine.CreatedAt, dbMachine.CreatedAt);                                  
            Assert.AreEqual(machine.Version, dbMachine.Version);                                      
            Assert.AreEqual(machine.UpdatedAt, dbMachine.UpdatedAt);                                  
            Assert.AreEqual(machine.CreatedByUserId, dbMachine.CreatedByUserId);                      
            Assert.AreEqual(machine.UpdatedByUserId, dbMachine.UpdatedByUserId);                      
            Assert.AreEqual(machine.Name, dbMachine.Name);        
        }

        [Test]
        public void Machine_Delete_SetWorkflowStateToRemoved()
        {
            //Arrange
            
            Machine machine = new Machine();
            machine.Name = Guid.NewGuid().ToString();
            
            DbContext.Machines.Add(machine);
            DbContext.SaveChanges();
            
            //Act

            machine.Delete(DbContext);
                                                                                     
            Machine dbMachine = DbContext.Machines.AsNoTracking().First();                               
            List<Machine> machinelList = DbContext.Machines.AsNoTracking().ToList();
            List<MachineVersion> machineVersions = DbContext.MachineVersions.AsNoTracking().ToList();
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbMachine);                                                             
            Assert.NotNull(dbMachine.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());
            Assert.AreEqual(1, machineVersions.Count());
            
            Assert.AreEqual(machine.CreatedAt, dbMachine.CreatedAt);                                  
            Assert.AreEqual(machine.Version, dbMachine.Version);                                      
            Assert.AreEqual(machine.UpdatedAt, dbMachine.UpdatedAt);                                  
            Assert.AreEqual(machine.CreatedByUserId, dbMachine.CreatedByUserId);                      
            Assert.AreEqual(machine.UpdatedByUserId, dbMachine.UpdatedByUserId);                      
            Assert.AreEqual(machine.Name, dbMachine.Name);    
            
            Assert.AreEqual(dbMachine.WorkflowState, eFormShared.Constants.WorkflowStates.Removed);
        }
    }
}