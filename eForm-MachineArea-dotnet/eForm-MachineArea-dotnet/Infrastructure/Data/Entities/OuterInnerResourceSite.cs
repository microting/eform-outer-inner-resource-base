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
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class OuterInnerResourceSite : BaseEntity
    {        
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        [ForeignKey("MachineArea")]
        public int OuterInnerResourceId { get; set; }
        
//        public virtual MachineArea MachineArea { get; set; }
        
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }
        
        public async Task Create(OuterInnerResourcePnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.OuterInnerResourceSites.Add(this);
            dbContext.SaveChanges();

            dbContext.OuterInnerResourceSiteVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(OuterInnerResourcePnDbContext dbContext)
        {
            OuterInnerResourceSite outerInnerResourceSite = dbContext.OuterInnerResourceSites.FirstOrDefault(x => x.Id == Id);

            if (outerInnerResourceSite == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            outerInnerResourceSite.OuterInnerResourceId = OuterInnerResourceId;
            outerInnerResourceSite.MicrotingSdkCaseId = MicrotingSdkCaseId;
            outerInnerResourceSite.MicrotingSdkeFormId = MicrotingSdkeFormId;
            outerInnerResourceSite.MicrotingSdkSiteId = MicrotingSdkSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerInnerResourceSite.UpdatedAt = DateTime.Now;
                outerInnerResourceSite.Version += 1;

                dbContext.OuterInnerResourceSiteVersions.Add(MapVersions(outerInnerResourceSite));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(OuterInnerResourcePnDbContext dbContext)
        {
            OuterInnerResourceSite outerInnerResourceSite = dbContext.OuterInnerResourceSites.FirstOrDefault(x => x.Id == Id);

            if (outerInnerResourceSite == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            outerInnerResourceSite.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerInnerResourceSite.UpdatedAt = DateTime.Now;
                outerInnerResourceSite.Version += 1;

                dbContext.OuterInnerResourceSiteVersions.Add(MapVersions(outerInnerResourceSite));
                dbContext.SaveChanges();
            }
        }

        private OuterInnerResourceSiteVersion MapVersions(OuterInnerResourceSite outerInnerResourceSite)
        {
            OuterInnerResourceSiteVersion outerInnerResourceSiteVersionVer = new OuterInnerResourceSiteVersion();

            outerInnerResourceSiteVersionVer.OuterInnerResourceId = outerInnerResourceSite.OuterInnerResourceId;
            outerInnerResourceSiteVersionVer.MicrotingSdkCaseId = outerInnerResourceSite.MicrotingSdkCaseId;
            outerInnerResourceSiteVersionVer.MicrotingSdkeFormId = outerInnerResourceSite.MicrotingSdkeFormId;
            outerInnerResourceSiteVersionVer.OuterInnerResourceSiteId = outerInnerResourceSite.Id;
            outerInnerResourceSiteVersionVer.Version = outerInnerResourceSite.Version;
            outerInnerResourceSiteVersionVer.CreatedAt = outerInnerResourceSite.CreatedAt;
            outerInnerResourceSiteVersionVer.UpdatedAt = outerInnerResourceSite.UpdatedAt;


            return outerInnerResourceSiteVersionVer;
        }
    }
    
    
}