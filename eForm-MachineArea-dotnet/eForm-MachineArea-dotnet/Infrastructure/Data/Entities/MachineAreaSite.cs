/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSite : BaseEntity
    {        
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        [ForeignKey("MachineArea")]
        public int MachineAreaId { get; set; }
        
        public virtual MachineArea MachineArea { get; set; }
        
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }
        
        public async Task Save(MachineAreaPnDbContext dbContext)
        {
            MachineAreaSite machineAreaSite = new MachineAreaSite
            {
                MachineAreaId = MachineAreaId,
                MicrotingSdkCaseId = MicrotingSdkCaseId,
                MicrotingSdkeFormId = MicrotingSdkeFormId,
                MicrotingSdkSiteId = MicrotingSdkSiteId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.MachineAreaSites.Add(machineAreaSite);
            dbContext.SaveChanges();

            dbContext.MachineAreaSiteVersions.Add(MapMachineAreaSiteVersion(machineAreaSite));
            dbContext.SaveChanges();
            
            Id = machineAreaSite.Id;
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            MachineAreaSite machineAreaSite = dbContext.MachineAreaSites.FirstOrDefault(x => x.Id == Id);

            if (machineAreaSite == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            machineAreaSite.MachineAreaId = MachineAreaId;
            machineAreaSite.MicrotingSdkCaseId = MicrotingSdkCaseId;
            machineAreaSite.MicrotingSdkeFormId = MicrotingSdkeFormId;
            machineAreaSite.MicrotingSdkSiteId = MicrotingSdkSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaSite.UpdatedAt = DateTime.Now;
                machineAreaSite.Version += 1;

                dbContext.MachineAreaSiteVersions.Add(MapMachineAreaSiteVersion(machineAreaSite));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            MachineAreaSite machineAreaSite = dbContext.MachineAreaSites.FirstOrDefault(x => x.Id == Id);

            if (machineAreaSite == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            machineAreaSite.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaSite.UpdatedAt = DateTime.Now;
                machineAreaSite.Version += 1;

                dbContext.MachineAreaSiteVersions.Add(MapMachineAreaSiteVersion(machineAreaSite));
                dbContext.SaveChanges();
            }
        }

        private MachineAreaSiteVersion MapMachineAreaSiteVersion(MachineAreaSite machineAreaSite)
        {
            MachineAreaSiteVersion machineAreaSiteVersionVer = new MachineAreaSiteVersion();

            machineAreaSiteVersionVer.MachineAreaId = machineAreaSite.MachineAreaId;
            machineAreaSiteVersionVer.MicrotingSdkCaseId = machineAreaSite.MicrotingSdkCaseId;
            machineAreaSiteVersionVer.MicrotingSdkeFormId = machineAreaSite.MicrotingSdkeFormId;
            machineAreaSiteVersionVer.MachineAreaSiteId = machineAreaSite.Id;
            machineAreaSiteVersionVer.Version = machineAreaSite.Version;
            machineAreaSiteVersionVer.CreatedAt = machineAreaSite.CreatedAt;
            machineAreaSiteVersionVer.UpdatedAt = machineAreaSite.UpdatedAt;


            return machineAreaSiteVersionVer;
        }
    }
    
    
}