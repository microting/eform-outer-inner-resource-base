using System;
using System.Collections.Generic;
using System.Linq;
using eFormMachineAreaDotnet.Tests;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace eForm_MachineArea_dotnet.Tests
{
    [TestFixture]
    public class InnerResourceUTest : DbTestFixture
    {
        [Test]
        public void Machine_Create_DoesCreate()
        {
            //Arrange
            
            InnerResource innerResource = new InnerResource();
            innerResource.Name = Guid.NewGuid().ToString();
            
            //Act
            
            innerResource.Create(DbContext);                                                             
                                                                                     
            InnerResource dbInnerResource = DbContext.InnerResources.AsNoTracking().First();                               
            List<InnerResource> machinelList = DbContext.InnerResources.AsNoTracking().ToList();                      
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbInnerResource);                                                             
            Assert.NotNull(dbInnerResource.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());                                                
            Assert.AreEqual(innerResource.CreatedAt.ToString(), dbInnerResource.CreatedAt.ToString());                                  
            Assert.AreEqual(innerResource.Version, dbInnerResource.Version);                                      
            Assert.AreEqual(innerResource.UpdatedAt.ToString(), dbInnerResource.UpdatedAt.ToString());                                  
            Assert.AreEqual(dbInnerResource.WorkflowState, Constants.WorkflowStates.Created);
            Assert.AreEqual(innerResource.CreatedByUserId, dbInnerResource.CreatedByUserId);                      
            Assert.AreEqual(innerResource.UpdatedByUserId, dbInnerResource.UpdatedByUserId);                      
            Assert.AreEqual(innerResource.Name, dbInnerResource.Name);                                            
        }

        [Test]
        public void Machine_Update_DoesUpdate()
        {
            InnerResource innerResource = new InnerResource();
            innerResource.Name = Guid.NewGuid().ToString();
            
            DbContext.InnerResources.Add(innerResource);
            DbContext.SaveChanges();
            
            //Act

            innerResource.Name = Guid.NewGuid().ToString();

            innerResource.Update(DbContext);
                                                                                     
            InnerResource dbInnerResource = DbContext.InnerResources.AsNoTracking().First();                               
            List<InnerResource> machinelList = DbContext.InnerResources.AsNoTracking().ToList();
            List<InnerResourceVersion> machineVersions = DbContext.InnerResourceVersions.AsNoTracking().ToList();
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbInnerResource);                                                             
            Assert.NotNull(dbInnerResource.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());
            Assert.AreEqual(1, machineVersions.Count());
            
            Assert.AreEqual(innerResource.CreatedAt.ToString(), dbInnerResource.CreatedAt.ToString());                                  
            Assert.AreEqual(innerResource.Version, dbInnerResource.Version);                                      
            Assert.AreEqual(innerResource.UpdatedAt.ToString(), dbInnerResource.UpdatedAt.ToString());                                  
            Assert.AreEqual(innerResource.CreatedByUserId, dbInnerResource.CreatedByUserId);                      
            Assert.AreEqual(innerResource.UpdatedByUserId, dbInnerResource.UpdatedByUserId);                      
            Assert.AreEqual(innerResource.Name, dbInnerResource.Name);        
        }

        [Test]
        public void Machine_Delete_SetWorkflowStateToRemoved()
        {
            //Arrange
            
            InnerResource innerResource = new InnerResource();
            innerResource.Name = Guid.NewGuid().ToString();
            
            DbContext.InnerResources.Add(innerResource);
            DbContext.SaveChanges();
            
            //Act

            innerResource.Delete(DbContext);
                                                                                     
            InnerResource dbInnerResource = DbContext.InnerResources.AsNoTracking().First();                               
            List<InnerResource> machinelList = DbContext.InnerResources.AsNoTracking().ToList();
            List<InnerResourceVersion> machineVersions = DbContext.InnerResourceVersions.AsNoTracking().ToList();
                                                                                     
            //Assert                                                                            
                                                                                     
            Assert.NotNull(dbInnerResource);                                                             
            Assert.NotNull(dbInnerResource.Id);                                                          
                                                                                     
            Assert.AreEqual(1,machinelList.Count());
            Assert.AreEqual(1, machineVersions.Count());
            
            Assert.AreEqual(innerResource.CreatedAt.ToString(), dbInnerResource.CreatedAt.ToString());                                  
            Assert.AreEqual(innerResource.Version, dbInnerResource.Version);                                      
            Assert.AreEqual(innerResource.UpdatedAt.ToString(), dbInnerResource.UpdatedAt.ToString());                                  
            Assert.AreEqual(innerResource.CreatedByUserId, dbInnerResource.CreatedByUserId);                      
            Assert.AreEqual(innerResource.UpdatedByUserId, dbInnerResource.UpdatedByUserId);                      
            Assert.AreEqual(innerResource.Name, dbInnerResource.Name);    
            
            Assert.AreEqual(dbInnerResource.WorkflowState, Constants.WorkflowStates.Removed);
        }
    }
}